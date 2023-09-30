using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba
{
    internal class Circle //cette class nous aident à garder une traces des velurs X et Y de chqaque cercle que nous dessinons sur l'écran.
    {
        public int X { get; set; }
        public int Y { get; set; }


        public Circle() //ce constructeur définit une valeur pour X et une valeur pour Y.
        {
            X = 0;
            Y = 0;
        }


    }
}
