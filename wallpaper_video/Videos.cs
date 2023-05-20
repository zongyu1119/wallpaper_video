using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace wallpaper_video
{
    public partial class Videos : Form
    {
        private List<ObjectFile> objectFiles;
        private string _moveDir;
        private Unit.ShowLogDelegate _showLog;
        private List<Object> orderList = new List<Object>() {
            new { Text= "文件大=>小",index=0 },
            new {Text="文件小=>大",index=1},
            new {Text="时间新=>旧",index=2},
            new {Text="时间旧=>新",index=3},
            new {Text="文件名顺",index=4},
            new {Text="文件名逆",index=5}
        };
        private List<string> dropDownMenuList = new List<string>()
        {
            "AV",
            "B站",
            "抖音",
             "抖音R18",
            "舞蹈",
             "舞蹈R18",
            "露出",
            "PMV",
            "演唱会",
            "自慰"
        };
        public Videos(List<ObjectFile> fileList,string moveDir=null,Unit.ShowLogDelegate showLog=null)
        {
            this.objectFiles = fileList.OrderByDescending(x=>x.fileSizeMB).ToList();
            if(moveDir==null)
                moveToolStripMenuItem.Visible = false;
            _moveDir = moveDir;
            _showLog = showLog;
          
            InitializeComponent();
        }

        private void Videos_Load(object sender, EventArgs e)
        {
            orderComboBox.DisplayMember = "Text";
            orderComboBox.ValueMember = "index";
            orderComboBox.Items.AddRange(orderList.ToArray());
            dropDownMenuList.ForEach(x =>
            {
                var toolStripItem = new ToolStripMenuItem(x);
                toolStripItem.Text = x;
                toolStripItem.Click += moveToToolStripMenuItem_Click;
                moveToToolStripMenuItem.DropDownItems.Add(toolStripItem);
            });
            orderComboBox.SelectedIndex = 0;
            initListView();
        }


        /// <summary>
        /// 初始化视图
        /// </summary>
        private void initListView()
        {
            videoList.Items.Clear();
            imageList1.Images.Clear();
            var itemList = new List<ListViewItem>();
            objectFiles.ForEach(file =>
            {
                var imagePath = Path.Combine(file.dirPath, file.preview);
                if (File.Exists(imagePath))
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read, FileShare.Delete))
                    {
                        imageList1.Images.Add(file.objKey, Image.FromStream(stream));
                    }
                videoList.Items.Add(file.objKey,$"[{Math.Round(file.fileSizeMB,0)}MB]{file.title}", file.objKey);
            });
        }
        private void videoList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        private void moveFile(string moveTo = null)
        {
            var selectItemFirst = videoList.SelectedItems[0];
            var selectedObj = objectFiles.FirstOrDefault(x => x.objKey == selectItemFirst.ImageKey);
            if (deleteCheckBox.Checked)
            {
                DialogResult result = MessageBox.Show($"您确定要执行移动【{selectedObj.title}】吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
            }
            if (videoPlayer.URL == Path.Combine(selectedObj.dirPath, selectedObj.file))
            {
                videoPlayer.Ctlcontrols.stop();
                videoPlayer.URL = string.Empty;
            }
            imageList1.Images.RemoveByKey(selectItemFirst.ImageKey);
            var targetDir=string.IsNullOrWhiteSpace(moveTo)?_moveDir:Path.Combine(_moveDir, moveTo);
            if (Unit.MoveFile(selectedObj, targetDir, _showLog))
            {
                videoList.Items.Remove(selectItemFirst);
                objectFiles.Remove(selectedObj);
            }
        }
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            moveFile();
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectItemFirst = videoList.SelectedItems[0];
            var selectedObj = objectFiles.FirstOrDefault(x => x.objKey == selectItemFirst.ImageKey);
            if (deleteCheckBox.Checked)
            {
                DialogResult result = MessageBox.Show($"您确定要执行删除【{selectedObj.title}】吗？", "确认", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result != DialogResult.Yes)
                    return;
            }
            if (videoPlayer.URL == Path.Combine(selectedObj.dirPath, selectedObj.file))
            {
                videoPlayer.Ctlcontrols.stop();
                videoPlayer.URL = string.Empty;
            }
            imageList1.Images.RemoveByKey(selectItemFirst.ImageKey);
            if (Unit.DeleteFile(selectedObj))
            {
                videoList.Items.Remove(selectItemFirst);
                objectFiles.Remove(selectedObj);
            }
        }
        /// <summary>
        /// 鼠标双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void videoList_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (videoList.SelectedItems.Count > 0)
            {
                videoPlayer.Ctlcontrols.stop();
                var selectItemFirst = videoList.SelectedItems[0];
                var selectedObj = objectFiles.FirstOrDefault(x => x.objKey == selectItemFirst.ImageKey);
                infoLabel.Text = $@"播放信息：【{objectFiles.IndexOf(selectedObj)+1}/{objectFiles.Count}】【{Math.Round(selectedObj.fileSizeMB,2)}MB】【{selectedObj.title}】【{selectedObj.file}】【{selectedObj.description}】【{string.Join("，", selectedObj.tags)}】";
                this.Text = selectedObj.title;
                videoPlayer.URL = Path.Combine(selectedObj.dirPath, selectedObj.file);
                videoPlayer.Ctlcontrols.play();
            }
        }
        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Videos_FormClosing(object sender, FormClosingEventArgs e)
        {
            videoPlayer.Ctlcontrols.stop();
            videoPlayer.close();
            videoPlayer.Dispose();
        }
        /// <summary>
        /// 文件夹打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exporerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var selectItemFirst = videoList.SelectedItems[0];
            var selectedObj = objectFiles[selectItemFirst.Index];
            try
            {
                Process.Start("explorer.exe", $"\"{selectedObj.dirPath}\"");
            }
            catch (Exception ex)
            {
                // 处理异常
            }
        }

        private void orderComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.objectFiles = objectFiles.OrderByDescending(x => x.fileSizeMB).ToList();
            switch((int)orderComboBox.SelectedIndex)
            {
                case 0:
                    this.objectFiles = objectFiles.OrderByDescending(x => x.fileSizeMB).ToList();
                    break;
                case 1:
                    this.objectFiles = objectFiles.OrderBy(x => x.fileSizeMB).ToList();
                    break;
                case 2:
                    this.objectFiles = objectFiles.OrderByDescending(x => Directory.GetCreationTime(x.dirPath)).ToList();
                    break;
                case 3:
                    this.objectFiles = objectFiles.OrderBy(x => Directory.GetCreationTime(x.dirPath)).ToList();
                    break;
                case 4:
                    this.objectFiles = objectFiles.OrderBy(x => x.title).ToList();
                    break;
                case 5:
                    this.objectFiles = objectFiles.OrderByDescending(x => x.title).ToList();
                    break;
            }
            initListView();
        }

        private void videoPlayer_Enter(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// 移动到按钮点击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void moveToToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var text = ((ToolStripMenuItem)sender).Text;
            moveFile(text);
        }
    }
}
