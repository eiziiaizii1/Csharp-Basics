using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicCodeTrails
{
    internal class PropertiesCodes
    {
        private static string playerName;
        public static string PlayerName {
            get
            {
                if (playerName == null) { return "Unknown"; }
                return playerName;
            }
            set
            {
                if (playerName == "MONKEE") {
                    throw new Exception("CAnnot name player MONKEE");
                }
                playerName = value;
            }
        }

    }
}
