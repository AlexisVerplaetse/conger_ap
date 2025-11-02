namespace demande_conge
{
    partial class demande_conge
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label4 = new Label();
            dateTimePicker1 = new DateTimePicker();
            label5 = new Label();
            dateTimePicker2 = new DateTimePicker();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F);
            label1.Location = new Point(177, 9);
            label1.Name = "label1";
            label1.Size = new Size(271, 25);
            label1.TabIndex = 0;
            label1.Text = "Espace de demande de congès";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(5, 99);
            label2.Name = "label2";
            label2.Size = new Size(166, 19);
            label2.TabIndex = 1;
            label2.Text = "Nombre de jours restant :";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(177, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(283, 99);
            label3.Name = "label3";
            label3.Size = new Size(44, 19);
            label3.TabIndex = 3;
            label3.Text = "Jours.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10F);
            label4.Location = new Point(5, 190);
            label4.Name = "label4";
            label4.Size = new Size(144, 19);
            label4.TabIndex = 4;
            label4.Text = "Prendre un congès du";
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(155, 190);
            dateTimePicker1.MinDate = new DateTime(2025, 10, 14, 0, 0, 0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 5;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10F);
            label5.Location = new Point(361, 190);
            label5.Name = "label5";
            label5.Size = new Size(26, 19);
            label5.TabIndex = 6;
            label5.Text = "Au";
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(393, 190);
            dateTimePicker2.MinDate = new DateTime(2025, 10, 14, 0, 0, 0, 0);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(477, 273);
            button1.Name = "button1";
            button1.Size = new Size(138, 23);
            button1.TabIndex = 8;
            button1.Text = "Valider ma demande";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // demande_conge
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(641, 308);
            Controls.Add(button1);
            Controls.Add(dateTimePicker2);
            Controls.Add(label5);
            Controls.Add(dateTimePicker1);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "demande_conge";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private Label label4;
        private DateTimePicker dateTimePicker1;
        private Label label5;
        private DateTimePicker dateTimePicker2;
        private Button button1;
    }
}