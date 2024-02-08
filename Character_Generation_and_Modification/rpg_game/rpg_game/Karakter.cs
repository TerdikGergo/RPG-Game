using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rpg_game
{
    class Karakter
    {
        //A karakter neve
        public string Character_name { get; set; }
        //Alap támadások ereje
        public int Strength { get; set; }
        //A karakter hpja
        public int Vigor { get; set; }
        //A karakter movementspeedje (Szerintem legyen fixalt ertek, nem latok sok hasznot harc kozben, javaslatokat elfogadok!!!)
        public int Agility { get; set; }
        //A karakter crit eselye %-ban
        public int Crit_chance { get; set; }
        //Ennyi képességet tud hordozni a karakter
        public int Knowledge { get; set; }
        //Milyen tipusu a karakter
        public string Character_type { get; set; }
    }
}
