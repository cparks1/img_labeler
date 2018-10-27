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
    public class Settings
    {
        /// <summary>
        /// Color of the outer (border) portion of each point added by the user.
        /// </summary>
        public Color pointOuterColor;

        /// <summary>
        /// Color of the inner portion of each point added by the user.
        /// </summary>
        public Color pointInnerColor;

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
            pointOuterColor = Color.Black; // Point border color solid black by default
            pointInnerColor = Color.Transparent; // Point inner color transparent by default
            lineColor = Color.Black; // Lines defining vector color solid black by default
            shadingColor = Color.FromArgb(128, Color.Purple); // Vector shading color half opaque purple by default
        }

        public Settings(Color PointOuterColor, Color PointInnerColor, Color LineColor, Color ShadingColor)
        {
            this.pointOuterColor = PointOuterColor;
            this.pointInnerColor = PointInnerColor;
            this.lineColor = LineColor;
            this.shadingColor = ShadingColor;
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
            this.pointOuterColor = loaded_settings.pointOuterColor;
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
