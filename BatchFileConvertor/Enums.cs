using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchFileConvertor
{
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

    /// <summary>
    /// 编码类型
    /// </summary>
    public enum EncodingType : byte
    {
        /// <summary>
        /// 使用系统默认编码
        /// </summary>
        Default = 0,
        /// <summary>
        /// 使用UTF8编码格式读取
        /// </summary>
        UTF8 = 1,
    }
}
