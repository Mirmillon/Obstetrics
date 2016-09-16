namespace Echographie.Classes.Parametres
{
    public class ReferenceCheck : Reference
    {
        private bool? check;

        public ReferenceCheck()
        {
            check = false;
        }

        public bool? Check
        {
            get
            {
                //return (check ?? false);
                return check;
            }
            set  
            {
                check = value;
                OnPropertyChanged("Check");
            }
        }
    }
}
