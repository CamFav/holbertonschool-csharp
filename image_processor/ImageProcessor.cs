﻿using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

/// <summary>
/// The ImageProcessor class provides methods for processing images.
/// </summary>
public class ImageProcessor
{
    /// <summary>
    /// Inverses the colors of the images specified in the filenames array.
    /// The inverted images are saved with the same name appended with "_inverse" in the same directory.
    /// </summary>
    /// <param name="filenames">An array of filenames of the images to be processed.</param>
    public static void Inverse(string[] filenames)
    {
        // Load, switch colors, save the file.

        // Retrieve the image
        foreach (string filename in filenames)
        {
            // Load the image
            using (Bitmap bitmap = new Bitmap(filename))
            {
                int x, y;

                // Get the image pixels
                for(x = 0; x < bitmap.Width; x++)
                {
                    for(y = 0; y < bitmap.Height; y++)
                    {
                        Color pixelColor = bitmap.GetPixel(x, y);
                        // Switch colors
                        Color newColor = Color.FromArgb(255 - pixelColor.R, 255 - pixelColor.G, 255 - pixelColor.B);
                        // Switch pixels with new pixels values.
                        bitmap.SetPixel(x, y, newColor);
                    }
                }

                // Save the new image
                string newFilename = Path.GetFileNameWithoutExtension(filename) + "_inverse" + Path.GetExtension(filename);
                bitmap.Save(newFilename, ImageFormat.Jpeg);
            }
        }
    }
}