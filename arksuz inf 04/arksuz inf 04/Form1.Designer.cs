namespace arksuz_inf_04
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label_rejestr = new Label();
            label_mail = new Label();
            textBox_mail = new TextBox();
            textbox_haslo = new TextBox();
            textBox_haslo2 = new TextBox();
            label_haslo = new Label();
            label_haslo2 = new Label();
            button_zatwierdz = new Button();
            label_wynik = new Label();
            SuspendLayout();
            // 
            // label_rejestr
            // 
            label_rejestr.BackColor = Color.Green;
            label_rejestr.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            label_rejestr.ForeColor = SystemColors.ControlLightLight;
            label_rejestr.Location = new Point(0, 0);
            label_rejestr.Name = "label_rejestr";
            label_rejestr.Size = new Size(398, 42);
            label_rejestr.TabIndex = 0;
            label_rejestr.Text = "Rejestruj konto";
            // 
            // label_mail
            // 
            label_mail.AutoSize = true;
            label_mail.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_mail.ForeColor = SystemColors.AppWorkspace;
            label_mail.Location = new Point(0, 42);
            label_mail.Name = "label_mail";
            label_mail.Size = new Size(99, 21);
            label_mail.TabIndex = 1;
            label_mail.Text = "Podaj e-mail:";
            // 
            // textBox_mail
            // 
            textBox_mail.BackColor = SystemColors.Control;
            textBox_mail.Location = new Point(0, 66);
            textBox_mail.Name = "textBox_mail";
            textBox_mail.Size = new Size(398, 23);
            textBox_mail.TabIndex = 2;
            textBox_mail.Text = "email";
            // 
            // textbox_haslo
            // 
            textbox_haslo.Location = new Point(0, 146);
            textbox_haslo.Name = "textbox_haslo";
            textbox_haslo.PasswordChar = '*';
            textbox_haslo.Size = new Size(398, 23);
            textbox_haslo.TabIndex = 3;
            // 
            // textBox_haslo2
            // 
            textBox_haslo2.Location = new Point(0, 209);
            textBox_haslo2.Name = "textBox_haslo2";
            textBox_haslo2.PasswordChar = '*';
            textBox_haslo2.Size = new Size(398, 23);
            textBox_haslo2.TabIndex = 4;
            // 
            // label_haslo
            // 
            label_haslo.AutoSize = true;
            label_haslo.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_haslo.ForeColor = SystemColors.AppWorkspace;
            label_haslo.Location = new Point(-1, 103);
            label_haslo.Name = "label_haslo";
            label_haslo.Size = new Size(92, 21);
            label_haslo.TabIndex = 6;
            label_haslo.Text = "Podaj hasło:";
            // 
            // label_haslo2
            // 
            label_haslo2.AutoSize = true;
            label_haslo2.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label_haslo2.ForeColor = SystemColors.AppWorkspace;
            label_haslo2.Location = new Point(-1, 172);
            label_haslo2.Name = "label_haslo2";
            label_haslo2.Size = new Size(110, 21);
            label_haslo2.TabIndex = 7;
            label_haslo2.Text = "Powtórz hasło:";
            // 
            // button_zatwierdz
            // 
            button_zatwierdz.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button_zatwierdz.Location = new Point(145, 331);
            button_zatwierdz.Name = "button_zatwierdz";
            button_zatwierdz.Size = new Size(101, 51);
            button_zatwierdz.TabIndex = 8;
            button_zatwierdz.Text = "ZATWIEDŹ";
            button_zatwierdz.UseVisualStyleBackColor = true;
            button_zatwierdz.Click += button_zatwierdz_Click;
            // 
            // label_wynik
            // 
            label_wynik.AutoSize = true;
            label_wynik.Location = new Point(173, 408);
            label_wynik.Name = "label_wynik";
            label_wynik.Size = new Size(38, 15);
            label_wynik.TabIndex = 9;
            label_wynik.Text = "label1";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(398, 684);
            Controls.Add(label_wynik);
            Controls.Add(button_zatwierdz);
            Controls.Add(label_haslo2);
            Controls.Add(label_haslo);
            Controls.Add(textBox_haslo2);
            Controls.Add(textbox_haslo);
            Controls.Add(textBox_mail);
            Controls.Add(label_mail);
            Controls.Add(label_rejestr);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label_rejestr;
        private Label label_mail;
        private TextBox textBox_mail;
        private TextBox textbox_haslo;
        private TextBox textBox_haslo2;
        private Label label_haslo;
        private Label label_haslo2;
        private Button button_zatwierdz;
        private Label label_wynik;
    }
}