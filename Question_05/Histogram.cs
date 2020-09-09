using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenCvSharp;
namespace Question_05
{
    class Histogram
    {
        IplImage srcImage,grayImage, histImage, srcImage2;
        

        public void LoadOriginalImage(string fname)
        {

            srcImage = Cv.LoadImage("BinaryImage.png", LoadMode.Color);
            Cv.SaveImage("BinaryImageOutput.png", srcImage);
           
        }

        ////// PART B///////

        public void drawHistogram5a()
        {
            srcImage2 = Cv.LoadImage("5a.png", LoadMode.Color);

            float[] range = { 0, 255 };
            float[][] ranges = { range };
            int hist_size = 255;
            float min_value, max_value = 0;

            //Convert colour image into gray
            IplImage gray = Cv.CreateImage(srcImage2.Size, BitDepth.U8, 1);
            Cv.CvtColor(srcImage2, gray, ColorConversion.RgbToGray);

            //Create an image to hold the histogram
            IplImage histImage = Cv.CreateImage(srcImage2.Size, BitDepth.U8, 1);

            //Create a histogram to store the information from image
            CvHistogram hist = Cv.CreateHist(new int[] { hist_size }, HistogramFormat.Array, ranges, true);

            //Calculate the histogram and apply to hist
            Cv.CalcHist(gray, hist);

            //Grab the minimum & maximum values from the image
            Cv.GetMinMaxHistValue(hist, out min_value, out max_value);

            //Scale the bin values to fit to image representation
            Cv.Scale(hist.Bins, hist.Bins, ((double)histImage.Height) / max_value, 0);

            //Set background color to white
            histImage.Set(CvColor.White);

            int bin_w = Cv.Round((double)histImage.Width / hist_size);

            //Draw Values on Image - Here we will iterate across the histogram bins and apply the values to the image.
            for (int i = 0; i < hist_size; i++)
            {
                histImage.Rectangle(new CvPoint(i * bin_w, gray.Height), new CvPoint((i + 1) * bin_w, gray.Height - Cv.Round(hist.Bins[i])), CvColor.Black, 1, LineType.Link8, 0);
            }

            Cv.SaveImage("5ahistogram.png", histImage);
        }

        public void drawHistogram5b()
        {
            srcImage2 = Cv.LoadImage("5b.png", LoadMode.Color);

            float[] range = { 0, 255 };
            float[][] ranges = { range };
            int hist_size = 255;
            float min_value, max_value = 0;

            //Convert colour image into gray
            grayImage = Cv.CreateImage(srcImage2.Size, BitDepth.U8, 1);
            Cv.CvtColor(srcImage2, grayImage, ColorConversion.RgbToGray);

            //Create an image to hold the histogram
             histImage = Cv.CreateImage(srcImage2.Size, BitDepth.U8, 1);

            //Create a histogram to store the information from image
            CvHistogram hist = Cv.CreateHist(new int[] { hist_size }, HistogramFormat.Array, ranges, true);

            //Calculate the histogram and apply to hist
            Cv.CalcHist(grayImage, hist);

            //Grab the minimum & maximum values from the image
            Cv.GetMinMaxHistValue(hist, out min_value, out max_value);

            //Scale the bin values to fit to image representation
            Cv.Scale(hist.Bins, hist.Bins, ((double)histImage.Height) / max_value, 0);

            //Set background color to white
            histImage.Set(CvColor.White);

            int bin_w = Cv.Round((double)histImage.Width / hist_size);

            //Draw Values on Image - Here we will iterate across the histogram bins and apply the values to the image.
            for (int i = 0; i < hist_size; i++)
            {
                histImage.Rectangle(new CvPoint(i * bin_w, grayImage.Height), new CvPoint((i + 1) * bin_w, grayImage.Height - Cv.Round(hist.Bins[i])), CvColor.Black, 1, LineType.Link8, 0);
            }

            Cv.SaveImage("5bhistogram.png", histImage);

        }
    }
}