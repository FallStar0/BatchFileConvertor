using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchFileConvertor
{
    /// <summary>
    /// 上下文
    /// </summary>
    public class ConvertContext
    {
        /// <summary>
        /// 输入路径
        /// </summary>
        public string RootInputDirectory { get; set; }
        /// <summary>
        /// 输出路径
        /// </summary>
        public string RootOutputDirectory { get; set; }
        /// <summary>
        /// 【可选】转换方法
        /// </summary>
        public Func<string, string> Convertor { get; set; }
        /// <summary>
        /// 支持的文件结尾
        /// </summary>
        public List<string> Subfix { get; set; }
        /// <summary>
        /// 忽略未改变的文件
        /// </summary>
        public bool IsIgnoreUnchangeFile { get; set; } = true;
        /// <summary>
        /// 是否递归
        /// </summary>
        public bool IsRecursive { get; set; } = true;

        /// <summary>
        /// 忽略的目录名称
        /// </summary>
        public List<string> IgnoreFolders { get; set; }

        /// <summary>
        /// 当前计数
        /// </summary>
        public int CurrentCount { get; set; }
        /// <summary>
        /// 转换模式
        /// </summary>
        public ConvertMode Mode { get; set; }
    }
}
