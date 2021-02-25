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

        public enum eTipo // Defino el enumerado
        {
            Numerico, // (Números enteros: sólo son válidos los dígitos y espacios en los extremos)
            Texto // (No admitirá nada que no sea una serie de letras o espacios)
        }

        private eTipo tipo = eTipo.Texto;
        [Category("TextBox")]
        [Description("Referente al tipo de caracteres que se pueden escribir en el TextBox")]
        public eTipo Tipo
        {
            set
            {
                tipo = value;
            }

            get 
            { 
                return tipo; 
            }
        }


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


        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);

            this.Height = textBox.Height + 20;
            textBox.Width = this.Width - 20;


            Graphics g = pe.Graphics;
            //Esta propiedad provoca mejoras en la apariencia o en la eficiencia a la hora de dibujar
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int grosor = 5; // Variable que controla el grosor del lápiz
            Pen lapiz = new Pen(Color.Red, grosor);

            // Dibujo el recuadro al rededor del TextBox
            g.DrawLine(lapiz, 5, 5, textBox.Width + 10 + 5, 5); // 10 + 5 porque el ancho del textbox es el ancho del componente -20, por lo que 10 es la mitad y +5 es hasta donde llega el recuadro
            g.DrawLine(lapiz, 5, 5, 5, textBox.Height + 10 + 5);
            g.DrawLine(lapiz, 5, textBox.Height + 10 + 5, textBox.Width + 10 + 5, textBox.Height + 10 + 5);
            g.DrawLine(lapiz, textBox.Width + 10 + 5, textBox.Height + 10 + 5, textBox.Width + 10 + 5, 5);
        }
    }
}
