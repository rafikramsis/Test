using System;
using System.Collections.Generic;
using System.Web;
using System.Drawing;
using System.IO;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;

/*
 * Resizes an image
 **/
public static class ImageResizer
{
    private static ImageCodecInfo GetEncoder(ImageFormat format)
    {
        ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();
        foreach (ImageCodecInfo codec in codecs)
        {
            if (codec.FormatID == format.Guid)
            {
                return codec;
            }
        }
        return null;
    }

    // Saves the image to specific location, save location includes filename
    private static void saveImageToLocation(Image theImage, string saveLocation)
    {
        // Strip the file from the end of the dir
        string saveFolder = Path.GetDirectoryName(saveLocation);
        if (!Directory.Exists(saveFolder))
        {
            Directory.CreateDirectory(saveFolder);
        }

        ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);

        // Create an Encoder object based on the GUID
        // for the Quality parameter category.
        System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;

        // Create an EncoderParameters object.
        // An EncoderParameters object has an array of EncoderParameter
        // objects. In this case, there is only one
        // EncoderParameter object in the array.
        EncoderParameters myEncoderParameters = new EncoderParameters(1);
        EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);
        myEncoderParameters.Param[0] = myEncoderParameter;

        // Save to disk
        theImage.Save(saveLocation, jgpEncoder, myEncoderParameters);
    }

    // Resizes the image and saves it to disk.  Save as property is full path including file extension
    public static void resizeImageAndSave(Image ImageToResize, int newWidth, int maxHeight, bool onlyResizeIfWider, string thumbnailSaveAs)
    {
        Image thumbnail = resizeImage(ImageToResize, newWidth, maxHeight, onlyResizeIfWider);
        thumbnail.Save(thumbnailSaveAs);
    }


    // Overload if filepath is passed in
    public static void resizeImageAndSave(string imageLocation, int newWidth, int maxHeight, bool onlyResizeIfWider, string thumbnailSaveAs)
    {
        Image loadedImage = Image.FromFile(imageLocation);
        Image thumbnail = resizeImage(loadedImage, newWidth, maxHeight, onlyResizeIfWider);

        saveImageToLocation(thumbnail, thumbnailSaveAs);
    }

    // Returns the thumbnail image when an image object is passed in
    public static Image resizeImage(Image ImageToResize, int newWidth, int maxHeight, bool onlyResizeIfWider)
    {
        try
        {
            // Prevent using images internal thumbnail
            ImageToResize.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
            ImageToResize.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);

            // Set new width if in bounds
            if (onlyResizeIfWider)
            {
                if (ImageToResize.Width <= newWidth)
                {
                    newWidth = ImageToResize.Width;
                }
            }

            // Calculate new height
            int newHeight = ImageToResize.Height * newWidth / ImageToResize.Width;
            if (newHeight > maxHeight)
            {
                // Resize with height instead
                newWidth = ImageToResize.Width * maxHeight / ImageToResize.Height;
                newHeight = maxHeight;
            }

            // Create the new 
            if (newWidth > 120 || newHeight > 120)
            {
                Bitmap newImage = new Bitmap(newWidth, newHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                newImage.SetResolution(ImageToResize.HorizontalResolution, ImageToResize.VerticalResolution);
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(ImageToResize, new Rectangle(0, 0, newWidth, newHeight));
                }
                return newImage;
            }
            else
            {
                Image resizedImage = ImageToResize.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero);
                return resizedImage;
            }
        }
        catch
        {
            return null;
        }
        finally
        {
            // Clear handle to original file so that we can overwrite it if necessary
            ImageToResize.Dispose();
        }
    }

    // Overload if file path is passed in instead
    public static Image resizeImage(string imageLocation, int newWidth, int maxHeight, bool onlyResizeIfWider)
    {
        Image loadedImage = Image.FromFile(imageLocation);
        return resizeImage(loadedImage, newWidth, maxHeight, onlyResizeIfWider);
    }
}
