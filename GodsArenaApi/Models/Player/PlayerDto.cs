using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class PlayerDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Username { get; set; }
    }
}
