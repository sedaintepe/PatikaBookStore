using System;
using System.Linq;
using AutoMapper;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.commands.CreateAuthor{
    public class CreateAuthorCommand{
        public CreateAuthor Model{get;set;}
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;

        public CreateAuthorCommand(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public void Handle(){
            var author=_context.Authors.SingleOrDefault(x=>x.Name==Model.Name);
            if(author is not null) throw new InvalidOperationException("İsimli yazar zaten var!");
            author=_mapper.Map<Author>(Model);
            _context.Authors.Add(author);
            _context.SaveChanges();
        }
    }
    public class CreateAuthor{
        public string Name { get; set; }
        public string Surname { get; set; }
        public int BookId { get; set; }
        public DateTime BirthDate{ get; set; }
    }

}