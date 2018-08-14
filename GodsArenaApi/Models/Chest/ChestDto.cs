using GodsArenaApi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class ChestDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public MythologyType MythologyType { get; set; } = MythologyType.Generic;
    }
}
