using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace img_vector
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        public SettingsForm(Settings currentSettings) : this()
        {
            this.Settings = currentSettings;
        }

        public Color PointBorderColor
        {
            get
            {
                return Color.FromArgb((int)pointBorderColorAlphaLevel.Value, (int)pointBorderColorRedLevel.Value, (int)pointBorderColorGreenLevel.Value, (int)pointBorderColorBlueLevel.Value);
            }
            set
            {
                pointBorderColorAlphaLevel.Value = value.A;
                pointBorderColorRedLevel.Value = value.R;
                pointBorderColorGreenLevel.Value = value.G;
                pointBorderColorBlueLevel.Value = value.B;
            }
        }

        public Color PointInnerColor
        {
            get
            {
                return Color.FromArgb((int)pointInnerColorAlphaLevel.Value, (int)pointInnerColorRedLevel.Value, (int)pointInnerColorGreenLevel.Value, (int)pointInnerColorBlueLevel.Value);
            }
            set
            {
                pointInnerColorAlphaLevel.Value = value.A;
                pointInnerColorRedLevel.Value = value.R;
                pointInnerColorGreenLevel.Value = value.G;
                pointInnerColorBlueLevel.Value = value.B;
            }
        }

        public Color VectorLineColor
        {
            get
            {
                return Color.FromArgb((int)vectorLineColorAlphaLevel.Value, (int)vectorLineColorRedLevel.Value, (int)vectorLineColorGreenLevel.Value, (int)vectorLineColorBlueLevel.Value);
            }
            set
            {
                vectorLineColorAlphaLevel.Value = value.A;
                vectorLineColorRedLevel.Value = value.R;
                vectorLineColorGreenLevel.Value = value.G;
                vectorLineColorBlueLevel.Value = value.B;
            }
        }

        public Color VectorShadingColor
        {
            get
            {
                return Color.FromArgb((int)vectorShadingColorAlphaLevel.Value, (int)vectorShadingColorRedLevel.Value, (int)vectorShadingColorGreenLevel.Value, (int)vectorShadingColorBlueLevel.Value);
            }
            set
            {
                vectorShadingColorAlphaLevel.Value = value.A;
                vectorShadingColorRedLevel.Value = value.R;
                vectorShadingColorGreenLevel.Value = value.G;
                vectorShadingColorBlueLevel.Value = value.B;
            }
        }

        public int PointSize
        {
            get
            {
                return (int)pointSizeSelector.Value;
            }
            set
            {
                pointSizeSelector.Value = value;
            }
        }

        public PointRepresentationType PointRepresentationType
        {
            get
            {
                if(PointRepresentationType.TryParse(pointCenterTypeSelector.SelectedText.Replace(" ", ""), out PointRepresentationType representationType))
                {
                    return representationType;
                }
                else
                {
                    return PointRepresentationType.TopLeft;
                }
            }
            set
            {
                string enum_string = value.ToString();
                string user_representation_of_string = "";

                for (int i = 0; i < enum_string.Length; i++)
                {
                    char c = enum_string[i];
                    user_representation_of_string += (char.IsUpper(c) && i != 0 ? " " + c : "" + c); // If it's an uppercase letter, add a space before it, so "TopLeft" becomes "Top Left"
                }

                pointCenterTypeSelector.SelectedIndex = pointCenterTypeSelector.FindStringExact(user_representation_of_string);
            }
        }

        public Settings Settings
        {
            get
            {
                return new Settings(PointBorderColor, PointInnerColor, VectorLineColor, VectorShadingColor, PointSize, PointRepresentationType);
            }
            set
            {
                PointInnerColor = value.pointInnerColor;
                PointBorderColor = value.pointOuterColor;
                VectorLineColor = value.lineColor;
                VectorShadingColor = value.shadingColor;
                PointSize = value.pointSize;
                PointRepresentationType = value.pointRepresentationType;
            }
        }

        public void PointBorderColorValueChanged(object sender, EventArgs e)
        {
            pointBorderColorBox.BackColor = PointBorderColor;
        }

        public void PointInnerColorValueChanged(object sender, EventArgs e)
        {
            pointInnerColorBox.BackColor = PointInnerColor;
        }

        public void VectorLineColorValueChanged(object sender, EventArgs e)
        {
            vectorLineColorBox.BackColor = VectorLineColor;
        }

        public void VectorShadingColorValueChanged(object sender, EventArgs e)
        {
            vectorShadingColorBox.BackColor = VectorShadingColor;
        }
    }
}
