using ProjetNarratif.Rooms;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProjetNarratif
{
    internal class SharedData
    {
        public static string SelectedArme { get; set; }
        public static string PlayerName { get; set; }



        public static bool Carte { get; set; } = false;
        public static string Village1 { get; } = "Village du commencement";
        public static string Village2 { get; set; } = "???";
        public static string Village3 { get; set; } = "???";





        public static List<Quest> QuetesDecouvert { get; } = new List<Quest>
    {
      
    };
        


        public static bool Fins { get; set; } = false;

        public static int Mana { get; set; } = 0;
        public static bool fins { get; set; } = false;
        public static int AttaqueBoss { get; set; } = 100;
        public static int HPBoss { get; set; } = 300;
        public static int TakePotion { get; set; } = 0;
        public static int TakePotionMax { get; set; } = 0;
        public static int HPBonus { get; set; } = 0;
        public static int Bombe { get; set; } = 0;
        public static int EpeeDamage { set; get; } = 50;
        public static int LongueEpee { get; set; } = 100;
        public static int HealtHero { get; set; } = Math.Max(HealtHero, 300);
        public static int HealGoblin { get; set; } = 130;
        public static int AttaqueGoblin { get; } = 60;
        public static int Gold { get; set; } = 0;
        public static int poisson {  get; set; } = 0;






    }
}


