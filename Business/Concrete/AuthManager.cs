using Business.Abstract;
using Business.Constant;
using Core.Entities.Concrete;
using Core.Utilities.Hashing;
using Core.Utilities.Result;
using Core.Utilities.Security.Jwt;
using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userSerive;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userSerive, ITokenHelper tokenHelper)
        {
            _userSerive = userSerive;
            _tokenHelper = tokenHelper;
        }
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userSerive.GetClaims(user);

            var accesToken=_tokenHelper.CreateToken(user,claims);
            return new SuccessDataResult<AccessToken>(accesToken, Messages.AccessTokenCreated);
        }

        public User GetUser(string email)
        {
            var user = _userSerive.GetUserByEmail(email);
            return user;
        }

        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = _userSerive.GetUserByEmail(userForLoginDto.Email);
            if (user == null) 
                {
                return new ErrorDataResult<User>(user,Messages.NotExsist);
                }
            if (!HasingHelper.VerifyPassword(userForLoginDto.Password, user.PasswordHash, user.PasswordSalt))
            {
                return new ErrorDataResult<User>(user,Messages.Passwordwrong);
            }
            return new SuccessDataResult<User>(user,Messages.SuccesgullyLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash,passwordSalt;
             
            HasingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            User newUser = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.Name,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                PhoneNumber=userForRegisterDto.PhoneNumber
            };
            _userSerive.Add(newUser);
            return new SuccessDataResult<User>(newUser, Messages.UserRegistred);
            
        }

        public IResult UserExsist(string email)
        {
            var user = _userSerive.GetUserByEmail(email);
            if (user==null)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.UserExsist);
        }
    }
}
