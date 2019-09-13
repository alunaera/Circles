namespace Circles
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
            this.components = new System.ComponentModel.Container();
            this.paintBox = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.StartButton = new System.Windows.Forms.Button();
            this.addPointButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.circleCountLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).BeginInit();
            this.SuspendLayout();
            // 
            // paintBox
            // 
            this.paintBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.paintBox.Location = new System.Drawing.Point(12, 30);
            this.paintBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.paintBox.Name = "paintBox";
            this.paintBox.Size = new System.Drawing.Size(567, 311);
            this.paintBox.TabIndex = 0;
            this.paintBox.TabStop = false;
            this.paintBox.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 13;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // StartButton
            // 
            this.StartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.StartButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StartButton.Location = new System.Drawing.Point(598, 316);
            this.StartButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(97, 26);
            this.StartButton.TabIndex = 1;
            this.StartButton.Text = "Старт";
            this.toolTip1.SetToolTip(this.StartButton, "Включает или выключает таймер");
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // addPointButton
            // 
            this.addPointButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.addPointButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addPointButton.Location = new System.Drawing.Point(598, 260);
            this.addPointButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addPointButton.Name = "addPointButton";
            this.addPointButton.Size = new System.Drawing.Size(97, 52);
            this.addPointButton.TabIndex = 2;
            this.addPointButton.Text = "Добавить шар";
            this.toolTip1.SetToolTip(this.addPointButton, "Добавляет новый шар на поле");
            this.addPointButton.UseVisualStyleBackColor = true;
            this.addPointButton.Visible = false;
            this.addPointButton.Click += new System.EventHandler(this.AddPointButton_Click);
            // 
            // circleCountLabel
            // 
            this.circleCountLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circleCountLabel.AutoSize = true;
            this.circleCountLabel.Location = new System.Drawing.Point(605, 52);
            this.circleCountLabel.Name = "circleCountLabel";
            this.circleCountLabel.Size = new System.Drawing.Size(54, 17);
            this.circleCountLabel.TabIndex = 6;
            this.circleCountLabel.Text = "Шаров:";
            this.toolTip1.SetToolTip(this.circleCountLabel, "Количество шаров на поле");
            this.circleCountLabel.Visible = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(707, 353);
            this.Controls.Add(this.circleCountLabel);
            this.Controls.Add(this.addPointButton);
            this.Controls.Add(this.StartButton);
            this.Controls.Add(this.paintBox);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Circles";
            ((System.ComponentModel.ISupportInitialize)(this.paintBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox paintBox;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Button addPointButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label circleCountLabel;
    }
}

