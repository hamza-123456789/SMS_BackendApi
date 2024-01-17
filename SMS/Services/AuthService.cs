using BusinessLayer.Middleware;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SMS.Interfaces;
using SMS.Models;
using SMS.ViewModel;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SMS.Services
{
    public class AuthService : IAuth
    {
        private readonly AppdbContext _dbContext;
        private readonly IConfiguration _configuration;
        ResponseModel res = new ResponseModel();

        public AuthService(AppdbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        public ResponseModel UserLogin(LoginVM loginVM)
        {
            ResponseModel res = new ResponseModel();
            try
            {
              var user = _dbContext.Registration.FirstOrDefault(x => x.Username == loginVM.Username && x.Password == loginVM.Password);
                if (user == null)
                {
                    res.Status = "403";
                    return res;
                }
                var token = GenerateJwtToken(user.Username);
                res.Token = token;
                res.Status = "200";
             
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return res;
        }

        public ResponseModel UserRegistration(RegistrationVM registrationVM)
        {
            Registration registration = new Registration();
            try
            {
                registration.Id = registrationVM.Id;
                registration.FirstName = registrationVM.FirstName;
                registration.LastName = registrationVM.LastName;
                registration.Email = registrationVM.Email;
                registration.Username = registrationVM.Username;
                registration.Password = registrationVM.Password;
                registration.IsDeleted = registrationVM.IsDeleted;
                if (registrationVM.IsDeleted == null)
                {
                    registration.IsDeleted = true;
                }
                    registration.CreatedDate = DateTime.Now;
                    //registration.ModifiedDate = null;
                
                _dbContext.Registration.Add(registration);
                _dbContext.SaveChanges();
                res.Status = "200";
                return res;
            }
            catch (ApiException ex)
            {
                throw ex;
            }
         
        }

        private string GenerateJwtToken(string username)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                new Claim(ClaimTypes.Name, username)
            }),
                Expires = DateTime.UtcNow.AddHours(1), // Set token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

