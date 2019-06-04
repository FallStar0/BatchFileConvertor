namespace BatchFileConvertor
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.btnToCHS = new System.Windows.Forms.Button();
            this.btnToCHT = new System.Windows.Forms.Button();
            this.btnBrowseIn = new System.Windows.Forms.Button();
            this.txtBrowseIn = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnConfigReset = new System.Windows.Forms.Button();
            this.btnConfigApply = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnBrowseOut = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cbIsRecursive = new System.Windows.Forms.CheckBox();
            this.txtSubfix = new System.Windows.Forms.TextBox();
            this.txtBrowseOut = new System.Windows.Forms.TextBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(561, 522);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtLog);
            this.tabPage1.Controls.Add(this.btnToCHS);
            this.tabPage1.Controls.Add(this.btnToCHT);
            this.tabPage1.Controls.Add(this.btnBrowseIn);
            this.tabPage1.Controls.Add(this.txtBrowseIn);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(553, 488);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "转换";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtLog
            // 
            this.txtLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLog.Location = new System.Drawing.Point(13, 163);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(532, 317);
            this.txtLog.TabIndex = 7;
            // 
            // btnToCHS
            // 
            this.btnToCHS.Location = new System.Drawing.Point(199, 89);
            this.btnToCHS.Name = "btnToCHS";
            this.btnToCHS.Size = new System.Drawing.Size(157, 52);
            this.btnToCHS.TabIndex = 6;
            this.btnToCHS.Text = "转为简体中文";
            this.btnToCHS.UseVisualStyleBackColor = true;
            // 
            // btnToCHT
            // 
            this.btnToCHT.Location = new System.Drawing.Point(10, 89);
            this.btnToCHT.Name = "btnToCHT";
            this.btnToCHT.Size = new System.Drawing.Size(157, 52);
            this.btnToCHT.TabIndex = 6;
            this.btnToCHT.Text = "转为繁体中文";
            this.btnToCHT.UseVisualStyleBackColor = true;
            // 
            // btnBrowseIn
            // 
            this.btnBrowseIn.Location = new System.Drawing.Point(461, 39);
            this.btnBrowseIn.Name = "btnBrowseIn";
            this.btnBrowseIn.Size = new System.Drawing.Size(61, 29);
            this.btnBrowseIn.TabIndex = 4;
            this.btnBrowseIn.Text = "...";
            this.btnBrowseIn.UseVisualStyleBackColor = true;
            // 
            // txtBrowseIn
            // 
            this.txtBrowseIn.Location = new System.Drawing.Point(13, 39);
            this.txtBrowseIn.Name = "txtBrowseIn";
            this.txtBrowseIn.Size = new System.Drawing.Size(441, 29);
            this.txtBrowseIn.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(132, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "输入路径(目录)：";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnConfigReset);
            this.tabPage3.Controls.Add(this.btnConfigApply);
            this.tabPage3.Controls.Add(this.label3);
            this.tabPage3.Controls.Add(this.btnBrowseOut);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.cbIsRecursive);
            this.tabPage3.Controls.Add(this.txtSubfix);
            this.tabPage3.Controls.Add(this.txtBrowseOut);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(553, 488);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "配置";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnConfigReset
            // 
            this.btnConfigReset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigReset.Location = new System.Drawing.Point(305, 424);
            this.btnConfigReset.Name = "btnConfigReset";
            this.btnConfigReset.Size = new System.Drawing.Size(96, 52);
            this.btnConfigReset.TabIndex = 5;
            this.btnConfigReset.Text = "重置";
            this.btnConfigReset.UseVisualStyleBackColor = true;
            // 
            // btnConfigApply
            // 
            this.btnConfigApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfigApply.Location = new System.Drawing.Point(425, 424);
            this.btnConfigApply.Name = "btnConfigApply";
            this.btnConfigApply.Size = new System.Drawing.Size(96, 52);
            this.btnConfigApply.TabIndex = 5;
            this.btnConfigApply.Text = "应用";
            this.btnConfigApply.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(212, 21);
            this.label3.TabIndex = 4;
            this.label3.Text = "支持拓展名(英文逗号分隔)：";
            // 
            // btnBrowseOut
            // 
            this.btnBrowseOut.Location = new System.Drawing.Point(461, 38);
            this.btnBrowseOut.Name = "btnBrowseOut";
            this.btnBrowseOut.Size = new System.Drawing.Size(61, 29);
            this.btnBrowseOut.TabIndex = 2;
            this.btnBrowseOut.Text = "...";
            this.btnBrowseOut.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "输出路径：";
            // 
            // cbIsRecursive
            // 
            this.cbIsRecursive.AutoSize = true;
            this.cbIsRecursive.Checked = global::BatchFileConvertor.Properties.Settings.Default.IsRecursive;
            this.cbIsRecursive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbIsRecursive.Location = new System.Drawing.Point(13, 91);
            this.cbIsRecursive.Name = "cbIsRecursive";
            this.cbIsRecursive.Size = new System.Drawing.Size(141, 25);
            this.cbIsRecursive.TabIndex = 3;
            this.cbIsRecursive.Text = "是否递归子目录";
            this.cbIsRecursive.UseVisualStyleBackColor = true;
            // 
            // txtSubfix
            // 
            this.txtSubfix.Location = new System.Drawing.Point(13, 173);
            this.txtSubfix.Name = "txtSubfix";
            this.txtSubfix.Size = new System.Drawing.Size(441, 29);
            this.txtSubfix.TabIndex = 1;
            this.txtSubfix.Text = global::BatchFileConvertor.Properties.Settings.Default.SupportSubfix;
            // 
            // txtBrowseOut
            // 
            this.txtBrowseOut.Location = new System.Drawing.Point(13, 38);
            this.txtBrowseOut.Name = "txtBrowseOut";
            this.txtBrowseOut.Size = new System.Drawing.Size(441, 29);
            this.txtBrowseOut.TabIndex = 1;
            this.txtBrowseOut.Text = global::BatchFileConvertor.Properties.Settings.Default.OutputDir;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(561, 522);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(500, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "批量文件转换-简繁互转 by Fallstar";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBrowseOut;
        private System.Windows.Forms.TextBox txtBrowseOut;
        private System.Windows.Forms.CheckBox cbIsRecursive;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSubfix;
        private System.Windows.Forms.Button btnConfigApply;
        private System.Windows.Forms.Button btnBrowseIn;
        private System.Windows.Forms.TextBox txtBrowseIn;
        private System.Windows.Forms.Button btnToCHT;
        private System.Windows.Forms.Button btnToCHS;
        private System.Windows.Forms.Button btnConfigReset;
        private System.Windows.Forms.TextBox txtLog;
    }
}

