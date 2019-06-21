# 批量文件转换器

## 介绍
名称：BatchFileConvertor          
功能：    
主要用于将单个或者批量递归将目录里面的文件文本转换为对应的简体中文或者繁体中文。

## 运行环境

.Net Framework 4.5.2(Win10自带了)   

## 其它
【VisualBasic模式】这是使用 Microsoft.VisualBasic.dll 作为转换组件，在非中文系统可以使用，如果是转换ASP.NET 的CS文件的话，会报错，其它类型文件没问题。

【系统模式】这个要求自身系统是中文，如果符合条件，推荐使用这个。

## 界面

![shot](/Assets/Shot1.jpg "shot")


![shot](/Assets/Shot2.jpg "shot")


![shot](/Assets/Shot3.jpg "shot")

## 日志

### v1.3.2 20190621
>1.新增一个面板，用于直接复制粘贴文字进行直接转换。


### v1.3.1 20190611
>1. 修复输出目录不存在的时候报错，现在会创建目录。


### v1.3 20190605
>1. 新增 拖动单个文件到输入框，允许转换单个文件。

>2. 新增 自动识别文件编码格式，绝大部分情况不会因为编码格式导致转换不了。

>3. 新增 文件编码输出选项，现在可以选择默认格式（和源文件一样）或者UTF8 编码格式。

>4. 新增 图标。

### v1.2 20190605
>1. 新增 转换模式，【VisualBasic模式】这是使用 Microsoft.VisualBasic.dll 作为转换组件，【系统模式】使用系统的 kernel32.dll 里面的方法转换。

>2. 新增 拖动文件夹支持。

>3. 新增 忽略目录、大小写敏感、忽略没更改文件 选项。  
