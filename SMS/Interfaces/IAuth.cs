using SMS.Models;
using SMS.ViewModel;

namespace SMS.Interfaces
{
    public interface IAuth
    {
        public ResponseModel UserRegistration(RegistrationVM registrationVM);
        public ResponseModel UserLogin(LoginVM loginVM);
       
    }
}
