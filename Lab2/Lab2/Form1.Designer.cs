namespace Lab2
{
    partial class Form1
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
            this.SystemOutputTB = new System.Windows.Forms.TextBox();
            this.UserAnswerTB = new System.Windows.Forms.TextBox();
            this.UserAnswerBTN = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SystemResetBTN = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SystemOutputTB
            // 
            this.SystemOutputTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SystemOutputTB.Location = new System.Drawing.Point(140, 8);
            this.SystemOutputTB.Multiline = true;
            this.SystemOutputTB.Name = "SystemOutputTB";
            this.SystemOutputTB.ReadOnly = true;
            this.SystemOutputTB.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.SystemOutputTB.Size = new System.Drawing.Size(308, 170);
            this.SystemOutputTB.TabIndex = 0;
            this.SystemOutputTB.TextChanged += new System.EventHandler(this.SystemOutputTB_TextChanged);
            // 
            // UserAnswerTB
            // 
            this.UserAnswerTB.Enabled = false;
            this.UserAnswerTB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserAnswerTB.Location = new System.Drawing.Point(106, 216);
            this.UserAnswerTB.Multiline = true;
            this.UserAnswerTB.Name = "UserAnswerTB";
            this.UserAnswerTB.Size = new System.Drawing.Size(287, 32);
            this.UserAnswerTB.TabIndex = 1;
            this.UserAnswerTB.TextChanged += new System.EventHandler(this.UserAnswerTB_TextChanged);
            // 
            // UserAnswerBTN
            // 
            this.UserAnswerBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.UserAnswerBTN.Location = new System.Drawing.Point(16, 298);
            this.UserAnswerBTN.Name = "UserAnswerBTN";
            this.UserAnswerBTN.Size = new System.Drawing.Size(143, 50);
            this.UserAnswerBTN.TabIndex = 2;
            this.UserAnswerBTN.Text = "Ответить";
            this.UserAnswerBTN.UseVisualStyleBackColor = true;
            this.UserAnswerBTN.Click += new System.EventHandler(this.UserAnswerBTN_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 24);
            this.label1.TabIndex = 5;
            this.label1.Text = "Консультант:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(12, 223);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 24);
            this.label2.TabIndex = 6;
            this.label2.Text = "Клиент";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // SystemResetBTN
            // 
            this.SystemResetBTN.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SystemResetBTN.Location = new System.Drawing.Point(182, 299);
            this.SystemResetBTN.Name = "SystemResetBTN";
            this.SystemResetBTN.Size = new System.Drawing.Size(174, 49);
            this.SystemResetBTN.TabIndex = 8;
            this.SystemResetBTN.Text = "Начать заново";
            this.SystemResetBTN.UseVisualStyleBackColor = true;
            this.SystemResetBTN.Click += new System.EventHandler(this.SystemResetBTN_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(475, 371);
            this.Controls.Add(this.SystemResetBTN);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserAnswerBTN);
            this.Controls.Add(this.UserAnswerTB);
            this.Controls.Add(this.SystemOutputTB);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SystemOutputTB;
        private System.Windows.Forms.TextBox UserAnswerTB;
        private System.Windows.Forms.Button UserAnswerBTN;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SystemResetBTN;
    }
}

