using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetNarratif
{
    internal class Quest
    {
        public string Nom { get; }
        public string Description { get; }
        public bool Debloquer { get; set; }

        public Quest(string nom, string description)
        {
            Nom = nom;
            Description = description;
            Debloquer = false;
        }
    }
}

