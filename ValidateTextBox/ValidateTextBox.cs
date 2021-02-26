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


        private bool correcto = false;

        [Category("TextBox")]
        [Description("Referente al texto del TextBox")]
        public string Texto
        {
            set
            {
                switch (Tipo) // Compruebo qué tipo es el seleccionado actualmente
                {
                    case eTipo.Numerico: // Si es Numerico
                        try
                        {
                            int num = Convert.ToInt32(value.Trim());

                            correcto = true; // Si los caracteres introducidos son correctos y forman un número entero, el recuadro cambia a verde
                        }
                        catch (FormatException)
                        {
                            correcto = false;
                        }
                        break;


                    case eTipo.Texto: // Si es Texto
                        int contCorrectos = 0; // Contador para ver los caracteres correctos

                        // Recorro los caracteres del texto introducido :
                        for (int i = 0; i < value.Length; i++)
                        {
                            if (Char.IsLetter(value[i]) || Char.IsWhiteSpace(value[i]))
                            {
                                    contCorrectos++;  // Y si es un caracter correcto, se incrementa el contador
                            }
                        }

                        if (contCorrectos == value.Length) // Si al final de recorrer todos los caracteres, todos son correctos
                        {
                            // El recuadro se pinta de verde y se establece el nuevo texto del TextBox
                            correcto = true;
                        }
                        else
                        {
                            // El recuadro se pinta de rojo y no se establece el nuevo texto del TextBox
                            correcto = false;
                        }

                        break;
                }

                textBox.Text = value;
                this.Refresh();

                if (textBox.Text == "")
                {
                    correcto = false;
                }
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

            Pen lapiz;
            if (correcto) // Si los caracteres introducidos en el TextBox son correctos :
            {
                lapiz = new Pen(Color.Green, grosor);
            }
            else
            {
                lapiz = new Pen(Color.Red, grosor);
            }

            // Dibujo el recuadro alrededor del TextBox
            // 10 + 5 porque el ancho del textbox es el ancho del componente -20, por lo que 10 es la mitad y +5 es hasta donde llega el recuadro
            g.DrawRectangle(lapiz, 5, 5, textBox.Width + 10, textBox.Height + 10);
        }


        // Este evento se lanza cuando se cambia en tiempo real el texto del TextBox
        [Category("TextBox")]
        [Description("Se lanza cuando sucede el evento TextChanged en el TextBox")]
        public event EventHandler TxtChanged;

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.Texto = textBox.Text;
            TxtChanged?.Invoke(this, EventArgs.Empty); // Lanzo el evento TxtChanged
            
        }
    }
}
