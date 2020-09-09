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
    public partial class Form3 : Form
    {
        Histogram h = new Histogram();
        OpenFileDialog ofd = new OpenFileDialog();
        preprocessing p = new preprocessing();

        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            h.LoadOriginalImage(ofd.FileName);
            pictureBox1.ImageLocation = "5a.png";
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox2.ImageLocation = "5b.png";
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            h.drawHistogram5a();
            h.drawHistogram5b();

            pictureBox4.ImageLocation = "5ahistogram.png";
            pictureBox4.SizeMode = PictureBoxSizeMode.StretchImage;

            pictureBox3.ImageLocation = "5bhistogram.png";
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
