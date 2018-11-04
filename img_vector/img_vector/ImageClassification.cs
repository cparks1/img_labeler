using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    public class ImageClassification
    {
        #region Fields
        
        /// <summary>
        /// Absolute path of the image being classified.
        /// </summary>
        public string imagePath;

        /// <summary>
        /// Image being classified.
        /// </summary>
        public Image WorkingImage()
        {
            return Image.FromFile(imagePath);
        }

        /// <summary>
        /// Size of the image being classified.
        /// </summary>
        public readonly Size imageSize;

        /// <summary>
        /// Classification vectors of the image.
        /// </summary>
        public List<Vector> vectors;

        /// <summary>
        /// Classified PNG mask objects that contain a base 64 encoded string representing a PNG mask, and a string describing the object the mask is classifying.
        /// </summary>
        public List<ClassifiedSerializedPNGMask> pngMasks
        {
            get { return ClassifiedSerializedPNGMask.MasksFromImageClassification(this); }
        }

        #endregion Fields

        #region Constructors

        public ImageClassification()
        {
            vectors = new List<Vector>();
        }

        public ImageClassification(string imagePath) : this()
        {
            this.imagePath = imagePath;
            using (Image i = WorkingImage())
            {
                this.imageSize = i.Size;
            }
        }

        #endregion Constructors

        /// <summary>
        /// Returns images representing PNG masks of each classified vector.
        /// </summary>
        /// <returns></returns>
        public Image[] PNG_Masks()
        {
            Image[] masks = new Image[this.vectors.Count];

            for(int i=0; i < this.vectors.Count; i++)
            {
                Vector v = this.vectors[i];
                using (Bitmap b = new Bitmap(this.imageSize.Width, this.imageSize.Height))
                {
                    using (Graphics g = Graphics.FromImage(b))
                    {
                        v.DrawPNGMask(g);
                    }
                    masks[i] = new Bitmap(b);
                }
            }

            return masks;
        }

        /// <summary>
        /// Converts a PNG mask into a base 64 encoded string representing the mask image.
        /// </summary>
        /// <param name="mask">Image to be converted.</param>
        /// <returns>Base 64 encoded string</returns>
        public static string SerializedPNGMask(Image mask)
        {
            using (MemoryStream ms = new MemoryStream()) // Create a memory stream to save the images in PNG format, convert them to base 64 formatted strings, and dispose of the memory stream.
            {
                mask.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return Convert.ToBase64String(ms.ToArray());
            }
        }

        /// <summary>
        /// Generates PNG masks for all of the classified vectors, and converts them to base 64 encoded strings.
        /// </summary>
        /// <returns>An array of base 64 encoded strings.</returns>
        public string[] SerializedPNGMasks()
        {
            Image[] masks = PNG_Masks();
            string[] b64_encoded_masks = new string[masks.Length];

            for (int i = 0; i < masks.Length; i++)
            {
                Image mask = masks[i];
                b64_encoded_masks[i] = SerializedPNGMask(mask);
                mask.Dispose(); // Release resources used by the image.
            }

            return b64_encoded_masks;
        }
    }
}
