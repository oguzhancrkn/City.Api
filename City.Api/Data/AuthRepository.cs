using City.Api.Core;

namespace City.Api.Data
{
    public class AuthRepository : IAuthRespository
    {
        private readonly DataContext _context;

        public AuthRepository(DataContext context)
        {
            _context = context;
        }
        public Task<ServiceResponse<string>> Login(string username, string password)
        {
            throw new NotImplementedException();
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

        public Task<bool> UserExists(string username)
        {
            throw new NotImplementedException();
        }

        private void CreatePasswordHash (string password , out byte[] passwordHash , out byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
