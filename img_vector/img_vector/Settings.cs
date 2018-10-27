using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace img_vector
{
    class Settings
    {
        /// <summary>
        /// Color of each point added by the user.
        /// </summary>
        public Color pointColor;

        /// <summary>
        /// Color of each line drawn inbetween points.
        /// </summary>
        public Color lineColor;

        /// <summary>
        /// Color of the shading inbetween all of the points.
        /// </summary>
        public Color shadingColor;

        /// <summary>
        /// Default settings instantiation object that sets the default settings.
        /// </summary>
        public Settings()
        {
            pointColor = Color.Black;
            lineColor = Color.Black;
            shadingColor = Color.Purple;
        }

        /// <summary>
        /// Initializes a settings object from a file.
        /// </summary>
        /// <param name="filename"></param>
        public Settings(XmlReader writer)
        {
            // Create a serializer object that will handle the settings object
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));

            // Deserialize the XML encoded settings
            Settings loaded_settings = serializer.Deserialize(writer) as Settings;

            // Load the settings
            this.pointColor = loaded_settings.pointColor;
            this.lineColor = loaded_settings.lineColor;
            this.shadingColor = loaded_settings.shadingColor;
        }

        public static Settings fromFilepath(string filepath)
        {
            return new Settings(XmlReader.Create(filepath));
        }

        /// <summary>
        /// Saves the current settings to an XML file at the designated filepath.
        /// </summary>
        /// <param name="filepath"></param>
        public void saveToXMLFile(string filepath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Settings));
            XmlWriter writer = XmlWriter.Create(filepath);

            serializer.Serialize(writer, this);
        }
    }
}
