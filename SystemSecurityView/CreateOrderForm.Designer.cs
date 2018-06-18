namespace SystemSecurityView
{
    partial class CreateOrderForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CustomerCB = new System.Windows.Forms.ComboBox();
            this.SystemmCB = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CountTB = new System.Windows.Forms.TextBox();
            this.SumTB = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 25);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Клиент";
            // 
            // CustomerCB
            // 
            this.CustomerCB.FormattingEnabled = true;
            this.CustomerCB.Location = new System.Drawing.Point(129, 20);
            this.CustomerCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CustomerCB.Name = "CustomerCB";
            this.CustomerCB.Size = new System.Drawing.Size(326, 28);
            this.CustomerCB.TabIndex = 1;
            // 
            // SystemmCB
            // 
            this.SystemmCB.FormattingEnabled = true;
            this.SystemmCB.Location = new System.Drawing.Point(129, 62);
            this.SystemmCB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SystemmCB.Name = "SystemmCB";
            this.SystemmCB.Size = new System.Drawing.Size(326, 28);
            this.SystemmCB.TabIndex = 3;
            this.SystemmCB.SelectedIndexChanged += new System.EventHandler(this.SystemmCB_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 66);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Система";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 108);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Количество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 149);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Сумма";
            // 
            // CountTB
            // 
            this.CountTB.Location = new System.Drawing.Point(129, 103);
            this.CountTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CountTB.Name = "CountTB";
            this.CountTB.Size = new System.Drawing.Size(326, 26);
            this.CountTB.TabIndex = 7;
            this.CountTB.TextChanged += new System.EventHandler(this.CountTB_TextChanged);
            // 
            // SumTB
            // 
            this.SumTB.Enabled = false;
            this.SumTB.Location = new System.Drawing.Point(129, 145);
            this.SumTB.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SumTB.Name = "SumTB";
            this.SumTB.Size = new System.Drawing.Size(326, 26);
            this.SumTB.TabIndex = 8;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(308, 185);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(150, 35);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(129, 185);
            this.Save.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(150, 35);
            this.Save.TabIndex = 9;
            this.Save.Text = "Сохранить";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // CreateOrderForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 237);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.SumTB);
            this.Controls.Add(this.CountTB);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SystemmCB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.CustomerCB);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CreateOrderForm";
            this.Text = "CreateOrderForm";
            this.Load += new System.EventHandler(this.CreateOrderForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CustomerCB;
        private System.Windows.Forms.ComboBox SystemmCB;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CountTB;
        private System.Windows.Forms.TextBox SumTB;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button Save;
    }
}