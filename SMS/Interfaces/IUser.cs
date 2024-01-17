using SMS.Models;

namespace SMS.Interfaces
{
    public interface IUser
    {
        public ResponseModel GetAllRegisteredUser();
        public ResponseModel GetUserById(int id);
        public ResponseModel DeleteUser(int id);
    }
}
