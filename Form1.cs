using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace win_form
{
    public partial class Form1 : Form
    {
        private Thread t;
        private static Graphics windowG;

        private static Bitmap tempBmP;
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;

            windowG = this.CreateGraphics();

            tempBmP = new Bitmap(450, 450);
            Graphics bmpG = Graphics.FromImage(tempBmP);
            GameFramework.g = bmpG;
            t = new Thread(new ThreadStart(GameMainThread));
            t.Start();
           
        }

        private static void GameMainThread()
        {
            GameFramework.Start();
            int sleepTime = 1000 / 60;
            while (true)
            {
                GameFramework.g.Clear(Color.Black);

                GameFramework.Update();

                windowG.DrawImage(tempBmP, 0, 0);

                Thread.Sleep(sleepTime);
            }

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            t.Abort();
        }


        private void Form1_KeyUp_1(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyUp(e);
        }

        private void Form1_KeyDown_1(object sender, KeyEventArgs e)
        {
            GameObjectManager.KeyDwon(e);
        }
    }
}
