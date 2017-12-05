using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace ATMSimulatorLibrary
{
    class AccountsColl<T> : ICollection<T> where T : Account
    {
        private ArrayList innerArray;
        private static AccountsColl<T> instance;

        //Singleton pour avoir la collection existante s'il y a lieu
        public static AccountsColl<T> Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountsColl<T>();
                }
                return instance;
            }
        }


        //default constructor
        public AccountsColl()
        {
            innerArray = new ArrayList();
        }


        //default accessor for the collection
        public virtual T this[int index]
        {
            get
            {
                return (T)innerArray[index];
            }
            private set
            {
                innerArray[index] = value;
            }
        }

        public bool Contains (T account)
        public Artiste this[string ID]
        {
            get
            {
                foreach (Artiste artist in this)
                {
                    if (artist.IDArtiste == ID)
                    {
                        return artist;
                    }
                }
                return null;
            }
        } //https://www.codeproject.com/articles/21241/implementing-c-generic-collections-using-icollecti
    }
}
