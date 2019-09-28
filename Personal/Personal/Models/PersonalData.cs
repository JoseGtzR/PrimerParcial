using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Personal.Models
{
    public class PersonalData
    {
        [Key]
        public int FriendId { get; set; }

        [StringLength(50, MinimumLength = 5,ErrorMessage = "Nombre completo ")]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        public List Lista { get; set; }

        [Required(ErrorMessage = "Cumpleaños")]
        public DateTime Birthdate { get; set; }

    }

    public enum List
    {
        Gonzalo,
        Gustavo,
        Gael,
        Gary,
        Gerardo,
    }

}