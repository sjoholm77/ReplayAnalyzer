using System.Linq;
using HearthDb.Enums;

namespace ReplayAnalyzer.Domain
{
    public class ReplayKeyPoint
    {
        public Entity[] Data { get; set; }
        public int Id { get; set; }
        public Enums.ActivePlayer Player { get; set; }
        public Enums.KeyPointType Type { get; set; }
        public int Turn { get; set; }

        public Entity GetPlayerEntity(int playerId)
        {
            return Data.Single(x => x.Tags.ContainsKey(GameTag.PLAYER_ID) && x.Tags[GameTag.PLAYER_ID] == playerId);
        }
    }
}
