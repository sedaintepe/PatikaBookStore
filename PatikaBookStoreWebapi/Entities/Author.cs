using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaBookStoreWebapi.Entities{
    public class Author{
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] //odev 2.madde
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
         public int BookId { get; set; } //odev 3. madde
         public Book Book  { get; set; }  
        public DateTime BirthDate{get;set;}

    }
}