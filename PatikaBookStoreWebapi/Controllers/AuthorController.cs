using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.DeleteAuthor;
using PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthorDetail;
using PatikaBookStoreWebapi.Applications.AuthorOperations.queries.GetAuthors;
using PatikaBookStoreWebapi.DbOperations;

namespace PatikaBookStoreWebapi.Controllers{
    [ApiController]
    [Route("[controller]s")]
    public class AuthorController:ControllerBase{
        
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public AuthorController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAuthor(){
            GetAuthorsQuery query=new GetAuthorsQuery(_context,_mapper);
            var result=query.Handle();
            return Ok(result);

        }
        [HttpGet("{id}")]
        public IActionResult GetAuthorById(int id){
            AuthorDetailViewModel result;
            GetAuthorDetailQuery query=new GetAuthorDetailQuery(_context,_mapper);
            query.AuthorId=id;
            GetAuthorDetailQueryValidation validations=new GetAuthorDetailQueryValidation();
            validations.ValidateAndThrow(query);
            result=query.Handle();
            return Ok(result);




        }

        [HttpPost]
        public IActionResult AddAuthor([FromBody] CreateAuthor authorModel ){
          CreateAuthorCommand command=new CreateAuthorCommand(_context,_mapper);
          command.Model=authorModel;
          CreateAuthorCommandValidation validations=new CreateAuthorCommandValidation();
          validations.ValidateAndThrow(command);
          command.Handle();
          return Ok();

        }
        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorUpdateViewModel updateAuthor){
              UpdateAuthorCommand command=new UpdateAuthorCommand(_context);
              command.AuthorId=id;
              command.Model=updateAuthor;
              UpdateAuthorCommandValidations validations=new UpdateAuthorCommandValidations();
              validations.ValidateAndThrow(command);
              command.Handle();
              return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id){
            DeleteAuthorCommand command= new DeleteAuthorCommand(_context);
            command.AuthorId=id;
            DeleteAuthorCommandValidation validations=new DeleteAuthorCommandValidation();
            validations.ValidateAndThrow(command);
            command.Handle();
            return Ok();
        }





    }
}