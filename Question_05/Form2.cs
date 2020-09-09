using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question_05
{
    public partial class Form2 : Form
    {
        Histogram h = new Histogram();
        OpenFileDialog ofd = new OpenFileDialog();
        int A = 255;
        int R = 0;
        int G = 150;
        int B = 0;

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.LoadOriginalImage(ofd.FileName);
            pictureBox1.ImageLocation = "BinaryImage.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //image path
            string img = "BinaryImageOutput.png";

            //read image
            Bitmap bmp = new Bitmap(img);

            //load original image in picturebox1
            pictureBox1.Image = Image.FromFile(img);

            //get image dimension
            int width = bmp.Width;
            int height = bmp.Height;

            //3 bitmap for red green blue image
            Bitmap rbmp = new Bitmap(bmp);
            Bitmap gbmp = new Bitmap(bmp);
            Bitmap bbmp = new Bitmap(bmp);

            //red green blue image
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    //get pixel value
                    Color p = bmp.GetPixel(x, y);

                    //extract ARGB value from p
                    int a = p.A;
                    int r = p.R;
                    int g = p.G;
                    int b = p.B;

                    //set red image pixel
                    rbmp.SetPixel(x, y, Color.FromArgb(a, r, 0, 0));

                    //set green image pixel
                    gbmp.SetPixel(x, y, Color.FromArgb(a, 0, g, 0));

                    //set blue image pixel
                    bbmp.SetPixel(x, y, Color.FromArgb(a, 0, 0, b));

                }
            }

            //load red image in picturebox2
            pictureBox2.Image = rbmp;
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;

            //load green image in picturebox3
            pictureBox3.Image = gbmp;
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;

            //load blue image in picturebox4
            pictureBox4.Image = bbmp;
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            //write (save) red image
            rbmp.Save("Red.png");

            //write(save) green image
            gbmp.Save("Green.png");

            //write (save) blue image
            bbmp.Save("Blue.png");
        }
    }
}
