using System;
using System.Linq;
using AutoMapper;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.Applications.UserOperations.Commands.CreateUser{
    public class CreateUserCommand{

     public CreateUserModel Model{get;set;}
     private readonly IBookStoreDbContext _dbcontext;
     private readonly IMapper _mapper;
  
        public CreateUserCommand(IBookStoreDbContext dbContext, IMapper mapper)
        {
            _dbcontext = dbContext;
            _mapper = mapper;
        }
        public void Handle(){
        var user=_dbcontext.Users.SingleOrDefault(x=>x.Email==Model.Email);
         if(user is not null) throw new InvalidOperationException("Kullanıcı zaten mevcut");

      user=_mapper.Map<User>(Model);
    
      _dbcontext.Users.Add(user);
      _dbcontext.SaveChanges();
  }
    }
  public class CreateUserModel{
      public string Name{get;set;}
      public string SurName{get;set;}
      public string Email{get;set;}
      public string Password{get;set;}
}

}