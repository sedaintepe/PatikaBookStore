using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.DeleteBook;
using PatikaBookStoreWebapi.Applications.BookOperations.commands.UpdateBook;

using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBookDetail1;
using PatikaBookStoreWebapi.Applications.BookOperations.queries.GetBooks;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.CreateGenre;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.DeleteGenre;
using PatikaBookStoreWebapi.Applications.GenreOperations.commands.UpdateGenre;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenreDetail;
using PatikaBookStoreWebapi.Applications.GenreOperations.queries.GetGenres;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using static PatikaBookStoreWebapi.Applications.BookOperations.commands.CreateBook1.CreateBookCommand;


namespace PatikaBookStoreWebapi.Controllers
{

    [ApiController]
    [Route("[controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public GenreController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpGet]
        public ActionResult GetGenres()
        {
            GetGenresQuery query=new GetGenresQuery(_context,_mapper);
            var obj=query.Handle();
            return Ok(obj);
        }
        [HttpGet("{id}")]
        public ActionResult GetGenreDetail(int id)
        {
            GetGenreDetailQuery query=new GetGenreDetailQuery(_context,_mapper);
            query.GenreId=id;
            GetGenreDetailQueryValidator validations=new GetGenreDetailQueryValidator();
            validations.ValidateAndThrow(query);//hata alırsan goster

            var obj=query.Handle();
            return Ok(obj);
        }
        [HttpPost]

        public IActionResult AddGenre([FromBody] CreateGenreModel newGenre)
        {
            CreateGenreCommands command=new CreateGenreCommands(_context);
            command._model=newGenre;

            CreateGenreCommandsValidator validations=new CreateGenreCommandsValidator();
            validations.ValidateAndThrow(command);

            command.Handle();
            return Ok();
        }

        [HttpPut("{id}")]

        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel updateGenre)
        {
            UpdateGenreCommands commands=new UpdateGenreCommands(_context);
            commands.GenreId=id;
            commands.Model=updateGenre;

            UpdateGenreCommandsValidator validations=new UpdateGenreCommandsValidator();
            validations.ValidateAndThrow(commands);

            commands.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]

        public IActionResult DeleteGenre(int id)
        {
           DeleteGenreCommand command=new DeleteGenreCommand(_context);
           command.GenreId=id;

           DeleteGenreCommandValidator validations=new DeleteGenreCommandValidator();
           validations.ValidateAndThrow(command);

           command.Handle();
           return Ok();
        }
    }
}