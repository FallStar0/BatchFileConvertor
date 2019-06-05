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
        /// 将传入的文件，简体繁体转换
        /// </summary>
        /// <param name="context">上下文</param>
        public void Begin(ConvertContext context)
        {
            if (context == null)
                throw new ArgumentNullException(nameof(context));

            if (string.IsNullOrEmpty(context.RootInputDirectory))
                throw new ArgumentNullException(nameof(context.RootInputDirectory));
            if (string.IsNullOrEmpty(context.RootOutputDirectory))
                throw new ArgumentNullException(nameof(context.RootOutputDirectory));

            if (context.Convertor == null)
                throw new ArgumentNullException(nameof(context.Convertor));
            if (context.Subfix == null || context.Subfix.Count == 0)
                throw new ArgumentException(nameof(context.Subfix));

            context.CurrentCount = 0;

            Convert(context.RootInputDirectory, context.RootOutputDirectory, context);
        }

        /// <summary>
        /// 将传入的文件，简体繁体转换
        /// </summary>
        /// <param name="inputDir">输入路径</param>
        /// <param name="outputDir">输出路径</param>
        /// <param name="context">上下文</param>
        private void Convert(string inputDir, string outputDir, ConvertContext context)
        {
            if (!Directory.Exists(inputDir))
                throw new DirectoryNotFoundException();

            var files = Directory.GetFiles(inputDir);
            if (files != null && files.Length > 0)
            {
                if (!Directory.Exists(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }
                foreach (var item in files)
                {
                    if (!IsFileEndWith(context.Subfix, item)) continue;

                    var fi = new FileInfo(item);
                    var fn = fi.Name;

                    var text = File.ReadAllText(item);
                    var txt2 = context.Convertor(text);
                    if (context.IsIgnoreUnchangeFile && txt2 == text)
                        continue;
                    var textPath = Path.Combine(outputDir, fn);
                    File.WriteAllText(textPath, txt2, Encoding.UTF8);
                    if (Logger != null)
                        Logger(textPath);
                    context.CurrentCount++;
                }
            }

            if (!context.IsRecursive) return;
            var dirs = Directory.GetDirectories(inputDir);
            if (dirs == null || dirs.Length == 0) return;

            foreach (var item in dirs)
            {
                var di = new DirectoryInfo(item);
                var n = di.Name;
                if (context.IgnoreFolders != null && context.IgnoreFolders.Count > 0)
                {
                    if (context.IgnoreFolders.Contains(n))
                        continue;
                }
                var op = Path.Combine(outputDir, n);
                Convert(item, op, context);
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
        /// 转繁体
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToCHT(string text)
        {
            return Strings.StrConv(text, VbStrConv.TraditionalChinese, 0);
        }


        /// <summary>
        /// 转简体
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public string ToCHS(string text)
        {
            return Strings.StrConv(text, VbStrConv.SimplifiedChinese, 0);
        }


    }

    /// <summary>
    /// 转换模式
    /// </summary>
    public enum ConvertMode : byte
    {
        /// <summary>
        /// 使用VisualBasic类库转换
        /// </summary>
        VB = 0,
        /// <summary>
        /// 使用系统转换
        /// </summary>
        System = 1,
    }
}
