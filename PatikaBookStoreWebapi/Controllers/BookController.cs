using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
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


namespace PatikaBookStoreWebapi.Controllers
{ 
    [Authorize] //tokenla koruma

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        public BookController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context,_mapper);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            BookDetailViewModel result;
        //    try   //try catchleri error mesajlarını olşturduğumuz middleware kullanarak hata mesajlarını bad request ekledik artık try catchlere crud da gerek kalmadı.
         //   {
                GetBookDetailQuery query = new GetBookDetailQuery(_context,_mapper);
                query.BookId = id;
                GetBookDetailQueryValidator validations=new GetBookDetailQueryValidator();
                validations.ValidateAndThrow(query);
                result = query.Handle();
         //   }
            // catch (Exception ex)
            // {

            //     return BadRequest(ex.Message);
            // }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBook newbook)
        {
            CreateBookCommand command = new CreateBookCommand(_context,_mapper);
         
                command.Model = newbook;

                //Handle etmeden once validatorlar doğru mu çalışıyor bakalım:))
                CreateBookCommandValidator validations = new CreateBookCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
                // ValidationResult result=validations.Validate(command);//error mesajlarına bak.
                // if(!result.IsValid)
                // foreach (var item in result.Errors)
                // {
                //     Console.WriteLine(" Özellik: "+ item.PropertyName+ " ErrorMesaj: " + item.ErrorMessage); //rule uymayanları göster hataları  consolda gösterir yinede çalışır Ok dondugu surece
                // }
                // else
                //  command.Handle();
           
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateViewModel updateBook)
        {
            
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updateBook;
                UpdateBookCommandValidator validations=new UpdateBookCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();

            // }
            // catch (Exception ex)
            // {
            //     return BadRequest(ex.Message);
            // }


            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
           
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();

            return Ok();
        }
    }
}