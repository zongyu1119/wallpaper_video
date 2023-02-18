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
        private void ReNameForm_Load(object sender, EventArgs e)
        {
            lv_log.View = View.Details;
            lv_log.Columns.Add("信息", 600);
            showLog("初始化程序！");
        }

        private void btn_rename_Click(object sender, EventArgs e)
        {
            showLog("重命名开始！");
            lv_log.Items.Clear();
            string path = tb_dir.Text;
            if ((!string.IsNullOrWhiteSpace(path)) && Directory.Exists(path))
            {
                if ((!string.IsNullOrWhiteSpace(tbDestPath.Text)) && (Path.GetPathRoot(tbDestPath.Text) != Path.GetPathRoot(path)))
                    MessageBox.Show("目标目录和读取目录不在同一个磁盘下，不允许移动！");
                else
                {
                    var fileObjList = DirFind(path);
                    fileObjList.ForEach(x =>
                    {
                        DirRename(x,fileObjList.IndexOf(x));
                    });
                }               
            }
            showLog("重命名结束！");
        }
        delegate bool ShowLogDelegate(string logStr);
        /// <summary>
        /// 显示日志
        /// </summary>
        /// <param name="log_str"></param>
        /// <returns></returns>
        bool showLog(string log_str)
        {
            Func<string, bool> log = str1 =>
            {
                lv_log.Items.Add(new ListViewItem(str1));
                lv_log.EnsureVisible(lv_log.Items.Count - 1);
                return true;
            };
            // 要调用的方法的委托
            ShowLogDelegate funDelegate = new ShowLogDelegate(log);

            /*========================================================
             * 使用this.BeginInvoke方法
             * （也可以使用this.Invoke()方法）
            ========================================================*/

            // this.BeginInvoke(被调用的方法的委托，要传递的参数[Object数组])
            IAsyncResult aResult = this.BeginInvoke(funDelegate, log_str);

            // 用于等待异步操作完成(-1表示无限期等待)
            aResult.AsyncWaitHandle.WaitOne(1);

            // 使用this.EndInvoke方法获得返回值
            bool ret = (bool)this.EndInvoke(aResult);
            return ret;
        }
        /// <summary>
        /// 发现文件夹
        /// </summary>
        /// <param name="path"></param>
        private List<object_file> DirFind(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                var keyWords=tbPriKey.Text.Split(',').ToList();
                var typesChecked = new List<string>();
                var fileObjList=new List<object_file>();
                for (int i=0;i< typeCheckedListBox.CheckedItems.Count; i++)
                {
                    typesChecked.Add(typeCheckedListBox.CheckedItems[i].ToString());
                }
                if (files.Contains(Path.Combine(path, "project.json")) &&long.TryParse(Path.GetFileNameWithoutExtension(path), out long oi))
                {
                    var obj = getFileObj(path);
                    if (((!typesChecked.Any())||(obj.type!=null&&typesChecked.Contains(obj.type.ToUpper())))&&((!keyWords.Any())||keyWords.Any(x=>obj.title.Contains(x))))
                        fileObjList.Add(obj);
                }
                else if (Directory.GetDirectories(path).Length > 0)
                {
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string d in dirs)
                    {
                        try
                        {
                           fileObjList.AddRange(DirFind(d));
                        }
                        catch { }
                    }
                }
                return fileObjList;
            }
            catch (Exception ex) { showLog(path + "  " + ex.Message); return null; }
        }
        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="old_name"></param>
        /// <param name="new_name"></param>
        void DirRename(object_file objFile,int index)
        {
            string newFilePath = Path.Combine(string.IsNullOrWhiteSpace(tbDestPath.Text)?Path.GetDirectoryName(objFile.filePath): tbDestPath.Text, objFile.type);
            string new_name = objFile.type + "-" + objFile.title;
            new_name=new_name.Replace('\\', '-')
                .Replace('/', '-')
                .Replace('|', '-')
                .Replace('&', '-')
                .Replace('【', '[')
                .Replace('】', ']')
                .Replace(' ', '-')
                .Replace('|', '-')
                .Replace('（', '(')
                .Replace('）', ')')
                .Replace('*', 'x')
                .Replace('，', ',')
                .Replace('：', ':')
                .Replace(':', 'x')
                .Replace('>', ']')
                .Replace('<', '[')
                .Replace('\"', '-')
                .Replace('\'', '-');
            try
            {
                if (Directory.Exists(Path.Combine(newFilePath, new_name)))
                {
                    showLog("文件夹已经存在  " + new_name);
                    new_name += Guid.NewGuid().ToString("N").ToUpper().Substring(20);
                }
                if (!Directory.Exists(newFilePath))
                    Directory.CreateDirectory(newFilePath);
                Directory.Move(objFile.filePath, Path.Combine(newFilePath, new_name));
                showLog($"【{index+1}】重命名成功，标题：{objFile.title}");
            }
            catch(Exception ex)
            {
                showLog($"【{index + 1}】重命名失败，标题：{objFile.title},文件夹：{objFile.filePath},原因：{ex.Message}");
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
        /// <summary>
        /// 初始化类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void initBtn_Click(object sender, EventArgs e)
        {
            string path = tb_dir.Text;
            if ((!string.IsNullOrWhiteSpace(path)) && Directory.Exists(path))
            {
                List<string> types = new List<string>();
                typeGet(path, ref types);
                typeCheckedListBox.Items.Clear();
                types.ForEach(x =>
                {
                    typeCheckedListBox.Items.Add(x);
                });               
            }
        }
        /// <summary>
        /// 读取文件对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object_file getFileObj(string path)
        {
            var fileStream = new FileStream(path + "\\project.json", FileMode.Open);
            var bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            var obj = JsonConvert.DeserializeObject<object_file>(Encoding.UTF8.GetString(bytes));
            obj.filePath = path;
            fileStream.Close();
            fileStream.Dispose();
            return obj;
        }
        /// <summary>
        /// 获得类型
        /// </summary>
        /// <param name="path"></param>
        /// <param name="types"></param>
        private void typeGet(string path,ref List<string> types)
        {
            if ((!string.IsNullOrWhiteSpace(path)) && Directory.Exists(path))
            {
                string[] files = Directory.GetFiles(path);

                if (files.Contains(path + "\\project.json"))
                {
                   var obj=getFileObj(path);
                    if (obj.type!=null&&!types.Contains(obj.type.ToUpper()))
                        types.Add(obj.type.ToUpper());
                }
                else if (Directory.GetDirectories(path).Length > 0)
                {
                    string[] dirs = Directory.GetDirectories(path);
                    foreach (string d in dirs)
                    {
                        try
                        {
                            typeGet(d,ref types);
                        }
                        catch { }
                    }
                }
            }
        }
    }
}