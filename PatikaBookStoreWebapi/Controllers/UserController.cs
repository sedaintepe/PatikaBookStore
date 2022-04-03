using AutoMapper;
<<<<<<< HEAD

using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PatikaBookStoreWebapi.Applications.UserOperations.Commands;
using PatikaBookStoreWebapi.Applications.UserOperations.Commands.CreateUser;
using PatikaBookStoreWebapi.DbOperations;


namespace PatikaBookStoreWebapi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
=======
using AutoMapper.Configuration;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.UpdateBook;

using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks;

using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;


namespace PatikaBookStoreWebapi.Controllers{

       [ApiController]
       [Route("[controller]s")]
>>>>>>> 0e50dfe4e4f3e49d76269674914869a26e65933f
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

<<<<<<< HEAD
        readonly IConfiguration _configuration; //mic. extention con
        public UserController(IBookStoreDbContext context, IMapper mapper, IConfiguration configuration)
        {
            _context = context;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command=new CreateUserCommand(_context,_mapper);
            
            command.Model=newUser;
            CreateUserCommanValidation validation=new CreateUserCommanValidation();
            validation.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }


=======
        readonly IConfiguration _configuration;
        public UserController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
>>>>>>> 0e50dfe4e4f3e49d76269674914869a26e65933f
    }
}