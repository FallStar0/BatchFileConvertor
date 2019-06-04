using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Microsoft.VisualBasic;

namespace BatchFileConvertor
{
    /// <summary>
    /// 转换逻辑
    /// </summary>
    public class ConvertLogic
    {
        /// <summary>
        /// 日志输出
        /// </summary>
        public Action<string> Logger { get; set; }
        /// <summary>
        /// 当前计数
        /// </summary>
        public int CurrentCount { get; private set; }

        /// <summary>
        /// 将传入的文件，简体繁体转换
        /// </summary>
        /// <param name="inputDir">输入路径</param>
        /// <param name="outputDir">输出路径</param>
        /// <param name="convertor">转换器</param>
        /// <param name="subfix">拓展名，如 .cs</param>
        /// <param name="isRecursive">是否递归</param>
        public void Begin(string inputDir, string outputDir, Func<string, string> convertor, string subfix, bool isRecursive = true)
        {
            if (string.IsNullOrEmpty(inputDir))
                throw new ArgumentNullException(nameof(inputDir));
            if (string.IsNullOrEmpty(outputDir))
                throw new ArgumentNullException(nameof(outputDir));
            if (convertor == null)
                throw new ArgumentNullException(nameof(convertor));
            if (string.IsNullOrEmpty(subfix))
                throw new ArgumentNullException(nameof(subfix));
            var sp = subfix.Split(',');
            var sub = sp.Where(x => !string.IsNullOrEmpty(x)).Select(y => y.Trim().ToLower()).ToList();
            CurrentCount = 0;

            Convert(inputDir, outputDir, convertor, sub, isRecursive);

        }

        /// <summary>
        /// 将传入的文件，简体繁体转换
        /// </summary>
        /// <param name="inputDir">输入路径</param>
        /// <param name="outputDir">输出路径</param>
        /// <param name="convertor">转换器</param>
        /// <param name="subfixs">拓展名，如 .cs</param>
        /// <param name="isRecursive">是否递归</param>
        private void Convert(string inputDir, string outputDir, Func<string, string> convertor, List<string> subfixs, bool isRecursive = true)
        {
            if (!Directory.Exists(inputDir))
                throw new DirectoryNotFoundException();

            if (!Directory.Exists(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            var files = Directory.GetFiles(inputDir);
            if (files != null && files.Length > 0)
            {
                foreach (var item in files)
                {
                    if (!IsFileEndWith(subfixs, item)) continue;

                    var fi = new FileInfo(item);
                    var fn = fi.Name;

                    var text = File.ReadAllText(item);
                    var txt2 = convertor(text);
                    var textPath = Path.Combine(outputDir, fn);

                    File.WriteAllText(textPath, txt2);
                    if (Logger != null)
                        Logger(textPath);
                    CurrentCount++;
                }
            }

            if (!isRecursive) return;
            var dirs = Directory.GetDirectories(inputDir);
            if (dirs == null || dirs.Length == 0) return;

            foreach (var item in dirs)
            {
                var di = new DirectoryInfo(item);
                var n = di.Name;
                var op = Path.Combine(outputDir, n);
                Convert(item, op, convertor, subfixs, isRecursive);
            }
        }

        /// <summary>
        /// 文件是否以指定结尾
        /// </summary>
        /// <param name="subfix"></param>
        /// <param name="file"></param>
        /// <returns></returns>
        private bool IsFileEndWith(List<string> subfix, string file)
        {
            foreach (var item in subfix)
            {
                if (file.ToLower().EndsWith(item))
                    return true;
            }
            return false;
        }

        /// <summary>
        /// 简体转繁体
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string CHS2CHT(string text)
        {
            return Strings.StrConv(text, VbStrConv.TraditionalChinese, 0);
        }


        /// <summary>
        /// 繁体转简体
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string CHT2CHS(string text)
        {
            return Strings.StrConv(text, VbStrConv.SimplifiedChinese, 0);
        }
    }
}
