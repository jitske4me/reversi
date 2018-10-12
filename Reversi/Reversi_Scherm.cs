using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Reversi
{
    public partial class reversi_scherm : Form
    {
        // Een paar variabelen
        int hor_vak = 6;
        int vert_vak = 6;


        public reversi_scherm()
        {
            InitializeComponent();
        }

        
        private void panel_speelveld_Paint(object sender, PaintEventArgs e)
        {
            // Declareren van maten hele speelveld en de vakken
            int hoogte, breedte, vakbreedte, vakhoogte;
            // We nemen de remainder van de deling zodat de grootte van de vakken bij elkaar niet groter zijn dat het hele veld
            hoogte = panel_speelveld.Height - (panel_speelveld.Height % vert_vak); 
            breedte = panel_speelveld.Width - (panel_speelveld.Width % hor_vak);
            vakbreedte = breedte / hor_vak;
            vakhoogte = hoogte / vert_vak;

            Pen pen = new Pen(Brushes.Black);

            // Teken de vakken met een for loop
            int t;

            for (t = 0; t <= hor_vak; t++)
                e.Graphics.DrawLine(pen, vakbreedte * t , 0, vakbreedte * t , hoogte);
           
            for (t = 0; t <= vert_vak; t++)
                e.Graphics.DrawLine(pen, 0, vakhoogte * t, breedte, vakhoogte * t);

        }
    }
}
