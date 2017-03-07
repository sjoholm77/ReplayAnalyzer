using System.Collections.Generic;
using HearthDb.Enums;

namespace ReplayAnalyzer.Domain
{
    public class Entity
    {
        public Entity()
        {
            Tags = new Dictionary<GameTag, int>();
        }

        public string Info { get; set; }
        public Dictionary<GameTag, int> Tags { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }
        public string CardId { get; set; }
        public bool IsPlayer { get; set; }
        public bool IsSecret { get; set; }
        public bool IsSpell { get; set; }
        public bool IsHeroPower { get; set; }
        public bool IsCurrentPlayer { get; set; }
        public bool HasCardId { get; set; }
    }
}
