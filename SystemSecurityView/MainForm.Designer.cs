namespace SystemSecurityView
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.пополнитьСкладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчетыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.прайсИзделийToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьСкладовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.CreateOrder = new System.Windows.Forms.Button();
            this.TakeOrder = new System.Windows.Forms.Button();
            this.OrderReady = new System.Windows.Forms.Button();
            this.OrderPayed = new System.Windows.Forms.Button();
            this.UpdateList = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пополнитьСкладToolStripMenuItem,
            this.отчетыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(9, 3, 0, 3);
            this.menuStrip1.Size = new System.Drawing.Size(1335, 35);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // пополнитьСкладToolStripMenuItem
            // 
            this.пополнитьСкладToolStripMenuItem.Name = "пополнитьСкладToolStripMenuItem";
            this.пополнитьСкладToolStripMenuItem.Size = new System.Drawing.Size(164, 29);
            this.пополнитьСкладToolStripMenuItem.Text = "Пополнить склад";
            this.пополнитьСкладToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // отчетыToolStripMenuItem
            // 
            this.отчетыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.прайсИзделийToolStripMenuItem,
            this.загруженностьСкладовToolStripMenuItem,
            this.заказыКлиентовToolStripMenuItem});
            this.отчетыToolStripMenuItem.Name = "отчетыToolStripMenuItem";
            this.отчетыToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.отчетыToolStripMenuItem.Text = "Отчеты";
            // 
            // прайсИзделийToolStripMenuItem
            // 
            this.прайсИзделийToolStripMenuItem.Name = "прайсИзделийToolStripMenuItem";
            this.прайсИзделийToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.прайсИзделийToolStripMenuItem.Text = "Прайс изделий";
            this.прайсИзделийToolStripMenuItem.Click += new System.EventHandler(this.прайсИзделийToolStripMenuItem_Click);
            // 
            // загруженностьСкладовToolStripMenuItem
            // 
            this.загруженностьСкладовToolStripMenuItem.Name = "загруженностьСкладовToolStripMenuItem";
            this.загруженностьСкладовToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.загруженностьСкладовToolStripMenuItem.Text = "Загруженность складов";
            this.загруженностьСкладовToolStripMenuItem.Click += new System.EventHandler(this.загруженностьСкладовToolStripMenuItem_Click);
            // 
            // заказыКлиентовToolStripMenuItem
            // 
            this.заказыКлиентовToolStripMenuItem.Name = "заказыКлиентовToolStripMenuItem";
            this.заказыКлиентовToolStripMenuItem.Size = new System.Drawing.Size(290, 30);
            this.заказыКлиентовToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыКлиентовToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 35);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1100, 543);
            this.dataGridView1.TabIndex = 1;
            // 
            // CreateOrder
            // 
            this.CreateOrder.Location = new System.Drawing.Point(1108, 42);
            this.CreateOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CreateOrder.Name = "CreateOrder";
            this.CreateOrder.Size = new System.Drawing.Size(208, 55);
            this.CreateOrder.TabIndex = 2;
            this.CreateOrder.Text = "Создать заказ";
            this.CreateOrder.UseVisualStyleBackColor = true;
            this.CreateOrder.Click += new System.EventHandler(this.CreateOrder_Click);
            // 
            // TakeOrder
            // 
            this.TakeOrder.Location = new System.Drawing.Point(1108, 106);
            this.TakeOrder.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.TakeOrder.Name = "TakeOrder";
            this.TakeOrder.Size = new System.Drawing.Size(208, 55);
            this.TakeOrder.TabIndex = 3;
            this.TakeOrder.Text = "Отдать на выполнение";
            this.TakeOrder.UseVisualStyleBackColor = true;
            this.TakeOrder.Click += new System.EventHandler(this.TakeOrder_Click);
            // 
            // OrderReady
            // 
            this.OrderReady.Location = new System.Drawing.Point(1108, 171);
            this.OrderReady.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OrderReady.Name = "OrderReady";
            this.OrderReady.Size = new System.Drawing.Size(208, 55);
            this.OrderReady.TabIndex = 4;
            this.OrderReady.Text = "Заказ готов";
            this.OrderReady.UseVisualStyleBackColor = true;
            this.OrderReady.Click += new System.EventHandler(this.OrderReady_Click);
            // 
            // OrderPayed
            // 
            this.OrderPayed.Location = new System.Drawing.Point(1108, 235);
            this.OrderPayed.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.OrderPayed.Name = "OrderPayed";
            this.OrderPayed.Size = new System.Drawing.Size(208, 55);
            this.OrderPayed.TabIndex = 5;
            this.OrderPayed.Text = "Заказ оплачен";
            this.OrderPayed.UseVisualStyleBackColor = true;
            this.OrderPayed.Click += new System.EventHandler(this.OrderPayed_Click);
            // 
            // UpdateList
            // 
            this.UpdateList.Location = new System.Drawing.Point(1108, 300);
            this.UpdateList.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.UpdateList.Name = "UpdateList";
            this.UpdateList.Size = new System.Drawing.Size(208, 55);
            this.UpdateList.TabIndex = 6;
            this.UpdateList.Text = "Обновить";
            this.UpdateList.UseVisualStyleBackColor = true;
            this.UpdateList.Click += new System.EventHandler(this.UpdateList_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1335, 578);
            this.Controls.Add(this.UpdateList);
            this.Controls.Add(this.OrderPayed);
            this.Controls.Add(this.OrderReady);
            this.Controls.Add(this.TakeOrder);
            this.Controls.Add(this.CreateOrder);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MainForm";
            this.Text = "Система безопасности";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem пополнитьСкладToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button CreateOrder;
        private System.Windows.Forms.Button TakeOrder;
        private System.Windows.Forms.Button OrderReady;
        private System.Windows.Forms.Button OrderPayed;
        private System.Windows.Forms.Button UpdateList;
        private System.Windows.Forms.ToolStripMenuItem отчетыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьСкладовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыКлиентовToolStripMenuItem;
    }
}

