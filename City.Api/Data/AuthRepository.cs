using Azure;
using City.Api.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace City.Api.Data
{
    public class AuthRepository : IAuthRespository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }

        //Login işleminde alınacak hatala ve mesajları metodu
        public  async Task<ServiceResponse<string>> Login(string username, string password)
        {
           var response = new ServiceResponse<string>();
            var user = await _context.userEntities.FirstOrDefaultAsync(x=>x.Username.ToLower().Equals(username.ToLower()));

            if (user == null)
            {
                response.Success = false;
                response.Message = "Kullanıcı Bulunamadı";

            }
            else if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
            {
                response.Success=false;
                response.Message = "Hatalı Şifre";
            }
            else
            {
                response.Data =user.Id.ToString();
            }
            return response;
            
        }

        public async Task<ServiceResponse<int>> Register(UserEntity user, string password)
        {

            ServiceResponse<int> response = new ServiceResponse<int>();

            if (await UserExists(user.Username))
            {
                response.Success = true;
                response.Message = "Kullanıcı Mevcut";
                return response;
            }


            CreatePasswordHash(password,out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            //_context ile datayı cekiyoruz , await ile datayı yazıyoruz 
            _context.userEntities.Add(user);
            await _context.SaveChangesAsync();
            //ServiceResponse<int> response = new ServiceResponse<int>();
            response.Data = user.Id;
            return response;
        }

        public async Task<bool> UserExists(string username)
        {
           if(await _context.userEntities.AnyAsync(x=>x.Username.ToLower() == username.ToLower()))
           {
                
                return true;
               
           }
           return false;
        }

        //passsword oluşturma 
        private void CreatePasswordHash(string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computeHash.SequenceEqual(passwordHash);
            }
        }

    }
}
