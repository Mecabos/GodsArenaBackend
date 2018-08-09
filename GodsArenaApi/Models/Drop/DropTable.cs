using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GodsArenaApi.Entities;
using Random_Distribution_System;

namespace GodsArenaApi.Models
{
    public class DropTable : RDSTable
    {
        public DropTable(LootTable lootTable)
            : base()
        {
            rdsCount = lootTable.LootCount;
        }
    }
}
