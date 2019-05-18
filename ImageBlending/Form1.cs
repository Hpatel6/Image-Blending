using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.Structure;

namespace ImageBlending
{
    public partial class Form1 : Form
    {
        Image<Bgr, byte> imgInput1;
        Image<Bgr, byte> imgInput2;



        public Form1()
        {
            InitializeComponent();
        }

       

        private void openImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Images(*.jpg, *.jpng)|*.jpg;*.png";

            if (ofd.ShowDialog()==DialogResult.OK)
            {
                string[] fileNames = ofd.FileNames;
                if (fileNames.Length<2)
                {

                    MessageBox.Show("Please select at at least two image");
                    return;
                }
                imgInput1 = new Image<Bgr, byte>(fileNames[0]);
                imgInput2 = new Image<Bgr, byte>(fileNames[1]);

                pictureBox1.Image = imgInput1.Bitmap;
                pictureBox2.Image = imgInput2.Bitmap;




            }
        }

        private void blendImagesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double alpha = (double) numericUpDown1.Value;
            pictureBox2.Image = imgInput1.AddWeighted(imgInput2, alpha, (1 - alpha), 0).Bitmap;
        }
    }
}
