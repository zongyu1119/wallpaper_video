using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace wallpaper_video
{
    public class Unit
    {
        public delegate bool ShowLogDelegate(string logStr);
        /// <summary>
        /// 移动文件
        /// </summary>
        /// <param name="objFile"></param>
        /// <param name="targetPath"></param>
        /// <param name="showLog"></param>
        /// <returns></returns>
        public static bool MoveFile(ObjectFile objFile,string targetPath,ShowLogDelegate showLog)
        {
            string newFilePath = Path.Combine(string.IsNullOrWhiteSpace(targetPath) ? Path.GetDirectoryName(objFile.dirPath) : targetPath, objFile.type);
            string new_name = objFile.type + "-" + objFile.title;
            new_name = new_name.Replace('\\', '-')
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
                Directory.Move(objFile.dirPath, Path.Combine(newFilePath, new_name));
                //Copy(objFile.dirPath, Path.Combine(newFilePath, new_name));
                //DeleteFile(objFile);
                showLog($"重命名成功，标题：{objFile.title}");
                return true;
            }
            catch (Exception ex)
            {
                showLog($"重命名失败，标题：{objFile.title},文件夹：{objFile.dirPath},原因：{ex.Message}");
                return false;
            }
        }
        /// <summary>
        /// 复制文件夹
        /// </summary>
        /// <param name="sourceFolderPath"></param>
        /// <param name="destinationFolderPath"></param>
        private static void Copy(string sourceFolderPath,string destinationFolderPath)
        {
            // 复制文件夹及其子文件夹中的所有文件
            if (!Directory.Exists(destinationFolderPath))
                Directory.CreateDirectory(destinationFolderPath);
            foreach (var dirPath in Directory.GetDirectories(sourceFolderPath, "*", SearchOption.AllDirectories))
                Directory.CreateDirectory(dirPath.Replace(sourceFolderPath, destinationFolderPath));
            foreach (var filePath in Directory.GetFiles(sourceFolderPath, "*.*", SearchOption.AllDirectories))
                File.Copy(filePath, filePath.Replace(sourceFolderPath, destinationFolderPath), true);
        }
        /// <summary>
        /// 删除文件
        /// </summary>
        /// <param name="objectFile"></param>
        /// <returns></returns>
        public static bool DeleteFile(ObjectFile objectFile)
        {
            if(Directory.Exists(objectFile.dirPath))
            {
                try
                {
                    Directory.Delete(objectFile.dirPath, true);
                }
                catch (IOException ex)
                {
                    // 从异常消息中提取错误代码
                    int errorCode = Marshal.GetHRForException(ex) & ((1 << 16) - 1);

                    // 如果错误代码指示该文件夹正在被占用，则尝试强制删除
                    if (errorCode == 32 || errorCode == 33)
                    {
                        RemoveDirectory(objectFile.dirPath);
                    }
                    else
                    {
                        // 处理其他 IOException 异常
                        throw ex;
                    }
                }
                return true;
            }
            return false;
        }
        /// <summary>
        /// 强制删除文件夹及其所有内容
        /// </summary>
        /// <param name="path"></param>
        private static void RemoveDirectory(string path)
        {
            try
            {
                var files = Directory.GetFiles(path);
                var dirs = Directory.GetDirectories(path);

                foreach (var file in files)
                {
                    File.SetAttributes(file, FileAttributes.Normal);
                    File.Delete(file);
                }

                foreach (var dir in dirs)
                {
                    RemoveDirectory(dir);
                }

                Directory.Delete(path, false);
            }
            catch (Exception ex)
            {
                // 处理任何可能发生的异常
            }
        }
    }
}
