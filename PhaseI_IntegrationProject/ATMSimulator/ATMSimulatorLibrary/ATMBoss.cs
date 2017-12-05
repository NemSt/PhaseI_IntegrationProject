using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulatorLibrary
{
    class ATMBoss
    {
        //private Artistes listeArtistes = Artistes.Instance;
        //private Conservateurs listeConservateurs = Conservateurs.Instance;
        //private Oeuvres listeOeuvres = Oeuvres.Instance;
        private ValidationsUtility validations = new ValidationsUtility();
        //private static double tauxDeCommission = 0.25;
        private static ATMBoss instance;

        //Singleton for my boss class
        public static ATMBoss Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new ATMBoss();
                }
                return instance;
            }
        }
    }
}
