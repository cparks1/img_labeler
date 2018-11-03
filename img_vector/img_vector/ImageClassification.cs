using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    public class ImageClassification
    {
        /// <summary>
        /// Path of the image being classified.
        /// </summary>
        public string imagePath;

        /// <summary>
        /// Image being classified.
        /// </summary>
        [JsonIgnore] // Don't want to try to encode the image into the JSON or XML file. It can't anyways.
        public readonly Image image;

        /// <summary>
        /// Classification vectors of the image.
        /// </summary>
        public List<Vector> vectors;

        public ImageClassification()
        {
            vectors = new List<Vector>();
        }

        public ImageClassification(string imagePath) : this()
        {
            this.imagePath = imagePath;
            this.image = Image.FromFile(imagePath);
        }

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
                using (Bitmap b = new Bitmap(this.image.Width, this.image.Height))
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
    }
}
