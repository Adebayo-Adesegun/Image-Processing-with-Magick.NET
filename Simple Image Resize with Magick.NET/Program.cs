using System;
using System.IO;
using ImageMagick;

namespace Simple_Image_Resize_with_Magick.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            ImageProcess imageProcess = new ImageProcess(@"C:\Users\Daniel\Pictures\IMG_20190212_125706_0.jpg", @"C:\Users\Daniel\Pictures\newConverted.jpg");
            var result = imageProcess.Compress_Save_From_FilePath();
            if(result.Item1)
            {
                Console.WriteLine(result.Item2);
            }
        }
    }
}
