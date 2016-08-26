using System;
using System.ComponentModel;

namespace Echographie.Acteurs
{
    public class People: INotifyPropertyChanged
    {
        private int clePeople;
        private string firstName;
        private string middleName;
        private string lastName;
        private DateTime dateBirth;
        private bool alive;
        private int gender;
        private DateTime dateDeath;
        private int statut;

        public People() { }

        public People(string firstName, string lastname)
        {
            this.firstName = firstName;
            this.lastName = lastname;
            alive = true;
        }

        public People(string firstName, string lastname, DateTime dateBirth) : this()
        {
            this.dateBirth = dateBirth;
        }

        public string FirstName
        {
            get { return firstName; }
            set
            {

                if (this.firstName != value)
                {
                    this.firstName = value;
                    this.OnPropertyChanged("Name");
                }
            }
        }

        public string MiddleName
        {
            get { return middleName; }
            set
            {

                if (this.middleName != value)
                {
                    this.middleName = value;
                    OnPropertyChanged("MiddleName");
                }
            }
        }

        public string LastName
        {
            get { return lastName; }
            set
            {
                if (this.lastName != value)
                {
                    this.lastName = value;
                    OnPropertyChanged("Lastname");
                }
            }
        }

        public string FullName
        {
            get
            {
                if (!(middleName == string.Empty))
                {
                    return firstName + " " + middleName + " " + lastName;
                }
                else
                {
                    return firstName + " " + lastName;
                }
            }
        }

        public DateTime DateBirth
        {
            get { return dateBirth; }
            set
            {
                if (this.dateBirth != value)
                {
                    this.dateBirth = value;
                    OnPropertyChanged("DateBirth");
                }
            }
        }

        public int Gender
        {
            get { return gender; }
            set
            {
                if (this.gender != value)
                {
                    this.gender = value;
                    OnPropertyChanged("Gender");
                }
            }
        }

        public bool Alive
        {
            get { return alive; }
            set
            {
                if (this.alive != value)
                {
                    this.alive = value;
                    OnPropertyChanged("Alive");
                }
            }
        }

        public DateTime DateDeath
        {
            get { return dateDeath; }
            set
            {
                if (this.dateDeath != value)
                {
                    this.dateDeath = value;
                    OnPropertyChanged("DateDeath");
                }
            }
        }

        public int ClePeople
        {
            get { return clePeople; }
            set { clePeople = value; }
        }

        public int Statut
        {
            get{return statut;}
            set
            {
                if (this.statut != value)
                {
                    this.statut = value;
                    OnPropertyChanged("Statut");
                }
            }
        }

        public int AgeDeces()
        {ss
            // CALCUL D'APRES LIEN CI-DESSOUS
            //http://stackoverflow.com/questions/9/how-do-i-calculate-someones-age-in-c
            int age = dateDeath.Year - dateBirth.Year;
            if (dateBirth > dateDeath.AddYears(-age)) age--;
            return age;
        }

        public int AgeToday()
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateBirth.Year;
            if (dateBirth > today.AddYears(-age)) age--;
            return age;
        }

        public event PropertyChangedEventHandler PropertyChanged;



        public void OnPropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
