using AutoMapper;

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
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

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


    }
}