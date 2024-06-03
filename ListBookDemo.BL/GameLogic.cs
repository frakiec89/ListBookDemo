using ListBookDemo.DB;
using ListBookDemo.DB.Model;
using ListBookDemo.DB.Services;

namespace ListBookDemo.BL
{
    public  class GameLogic
    {
        private User _user;
        public GameLogic(User  user )
        {
            _user = user;
        }


        public void BayBook (Book book , Action<string> message)
        {
            var   _service = new ServiceBook();
            var _usService = new UserService();
            try
            {
                _service.BookHistoriesAdd(_user.UserId, book.BookId);
                _user.Experience += book.Experience;
                _usService.SaveUser(_user);

                message($"Книга куплена: Опыт игрока поменялся:\n текущий  опыт {_user.Experience}");
            }
            catch (Exception ex)
            {
                message(ex.Message);
            }
        }

    }
}
