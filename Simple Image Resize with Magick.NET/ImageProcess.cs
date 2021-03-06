﻿using ImageMagick;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Simple_Image_Resize_with_Magick.NET
{
    public class ImageProcess
    {
        private string _inputPath;
        private string _outputPath;
        private int _resizeToHeight;
        private int _resizeToWidth;
        private Stream _inputStream;

        public ImageProcess(Stream inputStream, string outputPath, int resizeHeight, int resizeWidth = 650)
        {
            _inputStream = inputStream;
            _outputPath = outputPath;
            _resizeToHeight = resizeHeight;
            _resizeToWidth = resizeWidth;
        }
        public ImageProcess(string inputPath, string outPutPath, int resizeHeight = 650, int resizeWidth = 600)
        {
            _inputPath = inputPath;
            _outputPath = outPutPath;
            _resizeToHeight = resizeHeight;
            _resizeToWidth = resizeWidth;
        }

        /// <summary>
        /// Compress Image 
        /// </summary>
        /// <returns></returns>
       public Tuple<bool, string> Compress_Save_From_FilePath()
       {
            try
            {
                using (var image = new MagickImage(_inputPath))
                {
                    var geometry = new MagickGeometry
                    {
                        Height = _resizeToHeight,
                        Width = _resizeToWidth,
                        IgnoreAspectRatio = false,
                        Greater = true
                    };
                    image.Resize(geometry);
                    using (var stream = new MemoryStream())
                    {
                        image.Write(stream);
                        byte[] imageByte = stream.ToArray();
                        File.WriteAllBytes(_outputPath, imageByte);
                    }
                }
                return new Tuple<bool, string>(true, $"Image saved to {_outputPath}");
            }
            catch (MagickException ex) // Catch Magick ExceptionErrors
            {
                throw ex;
            }
            catch (Exception ex) // Catch Exception Errors 
            {
                throw ex;
            }
        }


       public Tuple<bool, string> Compress_Save_From_Stream()
        {
            try
            {
                using (var image = new MagickImage(_inputStream))
                {
                    var geometry = new MagickGeometry
                    {
                        Height = _resizeToHeight,
                        Width = _resizeToWidth,
                        IgnoreAspectRatio = false,
                        Greater = true
                    };
                    image.Resize(geometry);
                    using (var stream = new MemoryStream())
                    {
                        image.Write(stream);
                        byte[] imageByte = stream.ToArray();
                        File.WriteAllBytes(_outputPath, imageByte);
                    }
                }
                return new Tuple<bool, string>(true, $"Image saved to {_outputPath}");
            }
            catch (MagickException ex) // Catch Magick ExceptionErrors
            {
                throw ex;
            }
            catch (Exception ex) // Catch Exception Errors 
            {
                throw ex;
            }
        }

    }
}
