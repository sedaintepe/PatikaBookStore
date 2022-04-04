

using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using PatikaBookStoreWebapi.Entities;
using PatikaBookStoreWebapi.TokenOperations.Models;

namespace PatikaBookStoreWebapi.TokenOperations{

   public class TokenHandle{
       public IConfiguration _configuration;
        public TokenHandle(IConfiguration configuration)
        {
            _configuration = configuration;
        }

      

        public Token CreateAccessToken(User user){
            Token tokenModel=new Token();
            SymmetricSecurityKey key=new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));
            SigningCredentials credentials=new SigningCredentials(key,SecurityAlgorithms.HmacSha256);
            tokenModel.Expiration=DateTime.Now.AddMinutes(15);//15 dk lık accesstoken
            JwtSecurityToken securityToken=new JwtSecurityToken(//tokenın modeli bu
              issuer:_configuration["Token:Issuer"],
              audience:_configuration["Token:Audience"],
              expires:tokenModel.Expiration,
              notBefore:DateTime.Now,
              signingCredentials:credentials
            ); 
            
            JwtSecurityTokenHandler tokenHandler=new JwtSecurityTokenHandler();
            //token yaratılıyor
            tokenModel.AccessToken=tokenHandler.WriteToken(securityToken);
            tokenModel.RefreshToken=CreateRefreshToken();
            return tokenModel;

        }
        public string CreateRefreshToken(){
            return Guid.NewGuid().ToString();
        }

    }



}