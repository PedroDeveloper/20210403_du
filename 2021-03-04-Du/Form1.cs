using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Printing;
using System.Threading;




namespace _2021_03_04_Du
{


    public partial class Form1 : Form
    {
        bool aux = true;
        public Form1()
        {

            InitializeComponent();       

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Thread trd = new Thread(new ThreadStart(PrintScreen));
            trd.Start();         

        }

        private void PrintScreen()
        {
            //for teste
            int j = 0;

           while(aux!= false)
            {
                if (j ==10)
                {
                    j=0;
                }

                j++;
                
                    System.Drawing.Bitmap printscreen = new System.Drawing.Bitmap(System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width, System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height);
                    System.Drawing.Graphics graphics = System.Drawing.Graphics.FromImage(printscreen as System.Drawing.Image);
                    graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);

                    byte[] byteArray = new byte[0];
                    using (MemoryStream stream = new MemoryStream())
                    {
                        printscreen.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                        stream.Close();

                        byteArray = stream.ToArray();
                    }
                   
                    //take screenshot every 5seg
                    Thread.Sleep(5000);

                    //open or create file and name as datatime now O.S
                    FileStream fs = new FileStream(@"C:\Users\Pedro\Desktop\foto\" + j + ".png", FileMode.Create);

                    fs.Write(byteArray, 0, byteArray.Length);
                    fs.Close();
                
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            aux = false;
        }
    }


}
