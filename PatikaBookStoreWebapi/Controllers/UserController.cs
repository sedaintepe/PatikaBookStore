using AutoMapper;
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
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IMapper _mapper;

        readonly IConfiguration _configuration;
        public UserController(IBookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}