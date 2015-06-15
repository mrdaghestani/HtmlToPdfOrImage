# HtmlToPdfOrImage
This is a wrapper for using HtmlToPdfOrImage.com api.

# Html to Pdf or Image

## Installation

Simply install it from NuGet:

```
PM> Install-Package HtmlToPdfOrImage
```

Or just add a reference to `HtmlToPdfOrImage.dll`


## Usage

```
var api = new HtmlToPdfOrImage.Api("99433eae-569c-470d-a763-0a3d0b28ad21", "vmZ2Qryg");
var result = api.Convert("<b>Html to PDF Sample</b>");
File.WriteAllBytes("myfile.pdf", (byte[])result.model);
```

## Options

Customizing PDF is available, just Under Construction

## Demo

[Demo Website](http://htmltopdforimage.com)

## License

Released under the MIT license.

Created by MohammadReza Daghestani, [ADAK SYS Co.](http://adaksys.com/)