using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using System.Drawing.Drawing2D;


namespace FInestraProve
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void roundButton1_Click(object sender, EventArgs e)
        {

            DialogResult dialogResult = MessageBox.Show("Hai fatto finire il mondo il: " + DateTime.Now);
        }

        private void button1_MouseCaptureChanged(object sender, EventArgs e)
        {

        }
    }
    //Elemento Custom Bottone Rotondo
    public partial class RoundButton : Button
    {
        public RoundButton()
        {

        }
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath grp = new GraphicsPath();
            grp.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            Region = new Region(grp);
            base.OnPaint(pevent);
        }
    }
}
