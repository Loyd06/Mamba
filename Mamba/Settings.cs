using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mamba
{
    internal class Settings //dans cette class nous avons créer trois variables static dont une qui est nullable.
    {

        public static int Width { get; set; }
        public static int Height { get; set; }

        public static string? directions;

        public Settings() //dans ce constructeur chaque élément que nous avons créer sont de 16 de hauteur * 16 de largeur
        {                 //et la direction par défaut dans laquelle nous voulons que le serpent se déplace sera à gauche.
            Width = 16;
            Height = 16;

            directions = "left";
        }

    }
}
