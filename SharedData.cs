using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif
{
    internal class SharedData
    {
        public static string SelectedArme { get; set; }
        public static string PlayerName { get; set; }
        public static bool FinsUnlock { get; set; }



        public static int Mana { get; set; } = 80;
        public static int AttaqueBoss { get; set; } = 100;
        public static int HPBoss { get; set; } = 300;
        public static int TakePotion { get; set; } = 0;
        public static int TakePotionMax { get; set; } = 0;
        public static int HPBonus { get; set; } = 0;
        public static int Bombe { get; set; }=0;
        public static int EpeeDamage { set;  get; } = 50;
        public static int LongueEpee { get; set; } = 100;
        public static int HealtHero { get; set; } = Math.Max(HealtHero, 300);
        public static int HealGoblin { get; set; } = 130;
        public static int AttaqueGoblin { get; } = 60;
        public static int Gold { get; set; } = 0;
    }
}
