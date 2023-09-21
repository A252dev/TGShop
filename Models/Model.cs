using System.ComponentModel.DataAnnotations;

namespace TelegramBot.Balance
{
    public class Model
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User { get; set; }
        [Required]
        public int Balance { get; set; }
    }
}
