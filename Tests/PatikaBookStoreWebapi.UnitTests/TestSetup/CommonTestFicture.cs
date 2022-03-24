using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PatikaBookStoreWebapi.Common;
using PatikaBookStoreWebapi.DbOperations;

namespace TestSetup
{
    public class CommonTestFicture
    {
        public BookStoreDbContext Context { get; set; }
        public IMapper Mapper { get; set; }
        public CommonTestFicture(){
            var options=new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(databaseName:"BookStoreTestDB").Options;
            Context=new BookStoreDbContext(options);
            Context.Database.EnsureCreated();
            //Commits
            Context.AddBooks();
            Context.AddGenres();
            Context.AddAuthors();            
            Context.SaveChanges();

            //Mapping

            Mapper=new MapperConfiguration(cfg=>{cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }

    }
}