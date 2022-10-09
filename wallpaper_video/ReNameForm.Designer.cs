
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
            this.btn_select_dir = new System.Windows.Forms.Button();
            this.btn_rename = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_dir = new System.Windows.Forms.TextBox();
            this.lv_log = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btn_select_dir
            // 
            this.btn_select_dir.Location = new System.Drawing.Point(696, 12);
            this.btn_select_dir.Name = "btn_select_dir";
            this.btn_select_dir.Size = new System.Drawing.Size(75, 23);
            this.btn_select_dir.TabIndex = 0;
            this.btn_select_dir.Text = "选择";
            this.btn_select_dir.UseVisualStyleBackColor = true;
            this.btn_select_dir.Click += new System.EventHandler(this.btn_select_dir_Click);
            // 
            // btn_rename
            // 
            this.btn_rename.Location = new System.Drawing.Point(696, 41);
            this.btn_rename.Name = "btn_rename";
            this.btn_rename.Size = new System.Drawing.Size(75, 23);
            this.btn_rename.TabIndex = 1;
            this.btn_rename.Text = "修改";
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
            this.tb_dir.Size = new System.Drawing.Size(615, 25);
            this.tb_dir.TabIndex = 3;
            // 
            // lv_log
            // 
            this.lv_log.GridLines = true;
            this.lv_log.HideSelection = false;
            this.lv_log.Location = new System.Drawing.Point(13, 72);
            this.lv_log.MultiSelect = false;
            this.lv_log.Name = "lv_log";
            this.lv_log.Size = new System.Drawing.Size(758, 366);
            this.lv_log.TabIndex = 4;
            this.lv_log.UseCompatibleStateImageBehavior = false;
            this.lv_log.View = System.Windows.Forms.View.Details;
            // 
            // ReNameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lv_log);
            this.Controls.Add(this.tb_dir);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_rename);
            this.Controls.Add(this.btn_select_dir);
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
    }
}