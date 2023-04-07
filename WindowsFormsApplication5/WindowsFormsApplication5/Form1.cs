using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication5
{
    public partial class FoglioCartaMillimetrata : Form
    {
        public FoglioCartaMillimetrata()
        {
            InitializeComponent();
            passo = 50;
        }
        int passo;
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bottone di Prova");
        }

        private void pictBox_Paint(object sender, PaintEventArgs e)
        {
            Graphics myGraphic = e.Graphics;

            //nella riga qui di seguito converto 1 cm in pixel, così avrò un passo da 1 cm nella mia quadrettatura.
            passo = Convert.ToInt32(myGraphic.DpiY / 2.54);

            //di seguito imposto una penna personalizzata per disegnare il tratteggio. La userò per le linee di quadrettatura
            Pen normalPen = new Pen(Color.Moccasin, 1.5f);
            normalPen.DashStyle = DashStyle.Dash;

            //il punto qui di seguito rappresenterà la coordinata dove disegnerò lo zero
            PointF zero = new PointF();

            //disegno linee verticali
            for (int i = 0; i <= pictBox.Width / passo; i++)
            {
                myGraphic.DrawLine(normalPen, new Point(i * passo, 0), new Point(i * passo, pictBox.Height));

                //la condizione if qui sotto l'ho 'inventata' per far si che una delle linee verticali disegnate sia più rimarcata e di colore diverso
                //ho deciso di posizionarlaad 1/5 della larghezza del foglio, per motivi estetici.
                //dentro l'if - come si vede dalle due condizioni logiche che ho imposto CHE DEVONO AVVENIRE IN CONTEMPORANEA (ho usato il connettore &&) - il ciclo for ci entra solo una volta
                //e precisamente quando i è maggiore di (pictureBox1.Width / 5) / passo ma anche minore o uguale alla stessa cifra aumentata di 1. Altrimenti non esegue quella istruzione.
                //vuol dire che: se ad esempio Width =20 e passo =2, allora se i > 2 e i<= 3 disegno la riga. Sto cioè disegnando la riga in coordinata 3!
                if (i > (pictBox.Width / 5) / passo && i <= (1 + (pictBox.Width / 5) / passo))
                {
                    myGraphic.DrawLine(new Pen(Brushes.LightSalmon, 3f), new Point(i * passo, 0), new Point(i * passo, pictBox.Height));

                    //qui sotto inserisco la coordinata x del punto dove disegnerò lo zero
                    zero.X = i * passo + 5;
                }
            }

            //stesso discorso per le linee orizzontali
            for (int i = 0; i <= pictBox.Height / passo; i++)
            {
                myGraphic.DrawLine(normalPen, new Point(0, i * passo), new Point(pictBox.Width, i * passo));
                if (i > (pictBox.Height / 2) / passo && i <= (1 + (pictBox.Height / 2) / passo))
                {
                    myGraphic.DrawLine(new Pen(Brushes.LightSalmon, 3f), new Point(0, i * passo), new Point(pictBox.Width, i * passo));

                    //qui sotto inserisco la coordinata y del punto dove disegnerò lo zero
                    zero.Y = i * passo + 5;
                }
            }
            //la funzione qui di seguito è fantastica! ci permette di disegnare qualunque stringa noi volessimo sul nostro Graphics
            myGraphic.DrawString("0", DefaultFont, Brushes.Red, zero);
        }

        private void pictBox_SizeChanged(object sender, EventArgs e)
        {
            pictBox.Invalidate(); //funzione importantissima!! Scatena il ri-disegno di tutto ciò che esiste dentro la picturebox
        }
    }
}
