using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatikaBookStoreWebapi.Entities{
    public class User{
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RefreshToken { get; set; } //authen olmak için
        public DateTime? RefreshTokenExpireDate { get; set; } //access süresi doldugunda browserda saklanır bu süre
    }
}