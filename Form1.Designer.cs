namespace PDFWasher
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.chkOverWritten = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkRemoveRestrictions = new System.Windows.Forms.CheckBox();
            this.chkRemoveUriLinks = new System.Windows.Forms.CheckBox();
            this.txtFielPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnWash = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.Location = new System.Drawing.Point(250, 6);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(32, 23);
            this.btnBrowseFile.TabIndex = 0;
            this.btnBrowseFile.Text = "...4";
            this.btnBrowseFile.UseVisualStyleBackColor = true;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // chkOverWritten
            // 
            this.chkOverWritten.AutoSize = true;
            this.chkOverWritten.Enabled = false;
            this.chkOverWritten.Location = new System.Drawing.Point(8, 22);
            this.chkOverWritten.Name = "chkOverWritten";
            this.chkOverWritten.Size = new System.Drawing.Size(84, 16);
            this.chkOverWritten.TabIndex = 1;
            this.chkOverWritten.Text = "覆盖原文件";
            this.chkOverWritten.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkRemoveRestrictions);
            this.groupBox1.Controls.Add(this.chkRemoveUriLinks);
            this.groupBox1.Controls.Add(this.chkOverWritten);
            this.groupBox1.Location = new System.Drawing.Point(7, 35);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(333, 101);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // chkRemoveRestrictions
            // 
            this.chkRemoveRestrictions.AutoSize = true;
            this.chkRemoveRestrictions.Checked = true;
            this.chkRemoveRestrictions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveRestrictions.Location = new System.Drawing.Point(8, 78);
            this.chkRemoveRestrictions.Name = "chkRemoveRestrictions";
            this.chkRemoveRestrictions.Size = new System.Drawing.Size(96, 16);
            this.chkRemoveRestrictions.TabIndex = 2;
            this.chkRemoveRestrictions.Text = "取消编辑限制";
            this.chkRemoveRestrictions.UseVisualStyleBackColor = true;
            // 
            // chkRemoveUriLinks
            // 
            this.chkRemoveUriLinks.AutoSize = true;
            this.chkRemoveUriLinks.Checked = true;
            this.chkRemoveUriLinks.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemoveUriLinks.Location = new System.Drawing.Point(8, 50);
            this.chkRemoveUriLinks.Name = "chkRemoveUriLinks";
            this.chkRemoveUriLinks.Size = new System.Drawing.Size(96, 16);
            this.chkRemoveUriLinks.TabIndex = 1;
            this.chkRemoveUriLinks.Text = "清除网站链接";
            this.chkRemoveUriLinks.UseVisualStyleBackColor = true;
            // 
            // txtFielPath
            // 
            this.txtFielPath.Location = new System.Drawing.Point(57, 7);
            this.txtFielPath.Name = "txtFielPath";
            this.txtFielPath.Size = new System.Drawing.Size(187, 21);
            this.txtFielPath.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "PDF文件";
            // 
            // btnWash
            // 
            this.btnWash.Location = new System.Drawing.Point(286, 6);
            this.btnWash.Name = "btnWash";
            this.btnWash.Size = new System.Drawing.Size(54, 23);
            this.btnWash.TabIndex = 4;
            this.btnWash.Text = "清洗";
            this.btnWash.UseVisualStyleBackColor = true;
            this.btnWash.Click += new System.EventHandler(this.btnWash_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.btnWash;
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 144);
            this.Controls.Add(this.btnWash);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFielPath);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnBrowseFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.CheckBox chkOverWritten;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkRemoveRestrictions;
        private System.Windows.Forms.CheckBox chkRemoveUriLinks;
        private System.Windows.Forms.TextBox txtFielPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnWash;
    }
}

