using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace img_vector
{
    class ImageClassification
    {
        public string imagePath;

        public List<Vector> vectors;

        public ImageClassification()
        {
            vectors = new List<Vector>();
        }

        public ImageClassification(string imagePath) : this()
        {
            this.imagePath = imagePath;
        }
    }
}
