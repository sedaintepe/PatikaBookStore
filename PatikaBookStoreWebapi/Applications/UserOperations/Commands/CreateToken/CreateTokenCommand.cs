using System;
using System.Linq;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;
using PatikaBookStoreWebapi.TokenOperations;
using PatikaBookStoreWebapi.TokenOperations.Models;

namespace PatikaBookStoreWebapi.Applications.UserOperations.Commands.CreateToken{
    public class CreateTokenCommand{

     public CreateTokenModel Model{get;set;}
     private readonly IBookStoreDbContext _dbcontext;
     private readonly IMapper _mapper;
     private readonly IConfiguration _configuration;

        public CreateTokenCommand(IBookStoreDbContext dbContext, IMapper mapper, IConfiguration configuration)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
            _configuration = configuration;
        }
        public Token Handle(){
          var user=_dbcontext.Users.FirstOrDefault(x=>x.Email==Model.Email&& x.Password==Model.Password );
          if(user is not null){
              //Token
              TokenHandle handler=new TokenHandle(_configuration);
              Token token=handler.CreateAccessToken(user);

              user.RefreshToken=token.RefreshToken;
              user.RefreshTokenExpireDate=token.Expiration.AddMinutes(5);//15 dk üzerine 5 dk daha ekler.
              _dbcontext.SaveChanges();
              return token;
          }
          else
          throw new InvalidOperationException("Kullanıcı Adı-Şifre Hatalı!");
        }
        public class CreateTokenModel{
            public string Email { get; set; }
            public string Password { get; set; }

        }
  }
}