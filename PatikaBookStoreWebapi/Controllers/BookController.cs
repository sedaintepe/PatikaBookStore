using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using PatikaBookStoreWebapi.BookOperations.CreateBook1;
using PatikaBookStoreWebapi.BookOperations.DeleteBook;
using PatikaBookStoreWebapi.BookOperations.GetBookDetail1;
using PatikaBookStoreWebapi.BookOperations.GetBooks;
using PatikaBookStoreWebapi.BookOperations.UpdateBook;
using PatikaBookStoreWebapi.DbOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using static PatikaBookStoreWebapi.BookOperations.CreateBook1.CreateBookCommand;

namespace PatikaBookStoreWebapi.AddControllers
{

    [ApiController]
    [Route("[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public BookController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context);
            var result = query.Handle();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {

            BookDetailViewModel result;
            try
            {
                GetBookDetailQuery query = new GetBookDetailQuery(_context);
                query.BookId = id;
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok(result);
        }
        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBook newbook)
        {
            CreateBookCommand command = new CreateBookCommand(_context);
            try
            {
                command.Model = newbook;

                //Handle etmeden once validatorlar doğru mu çalışıyor bakalım:))
                CreateBookVCommandValidator validations = new CreateBookVCommandValidator();
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
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateViewModel updateBook)
        {
            try
            {
                UpdateBookCommand command = new UpdateBookCommand(_context);
                command.BookId = id;
                command.Model = updateBook;
                command.Handle();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            try
            {
                DeleteBookCommand command = new DeleteBookCommand(_context);
                command.BookId = id;
                DeleteBookCommandValidator validations=new DeleteBookCommandValidator();
                validations.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();
        }
    }
}