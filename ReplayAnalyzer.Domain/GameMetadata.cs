using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthDb;

namespace ReplayAnalyzer.Domain
{
    public class GameMetadata
    {
        public Enums.Classes PlayerClass { get; set; }
        public Enums.Classes OpponentClass { get; set; }
        public Enums.Results Result { get; set; }

    }
}
