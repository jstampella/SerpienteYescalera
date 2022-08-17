namespace guia4
{
    partial class Form1
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
            this.btnCrear = new System.Windows.Forms.Button();
            this.inpHum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.inpMaq = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.inpHum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpMaq)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCrear
            // 
            this.btnCrear.Location = new System.Drawing.Point(225, 158);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(150, 23);
            this.btnCrear.TabIndex = 5;
            this.btnCrear.Text = "Crear Juego";
            this.btnCrear.UseVisualStyleBackColor = true;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // inpHum
            // 
            this.inpHum.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpHum.Location = new System.Drawing.Point(5, 54);
            this.inpHum.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.inpHum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpHum.Name = "inpHum";
            this.inpHum.Size = new System.Drawing.Size(86, 34);
            this.inpHum.TabIndex = 7;
            this.inpHum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpHum.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp);
            this.inpHum.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseUp);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 8;
            this.label1.Text = "Humanos";
            // 
            // inpMaq
            // 
            this.inpMaq.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.inpMaq.Location = new System.Drawing.Point(107, 54);
            this.inpMaq.Maximum = new decimal(new int[] {
            0,
            0,
            0});
            this.inpMaq.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpMaq.Name = "inpMaq";
            this.inpMaq.Size = new System.Drawing.Size(86, 34);
            this.inpMaq.TabIndex = 9;
            this.inpMaq.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.inpMaq.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numericUpDown1_KeyUp);
            this.inpMaq.MouseUp += new System.Windows.Forms.MouseEventHandler(this.numericUpDown1_MouseUp);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Name = "label3";
            this.label3.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(111, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Maquina";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.inpMaq);
            this.panel1.Controls.Add(this.inpHum);
            this.panel1.Location = new System.Drawing.Point(201, 52);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 13;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCrear);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.inpHum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inpMaq)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.NumericUpDown inpHum;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown inpMaq;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
    }
}

