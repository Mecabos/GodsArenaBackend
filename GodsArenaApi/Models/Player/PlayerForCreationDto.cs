using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class PlayerForCreationDto
    {
        public int Age { get; set; }
        [Required]
        [MaxLength(35), MinLength(4)]
        public string Username { get; set; }
    }
}
