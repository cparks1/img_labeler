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
    public partial class ClassificationQueryForm : Form
    {
        public ClassificationQueryForm()
        {
            InitializeComponent();
        }

        public ClassificationQueryForm(bool CancelEnabled) : this()
        {
                cancelButton.Enabled = CancelEnabled;
        }

        public string Classification
        {
            get { return classificationTextBox.Text; }
            set
            {
                classificationTextBox.Text = value;
                classificationTextBox.SelectAll();
            }
        }
    }
}
