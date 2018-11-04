using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    public class ClassifiedSerializedPNGMask
    {
        public ClassifiedSerializedPNGMask()
        {

        }

        public ClassifiedSerializedPNGMask(Vector classifiedVector, Size originalImageSize)
        {
            this.classification = classifiedVector.classification;

            Image maskImage = classifiedVector.PNGMask(originalImageSize);
            this.base64EncodedMask = ImageClassification.SerializedPNGMask(maskImage);

            maskImage.Dispose();
        }

        public static ClassifiedSerializedPNGMask FromVectorAndClassifier(Vector classifiedVector, ImageClassification classifier)
        {
            return new ClassifiedSerializedPNGMask(classifiedVector, classifier.imageSize);
        }

        public static List<ClassifiedSerializedPNGMask> MasksFromImageClassification(ImageClassification classification)
        {
            List<ClassifiedSerializedPNGMask> masks = new List<ClassifiedSerializedPNGMask>();

            foreach (Vector v in classification.vectors)
            {
                masks.Add(FromVectorAndClassifier(v, classification));
            }

            return masks;
        }

        /// <summary>
        /// Object this mask is classifying.
        /// </summary>
        public readonly string classification;

        /// <summary>
        /// Base 64 encoded PNG image.
        /// </summary>
        public readonly string base64EncodedMask;

        /// <summary>
        /// Converts the Base 64 encoded mask to an array of bytes.
        /// </summary>
        /// <returns></returns>
        public byte[] maskToBytes()
        {
            return Convert.FromBase64String(this.base64EncodedMask);
        }

        /// <summary>
        /// Converts the Base 64 encoded mask to an image object.
        /// </summary>
        /// <returns></returns>
        public Image maskToImage()
        {
            using (MemoryStream ms = new MemoryStream(maskToBytes()))
            {
                return Image.FromStream(ms);
            }
        }
    }
}
