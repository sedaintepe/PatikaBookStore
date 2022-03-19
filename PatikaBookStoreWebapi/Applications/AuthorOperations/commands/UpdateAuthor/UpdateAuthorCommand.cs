using System;
using System.Linq;
using AutoMapper;
using PatikaBookStoreWebapi.DbOperations;
using PatikaBookStoreWebapi.Entities;

namespace PatikaBookStoreWebapi.Applications.AuthorOperations.commands.UpdateAuthor{
    public class UpdateAuthorCommand{
        public int AuthorId { get; set; }
        public AuthorUpdateViewModel Model { get; set; }
        private readonly BookStoreDbContext _context;
        public UpdateAuthorCommand(BookStoreDbContext context)
        {
            _context = context;
        }
        public void Handle(){
            var author=_context.Authors.SingleOrDefault(x=>x.Id==AuthorId);
            if(author is null) throw new InvalidOperationException("Güncellenicek yazar bulunamadı!");
              if(_context.Authors.Any(x=>x.Name.ToLower()==Model.Name.ToLower()&& x.Id!=AuthorId))
            throw new InvalidOperationException("Aynı isimli yazar zaten var!");

            author.Name=string.IsNullOrEmpty(Model.Name.Trim())? author.Name:Model.Name; 
            author.BookId=Model.BookId!=default?Model.BookId:author.BookId;

            _context.SaveChanges();
        }

    }
    public class AuthorUpdateViewModel{
        public string Name { get; set; }
        public int BookId { get; set; }


    }
}