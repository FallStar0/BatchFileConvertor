# BatchFileConvertor for Chinese Simplified and Traditional

## Introduction
Name : BatchFileConvertor          
Function :     
It is mainly used to convert the file text in the catalog into simplified or traditional Chinese by single or batch recursion.

## Operating environment

.Net Framework 4.5.2(Win10 has included)   

## Other
[VisualBasic Mode] This function use Microsoft.VisualBasic.dll as the convertion component, it can be use in all system. For ASP.NET cs or cshtml files will case error.

[System Mode] This requirement is that the system itself is Chinese. If it meets the requirements, it is recommended to use this.

## UI

![shot](/Assets/Shot1.jpg "shot")


![shot](/Assets/Shot2.jpg "shot")


![shot](/Assets/Shot3.jpg "shot")

## Update Log

### v1.3.2 20190621
>1. A new panel is added to copy and paste text directly for direct conversion.


### v1.3.1 20190611
>1. Fix an error when the output directory does not exist, and now create the directory.


### v1.3 20190605
>1. Add drag a single file to the input box to allow the conversion of a single file.

>2. New automatic identification file encoding format, most of the cases will not be due to the encoding format can not be converted.

>3. With the new file encoding output option, you can now choose the default format (the same as the source file) or UTF8 encoding format.

>4. Add icons.

### v1.2 20190605
>1. Added conversion mode, [VisualBasic Mode] Use Microsoft.VisualBasic.dll ,[System Mode] Use kernel32.dll .

>2. Add drag folder support.

>3. Added ignore directory, case sensitive, ignore not changing file options.

