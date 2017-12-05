using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulatorLibrary
{
    public class Client
    {
        //définition des champs        
        private static ATMBoss boss = ATMBoss.Instance;
        private string name;        
        private string pin;
        
        //accesseurs
        public string Name
        {
            get { return name; }
            private set { name = value; }
        }

        public string PIN
        {
            get { return pin;  }
            private set { name = value; }
        }

        ////constructeur avec paramètres
        //public Client (string Name, string PIN)
        //{
        //    this.name = Name;
        //    this.typeAccount = char.ToUpper(TypeAccount);
        //    this.pin = PIN;
        //    balance = 0;
        //}           
            
     
        //constructeur à partir des données recueillies dans le fichier txt
        public Client (string Name, string PIN)
        {
            this.name = Name;            
            this.pin = PIN;            
        }
        
       
        //polymorphisme
        public override string ToString()
        {            
            if (Name == null)
            {
                throw new ApplicationException("Cette personne n'est pas au système.");
            }
             
            return "Nom : " + Name + "\tNip : " + PIN +"\r\n";
        }
    }
}
