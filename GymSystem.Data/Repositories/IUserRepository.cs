using GymSystem.Data.Utilities;
using GymSystem.Data.ViewObjects;
using GymSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public interface IUserRepository
    {
        User? GetById(int userId);

        bool CheckIfUsernameExist(string username);

        bool CheckIfEmailExist(string email);

        void CreateUser(UserVO user);

        Tokens? Authenticate(UserVO user);
    }
}
