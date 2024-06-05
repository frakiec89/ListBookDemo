using ListBookDemo.DB;
using ListBookDemo.DB.Model;
using ListBookDemo.DB.Services;

namespace ListBookDemo.BL
{
    public  class GameLogic
    {
        private User _user;

        ServiceBook _service = new ServiceBook();
        UserService _usService = new UserService();


        public GameLogic(User  user )
        {
            _user = user;
            _service = new ServiceBook();
            _user.PropertyChanged += _user_PropertyChanged;
        }

        private void _user_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            _usService.SaveUser(_user);
        }

        public void BayBook (Book book , Action<string> message)
        {
          
            try
            {
                _service.BookHistoriesAdd(_user.UserId, book.BookId);
                _user.Experience += book.Experience;
                _user.Bay(book.Price);
                _usService.SaveUser(_user);

                message($"Книга куплена: Опыт игрока поменялся:\n текущий  опыт: {_user.Experience}, деньги: {_user.Wallet}");
            }
            catch (Exception ex)
            {
                message(ex.Message);
            }
        }

        public void NetxStatus(StatusType type, Action<string> message)
        {
            StatusUser statusUser = new StatusUser(); 
            switch (type)
            {
                case StatusType.No: message("Функция не доступанв"); return ;
                case StatusType.Junior: statusUser = new Junior(); break;
                case StatusType.Middle: statusUser = new Middle(); break;
            }

            try
            {
                if (statusUser.Available(_user))
                {
                    _user.Status = statusUser;
                    _usService.SaveUser(_user);
                    message($"Пользователь поменял статус на {_user.Status.Name}");
                }
                else
                {
                    message("Вы не соответсвуете выбраной должности");
                }
            }
            catch (Exception ex)
            {
                message(ex.Message);
            }
        }
    }
}
