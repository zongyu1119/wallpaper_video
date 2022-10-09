using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wallpaper_video
{
    public partial class ReNameForm : Form
    {
        public ReNameForm()
        {
            InitializeComponent();
        }
        int index = 1;
        private void ReNameForm_Load(object sender, EventArgs e)
        {
            lv_log.View = View.Details;
          
            lv_log.Columns.Add("信息",600);
            show_log("初始化程序！");
        }

        private void btn_rename_Click(object sender, EventArgs e)
        {
            string path = tb_dir.Text;
            if ((!string.IsNullOrWhiteSpace(path)) && Directory.Exists(path))
            {
                video_dir_rename(path);
               show_log("重命名结束！");               
            }
        }
        delegate bool show_log_del(string log_str);
        bool show_log(string log_str)
        {
            Func<string, bool> log = str1 =>
            {
                lv_log.Items.Add(new ListViewItem(str1));
                return true;
            };
            // 要调用的方法的委托
            show_log_del funDelegate = new show_log_del(log);

            /*========================================================
             * 使用this.BeginInvoke方法
             * （也可以使用this.Invoke()方法）
            ========================================================*/

            // this.BeginInvoke(被调用的方法的委托，要传递的参数[Object数组])
            IAsyncResult aResult = this.BeginInvoke(funDelegate, log_str);

            // 用于等待异步操作完成(-1表示无限期等待)
            aResult.AsyncWaitHandle.WaitOne(100);

            // 使用this.EndInvoke方法获得返回值
            bool ret = (bool)this.EndInvoke(aResult);
            return ret;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="path"></param>
        private  void video_dir_rename(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);

                if (files.Contains(path + "\\project.json"))
                {
                    object_file obj = JsonConvert.DeserializeObject<object_file>(File.ReadAllText(path + "\\project.json"));
                    DirRename(path, obj.type + "-" + obj.title);
                }
                else if (Directory.GetDirectories(path).Length > 0)
                {
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string d in dirs)
                    {
                        try
                        {
                            video_dir_rename(d);
                        }
                        catch { }
                    }
                }
                else if (Directory.GetFiles(path).Length > 0)
                {
                    DirRename(path, Path.GetFileNameWithoutExtension(Directory.GetFiles(path)[0]));
                }
            }
            catch (Exception ex) { show_log(path + "  " + ex.Message); }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="old_name"></param>
        /// <param name="new_name"></param>
         void DirRename(string old_name, string new_name)
        {
            new_name.Replace('\\', '-');
            new_name.Replace('/', '-');
            new_name.Replace('|', '-');
            new_name.Replace('&', '-');
            new_name.Replace('【', '[');
            new_name.Replace('】', ']');
            new_name.Replace(' ', '-');
            string root_name = Directory.GetParent(old_name).FullName;
            if (!Directory.Exists(root_name + "/" + new_name))
            {
                Directory.Move(old_name, root_name + "/" + new_name);
                show_log($"重命名成功，标题：{new_name}");
            }
            else
            {
                show_log("文件夹已经存在  " + new_name);
                //  Console.WriteLine(Path.GetFileName(old_name));
                if (Path.GetFileName(old_name).Length == 10)
                    DirRename(old_name, new_name + Guid.NewGuid().ToString("N").ToUpperInvariant().Substring(20));
            }

        }

        private void btn_select_dir_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择wallpaper视频所在文件夹";
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show(this, "文件夹路径不能为空", "提示");
                    return;
                }
                tb_dir.Text = dialog.SelectedPath;
            }
        }
    }
}
