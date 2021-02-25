namespace Ejercicio5
{
    partial class Ejercicio
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.validateTextBox1 = new ValidateTextBox.ValidateTextBox();
            this.SuspendLayout();
            // 
            // validateTextBox1
            // 
            this.validateTextBox1.Location = new System.Drawing.Point(84, 75);
            this.validateTextBox1.Multilinea = false;
            this.validateTextBox1.Name = "validateTextBox1";
            this.validateTextBox1.Size = new System.Drawing.Size(248, 46);
            this.validateTextBox1.TabIndex = 0;
            this.validateTextBox1.Texto = "";
            this.validateTextBox1.Tipo = ValidateTextBox.ValidateTextBox.eTipo.Texto;
            // 
            // Ejercicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.validateTextBox1);
            this.Name = "Ejercicio";
            this.Text = "Ejercicio 5";
            this.ResumeLayout(false);

        }

        #endregion

        private ValidateTextBox.ValidateTextBox validateTextBox1;
    }
}

