using SMS.Interfaces;
using SMS.Models;

namespace SMS.Services
{
    public class User:IUser
    {
        private readonly AppdbContext _dbContext;
        private readonly IConfiguration _configuration;
        ResponseModel res = new ResponseModel();
        public User(AppdbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        public ResponseModel DeleteUser(int id)
        {
            var result=_dbContext.Registration.Where(x=>x.Id==id).FirstOrDefault();
            if(result != null)
            {
                _dbContext.Registration.Remove(result);
                _dbContext.SaveChanges();
                res.Response = "Successfully Deleted";
                res.Status = "200";
            }
            else
            {
                res.Response = "Not Found";
                res.Status = "500";
            }
            return res;
        }

        public ResponseModel GetAllRegisteredUser()
        {
            var result = _dbContext.Registration.ToList();

            if (result != null)
            {
                res.Response = result;
            }
            else
            {
                res.Status = "500";
            }
            return res;
        }

        public ResponseModel GetUserById(int id)
        {
            var resutl=_dbContext.Registration.Where(x=>x.Id == id).FirstOrDefault();
            if(resutl != null)
            {
                res.Response = resutl;
                res.Status = "200";
            }
            else
            {
                res.Status = "500";
                res.Response = "Not Found";
            }
            return res;
        }
    }
}
