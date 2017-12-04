using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikolaitis.Api.Database.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        [Key, Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserName { get; set; }

        [Required, StringLength(100), Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public UserEntity()
        {
            
        }

        public UserEntity(string userName, string email, string password)
        {
            UserName = userName;
            Email = email;
            Password = password;
        }

        public virtual ICollection<UserAuthorizationEntity> UserAuthorizations { get; set; } = new List<UserAuthorizationEntity>();
    }
}
