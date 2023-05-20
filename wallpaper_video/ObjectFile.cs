using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wallpaper_video
{
    public class ObjectFile
    {
        /// <summary>
        /// 说明
        /// </summary>
        public string description { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string file { get; set; }
        /// <summary>
        /// 预览图
        /// </summary>
        public string preview { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public string type { 
            get { return _type ?? "Undefined"; }
                set{ _type = value; } }
        private string _type;
        /// <summary>
        /// 文件夹路径
        /// </summary>
        public string dirPath { get; set; }
        /// <summary>
        /// 对象key
        /// </summary>
        public string objKey { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        public List<string> tags { get; set; }
        /// <summary>
        /// 文件大小（MB）
        /// </summary>
        public double fileSizeMB { get;set; }
    }
}
