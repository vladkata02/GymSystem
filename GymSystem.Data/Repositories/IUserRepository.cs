using GymSystem.Data.Utilities;
using GymSystem.Data.ViewObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymSystem.Data.Repositories
{
    public interface IUserRepository
    {
        bool CheckIfUsernameExist(string username);

        bool CheckIfEmailExist(string email);

        void CreateUser(UserVO user);

        Tokens? Authenticate(UserVO user);
    }
}
