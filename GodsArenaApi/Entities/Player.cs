using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GodsArenaApi.Entities
{
    public class Player
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }

        public virtual Wallet Wallet { get; set; }

        public virtual PlayerStats PlayerStats { get; set; }

        public virtual Pack Pack { get; set; }

        public virtual List<Purchase> Purchases { get; set; }

        public virtual List<Deck> Decks { get; set; }
    }
}
