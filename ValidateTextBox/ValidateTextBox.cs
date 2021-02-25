using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidateTextBox
{
    public partial class ValidateTextBox : UserControl
    {

        [Category("TextBox")]
        [Description("Referente al texto del TextBox")]
        public string Texto
        {
            set
            {
                textBox.Text = value;
            }

            get
            {
                return textBox.Text;
            }
        }


        [Category("TextBox")]
        [Description("Referente a la propiedad multilínea del TextBox")]
        public bool Multilinea
        {
            set
            {
                textBox.Multiline = value;
            }

            get
            {
                return textBox.Multiline;
            }
        }


        public ValidateTextBox()
        {
            InitializeComponent();

        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            this.Height = textBox.Height + 20;
            textBox.Width = this.Width - 20;
        }
    }
}
