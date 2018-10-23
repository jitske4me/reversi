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
        const int hor_index = hor_vak - 1;
        const int vert_index = vert_vak - 1;


        // Welke beurt
        int turn;
        // Een array om bij te houden waar welke kleur staat geregistreerd
        int[,] bezetting;
        bool[,] possible_moves;

        // Is de originele positie geïnitaliseerd?
        int init;


        // Kleur van speelstenen
        SolidBrush kleur1 = new SolidBrush(Color.Red);
        SolidBrush kleur2 = new SolidBrush(Color.Blue);


        public reversi_scherm()
        {
            NewGame();

            InitializeComponent();
        }

        private void AssignRandomPlayer()
        {
            // Wie er mag beginnen is random 
            Random rnd = new Random();
            turn = rnd.Next(1, 2);
            Console.WriteLine(turn);
        }

        int hoogte, breedte, vakbreedte, vakhoogte;

        private void NewGame()
        {
            AssignRandomPlayer();

            // Een array om bij te houden waar welke kleur staat geregistreerd
            bezetting = new int[hor_vak, vert_vak];
            possible_moves = new bool[hor_vak, vert_vak];

            // Is de originele positie geïnitaliseerd?
            init = -1;
        }

        public void panel_speelveld_Paint(object sender, PaintEventArgs e)
        {
            //// Declareren van maten hele speelveld en de vakken;
            // We nemen de remainder van de deling zodat de grootte van de vakken bij elkaar niet groter zijn dat het hele veld
            hoogte = panel_speelveld.Height - (panel_speelveld.Height % vert_vak);
            breedte = panel_speelveld.Width - (panel_speelveld.Width % hor_vak);
            vakbreedte = breedte / hor_vak;
            vakhoogte = hoogte / vert_vak;

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
                        // dit willen we alleen als help == 1 natuurlijk 
                        else if (possible_moves[teken_hor, teken_vert] == true)
                            e.Graphics.DrawEllipse(pen, teken_hor * vakbreedte, teken_vert * vakhoogte, vakbreedte / 2, vakhoogte / 2);


                    }
            }
        }


        private int horloc;
        private int vertloc;

        private void nieuw_spel_MouseClick(object sender, MouseEventArgs e)
        {
            NewGame();
            panel_speelveld.Invalidate();
        }

        // Add click location to array
        private void panel_speelveld_MouseClick(object sender, MouseEventArgs e)
        {
            // int horloc = MousePosition.X/hor_vak ;

            horloc = e.Location.X / vakbreedte;
            vertloc = e.Location.Y / vakhoogte  ;

            // Kijk of de zet klopt
            bool valid = legal_move(turn, bezetting, horloc, vertloc);
            bool[,] volgende_zet = help_functie(turn, bezetting);

            // Als de zet klopt, pas dit aan
            if (valid)
            {
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
            }
            
            panel_speelveld.Invalidate();
        }

        // Kijk of de zet mag
        bool legal_move(int turn, int[,] array, int xpos, int ypos)
        {
            bool valid_move = false;
            if (bezetting[xpos, ypos] != 0)
            {
                return valid_move;
            }
            else if(bezetting[xpos,ypos]==0)
            {
                // Check hier of je hor/vert/diag1/diag2 een andere steen insluit
                valid_move = true;
                return valid_move;
            }
            else
            {
                return valid_move;
            }

        }


        bool[,] help_functie(int turn, int[,] array)
        {
            possible_moves = new bool[hor_vak, vert_vak];

            //Array.Clear(possible_moves, 0, possible_moves.Length);
            
            int speler = turn;
            int tegenstander = 0;

            if (turn == 1)
                tegenstander = 2;
            else if (turn == 2)
                tegenstander = 1;

            // Loop alle x en y af
            for (int x = 0; x < hor_index; x++)
                for (int y = 0; y < vert_index; y++)
                {
                    // Check of de een vakje leeg is of bezet
                    if (array[x, y] != 0)
                        possible_moves[x, y] = false;

                    // Als het vakje leeg is, kijk of de zet geldig 
                    else if (bezetting[x, y] == 0)
                    {
                        // Kijk in 8 richtingen

                        // Horizontaal naar rechts ->
                        if (x < hor_index) // zou evt ook als while loop kunnen             
                            if (bezetting[x + 1, y] == tegenstander)
                                for (int t = x + 1; t < hor_vak; t++)
                                {
                                    if (bezetting[t, y] == speler)
                                    {
                                        possible_moves[x, y] = true;
                                        t = hor_vak;
                                    }
                                    else if (bezetting[t, y] == 0)
                                        t = hor_vak;
                                    else if (bezetting[t, y] == tegenstander)
                                        ;
                                }
                        // Horizontaal naar links <-
                        if (x > 0)
                            if (bezetting[x - 1, y] == tegenstander)
                                for (int t = x - 1; t >= 0; t--) // ????? moet dit >= of > zijn ????
                                {
                                    if (bezetting[t, y] == speler)
                                    {
                                        possible_moves[x, y] = true;
                                        t = 0;
                                    }
                                    else if (bezetting[t, y] == 0)
                                        t = 0;
                                    else if (bezetting[t, y] == tegenstander)
                                        ;
                                }

                        // Verticaal omlaag \/
                        if (y < vert_index)
                            if (bezetting[x, y + 1] == tegenstander)
                                for (int t = y + 1; t < vert_index; t++)
                                {
                                    if (bezetting[x, t] == speler)
                                    {
                                        possible_moves[x, y] = true;
                                        t = vert_index;
                                    }                                                          
                                    else if (bezetting[x, t] == 0)
                                        t = vert_index;
                                    else if (bezetting[x, t] == tegenstander)
                                        ;
                                }

                        // Verticaal omhoog ^
                        if (y > 0) 
                            if (bezetting[x, y - 1] == tegenstander)
                                for (int t = y - 1; t >= 0; t--)
                                {
                                    if (bezetting[x, t] == speler)
                                    {
                                        possible_moves[x, y] = true;
                                        t = 0;
                                    }                         
                                    else if (bezetting[x, t] == 0)
                                        t = 0;
                                    else if (bezetting[x, t] == tegenstander)
                                        ;
                                }

                        //// Diagonaal linksboven naar rechtsonder \>
                        //if (x < hor_index && y < vert_index)
                        //    if (bezetting[x + 1, y + 1] == tegenstander)
                        //    {
                        //        int tx = x + 1;
                        //        int ty = y + 1;
                                
                        //        while (tx < hor_index && ty < vert_index)
                        //        {
                
                        //        }
                        //    }



                    }


                }



            return possible_moves;
        }
    }
}
