using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mikolaitis.Api.Database.Entities
{
    [Table("UserAuthorizations")]
    public class UserAuthorizationEntity
    {
        [Key, Required]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required, ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        [Required]
        public DateTime AuthorizationDate { get; set; } = DateTime.UtcNow;
        
        public virtual UserEntity User { get; set; }
    }
}
