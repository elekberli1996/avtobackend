using Core.Entities.Concrete;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);

        IDataResult<User> Login(UserForLoginDto userForLoginDto);

        IResult UserExsist(string email);

        User GetUser(string email);

        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
