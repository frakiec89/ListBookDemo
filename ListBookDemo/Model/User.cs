
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ListBookDemo.DB.Model
{

    public class User : ObjectBase , INotifyPropertyChanged
    {
        [Key]
        public int UserId { get; set; }


        private double _experience; 
        public double Experience { get =>_experience; set { _experience = value; OnPropertyChanged("Experience"); } }


        private double _wallet;
        public double Wallet {  get =>_wallet; internal set { _wallet = value; OnPropertyChanged("Wallet"); } }


        private StatusUser? _statusUser;
        public StatusUser? Status {  get => _statusUser; set { _statusUser = value; OnPropertyChanged("Status"); } }



        public void Bay (double price)
        {
            if (Wallet - price >= 0)
                Wallet -= price;
            else
                throw new Exception("Не достаточно денег");
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }

    }
}
