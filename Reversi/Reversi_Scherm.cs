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
        // Speelveld grootte
        const int hor_vak = 6;
        const int vert_vak = 6;

        // Welke beurt
        int turn = 1;

        // Kleur van speelstenen
        SolidBrush kleur1 = new SolidBrush(Color.Red);
        SolidBrush kleur2 = new SolidBrush(Color.Blue);

        // Een array om bij te houden waar welke kleur staat geregistreerd
        int[,] bezetting = new int[hor_vak, vert_vak];

        // Is de originele positie geïnitaliseerd?
        int init = -1;


        public reversi_scherm()
        {
            InitializeComponent();
        }

        int hoogte, breedte, vakbreedte, vakhoogte;



        public void panel_speelveld_Paint(object sender, PaintEventArgs e)
        {
            //// Declareren van maten hele speelveld en de vakken;
            // We nemen de remainder van de deling zodat de grootte van de vakken bij elkaar niet groter zijn dat het hele veld
            hoogte = panel_speelveld.Height - (panel_speelveld.Height % vert_vak);
            breedte = panel_speelveld.Width - (panel_speelveld.Width % hor_vak);
            vakbreedte = breedte / hor_vak;
            vakhoogte = hoogte / vert_vak;

            // Wie er mag beginnen is random 
            Random rnd = new Random();
            int turn = rnd.Next(1, 2);
            Console.WriteLine(turn);

            Pen pen = new Pen(Brushes.Black);

            // Teken de vakken met een for loop
            int t;

            for (t = 0; t <= hor_vak; t++)
                e.Graphics.DrawLine(pen, vakbreedte * t, 0, vakbreedte * t, hoogte);

            for (t = 0; t <= vert_vak; t++)
                e.Graphics.DrawLine(pen, 0, vakhoogte * t, breedte, vakhoogte * t);


            // Initialize the playing field
            if (init == -1)
            {
                int startlocx = hor_vak / 2 - 1;
                int startlocy = vert_vak / 2 - 1;

                bezetting[startlocx, startlocy] = 1;
                bezetting[startlocx + 1, startlocy + 1] = 1;
                bezetting[startlocx, startlocy + 1] = 2;
                bezetting[startlocx + 1, startlocy] = 2;

                // Draw set-up
                e.Graphics.FillEllipse(kleur1, startlocx * vakbreedte, startlocy * vakhoogte, vakbreedte, vakhoogte);
                e.Graphics.FillEllipse(kleur1, (startlocx + 1) * vakbreedte, (startlocy + 1) * vakhoogte, vakbreedte, vakhoogte);
                e.Graphics.FillEllipse(kleur2, startlocx * vakbreedte, (startlocy + 1) * vakhoogte, vakbreedte, vakhoogte);
                e.Graphics.FillEllipse(kleur2, (startlocx + 1) * vakbreedte, startlocy * vakhoogte, vakbreedte, vakhoogte);

                init = 1;
            }

            // Gebruikt de array 'bezetting' om de positities op het bord te tekenen
            else if (init == 1)
            {
                for (int teken_hor = 0; teken_hor < hor_vak; teken_hor++)
                    for (int teken_vert = 0; teken_vert < vert_vak; teken_vert++)
                    {
                        if (bezetting[teken_hor, teken_vert] == 1)
                            e.Graphics.FillEllipse(kleur1, teken_hor * vakbreedte, teken_vert * vakhoogte, vakbreedte, vakhoogte);
                        else if (bezetting[teken_hor, teken_vert] == 2)
                            e.Graphics.FillEllipse(kleur2, teken_hor * vakbreedte, teken_vert * vakhoogte, vakbreedte, vakhoogte);

                    }
            }

        }

        private int horloc;
        private int vertloc;

        // Poging tot het registreren van de klik 
        private void panel_speelveld_Click(object sender, EventArgs e)
        {
           // int horloc = MousePosition.X/hor_vak ;

            // Change turn
            if (turn == 1)
            {
                bezetting[horloc, vertloc] = 1;
                turn = 2;
            }
            else if (turn == 2)
            {
                bezetting[horloc, vertloc] = 2;
                turn = 1;
            }
            else
            {
                Console.WriteLine("error");
                bezetting[horloc, vertloc] = -1;

            }

            panel_speelveld.Invalidate();
        }

        // Kliklocatie WORDT NU NOG NIET GOED DOORGEGEVEN HELAAS
        private void panel_speelveld_MouseUp(object sender, MouseEventArgs e)
        {
            horloc = e.Location.X / hor_vak;
            vertloc = e.Location.Y / vert_vak;
        }
    }
}
