using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMSimulatorLibrary
{
    public class Account : IEquatable<Account>, IComparable<Account>
    {
        //définition des champs        
        private static ATMBoss boss = ATMBoss.Instance;
        private string idAccount;
        private char typeAccount;
        private string pin;
        private double balance;

        //accesseurs
        public string IdAccount
        {
          get { return idAccount; }
          private set { idAccount = value; }
        }
        
        public char TypeAccount
        {
          get { return typeAccount; }
          private set { typeAccount = value; }
        }

        public string PIN
        {
            get { return pin; }
            private set { pin = value; }
        }

        public double Balance
        {
          get { return balance; }
          set { balance = value; }
        }

        
        
        ////constructeur avec paramètres
        //public Account (string IdAccount, char TypeAccount, string PIN)
        //{
        //    this.idAccount = IdAccount;
        //    this.typeAccount = char.ToUpper(TypeAccount);
        //    this.pin = PIN;
        //    balance = 0;
        //}           
            
     
        //constructeur à partir des données recueillies dans le fichier txt
        public Account (string IdAccount, string TypeAccount, string PIN, string Balance)
        {
            this.idAccount = IdAccount;
            this.typeAccount = char.ToUpper(Convert.ToChar(TypeAccount));
            this.pin = PIN;
            this.balance = double.Parse(Balance);
        }
        
       
        //polymorphisme
        public override string ToString()
        {            
            if (IdAccount == null)
            {
                throw new ApplicationException("Ce compte n'existe pas.");
            }
             
            return "Compte : " + IdAccount + "(" + TypeAccount + ")" + "\r\n" + "NIP : " +  PIN + "\t\t" + Balance.ToString("0.00") + "\r\n";
        }

        bool IEquatable<Account>.Equals(Account other)
        {
            throw new NotImplementedException();
        }

        int IComparable<Account>.CompareTo(Account other)
        {
            throw new NotImplementedException();
        }
    }
}
