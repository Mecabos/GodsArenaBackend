using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Models
{
    public class PackContentWithoutCardDto
    {
        public int PackId { get; set; }
        public int CardId { get; set; }
        public int Count { get; set; }
    }
}
