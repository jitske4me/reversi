using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace Reversi
{
    class Program
    {
        static void Main(string[] args)
        {
            reversi_scherm scherm = new reversi_scherm();
            Application.Run(scherm);
        }
    }
}
