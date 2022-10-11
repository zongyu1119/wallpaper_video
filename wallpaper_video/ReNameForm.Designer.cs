
namespace wallpaper_video
{
    partial class ReNameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReNameForm));
            this.btn_select_dir = new System.Windows.Forms.Button();
            this.btn_rename = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_dir = new System.Windows.Forms.TextBox();
            this.lv_log = new System.Windows.Forms.ListView();
            this.typeCheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.initBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPriKey = new System.Windows.Forms.TextBox();
            this.tbDestPath = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_select_dir
            // 
            this.btn_select_dir.Location = new System.Drawing.Point(502, 12);
            this.btn_select_dir.Name = "btn_select_dir";
            this.btn_select_dir.Size = new System.Drawing.Size(99, 25);
            this.btn_select_dir.TabIndex = 0;
            this.btn_select_dir.Text = "选择文件夹";
            this.btn_select_dir.UseVisualStyleBackColor = true;
            this.btn_select_dir.Click += new System.EventHandler(this.btn_select_dir_Click);
            // 
            // btn_rename
            // 
            this.btn_rename.Location = new System.Drawing.Point(879, 39);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(99, 27);
            this.btn_rename.TabIndex = 1;
            this.btn_rename.Text = "确定修改";
            this.btn_rename.UseVisualStyleBackColor = true;
            this.btn_rename.Click += new System.EventHandler(this.btn_rename_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "文件夹";
            // 
            // tb_dir
            // 
            this.tb_dir.Location = new System.Drawing.Point(75, 12);
            this.tb_dir.Name = "tb_dir";
            this.tb_dir.Size = new System.Drawing.Size(421, 25);
            this.tb_dir.TabIndex = 3;
            // 
            // lv_log
            // 
            this.lv_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lv_log.GridLines = true;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(208, 92);
            this.lv_log.MultiSelect = false;
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(770, 376);
            this.lv_log.TabIndex = 4;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // typeCheckedListBox
            // 
            this.typeCheckedListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.typeCheckedListBox.FormattingEnabled = true;
            this.typeCheckedListBox.Location = new System.Drawing.Point(12, 92);
            this.typeCheckedListBox.Name = "typeCheckedListBox";
            this.typeCheckedListBox.Size = new System.Drawing.Size(190, 364);
            this.typeCheckedListBox.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 6;
            this.label2.Text = "类型";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(205, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "日志";
            // 
            // initBtn
            // 
            this.initBtn.Location = new System.Drawing.Point(502, 41);
            this.initBtn.Name = "initBtn";
            this.initBtn.Size = new System.Drawing.Size(99, 27);
            this.initBtn.TabIndex = 8;
            this.initBtn.Text = "初始化类型";
            this.initBtn.UseVisualStyleBackColor = true;
            this.initBtn.Click += new System.EventHandler(this.initBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 9;
            this.label4.Text = "关键字";
            // 
            // tbPriKey
            // 
            this.tbPriKey.Location = new System.Drawing.Point(75, 43);
            this.tbPriKey.Name = "tbPriKey";
            this.tbPriKey.Size = new System.Drawing.Size(421, 25);
            this.tbPriKey.TabIndex = 10;
            // 
            // tbDestPath
            // 
            this.tbDestPath.Location = new System.Drawing.Point(672, 9);
            this.tbDestPath.Name = "tbDestPath";
            this.tbDestPath.Size = new System.Drawing.Size(306, 25);
            this.tbDestPath.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(629, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "目标";
            // 
            // ReNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 480);
            this.Controls.Add(this.tbDestPath);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbPriKey);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.initBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.typeCheckedListBox);
            this.Controls.Add(this.lv_log);
            this.Controls.Add(this.tb_dir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_rename);
            this.Controls.Add(this.btn_select_dir);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ReNameForm";
            this.Text = "修改文件夹名称";
            this.Load += new System.EventHandler(this.ReNameForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_select_dir;
        private System.Windows.Forms.Button btn_rename;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_dir;
        private System.Windows.Forms.ListView lv_log;
        private System.Windows.Forms.CheckedListBox typeCheckedListBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button initBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPriKey;
        private System.Windows.Forms.TextBox tbDestPath;
        private System.Windows.Forms.Label label5;
    }
}