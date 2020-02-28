namespace LogFilesSplit
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.btnRun = new System.Windows.Forms.Button();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.txtDateKeyWord = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.barFiles = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "目标源路径：";
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(492, 7);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 10;
            this.btnRun.Text = "运行";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(97, 9);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(350, 21);
            this.txtPath.TabIndex = 11;
            // 
            // txtDateKeyWord
            // 
            this.txtDateKeyWord.Location = new System.Drawing.Point(97, 34);
            this.txtDateKeyWord.Name = "txtDateKeyWord";
            this.txtDateKeyWord.Size = new System.Drawing.Size(350, 21);
            this.txtDateKeyWord.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(14, 37);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(77, 12);
            this.label11.TabIndex = 13;
            this.label11.Text = "日期关键字：";
            // 
            // barFiles
            // 
            this.barFiles.Location = new System.Drawing.Point(16, 61);
            this.barFiles.Name = "barFiles";
            this.barFiles.Size = new System.Drawing.Size(551, 23);
            this.barFiles.TabIndex = 15;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 91);
            this.Controls.Add(this.barFiles);
            this.Controls.Add(this.txtDateKeyWord);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.btnRun);
            this.Controls.Add(this.label1);
            this.Name = "Main";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.TextBox txtDateKeyWord;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ProgressBar barFiles;
    }
}

