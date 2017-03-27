using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using HearthDb;
using HearthDb.Enums;

namespace ReplayAnalyzer.Domain
{
    public class GameReplayAnalyzer
    {
        public static GameMetadata GenerateMetadata(List<ReplayKeyPoint> keypoints)
        {
            var metaData = new GameMetadata();
            var playerId = GetHumanId(keypoints, true);
            var opponentId = GetHumanId(keypoints, false);
            var playerHeroPowerCardId = GetHeroPowerByPlayerId(keypoints, playerId);
            var opponentHeroPowerCardId = GetHeroPowerByPlayerId(keypoints, opponentId);
            metaData.PlayerClass = GetHeroClassFrom(Cards.All[playerHeroPowerCardId].Class);
            metaData.OpponentClass = GetHeroClassFrom(Cards.All[opponentHeroPowerCardId].Class);
            metaData.Result = GetResult(keypoints);
            metaData.PlayerManaSpent = GetTotalManaSpent(playerId, keypoints.Last());
            metaData.OpponentManaSpent = GetTotalManaSpent(opponentId, keypoints.Last());
            return metaData;
        }

        private static int GetTotalManaSpent(int playerId, ReplayKeyPoint lastKeypoint)
        {
            return lastKeypoint.GetPlayerEntity(playerId).Tags[GameTag.NUM_RESOURCES_SPENT_THIS_GAME];
        }

        private static Enums.Results GetResult(List<ReplayKeyPoint> keypoints)
        {
            if (keypoints.Exists(x => x.Type == Enums.KeyPointType.Victory))
                return Enums.Results.Win;
            return Enums.Results.Loss;

        }

        private static string GetHeroPowerByPlayerId(List<ReplayKeyPoint> keypoints, int playerId)
        {
            return keypoints[0].Data.Single(x => x.IsHeroPower && x.Tags[GameTag.CONTROLLER] == playerId).CardId;
        }

        private static int GetHumanId(List<ReplayKeyPoint> keypoints, bool forPlayer)
        {
            return keypoints[0].Data.Where(x => x.Tags.ContainsKey(GameTag.PLAYER_ID)).Single(y => y.IsPlayer == forPlayer).Tags[GameTag.PLAYER_ID];
        }

        private static Enums.Classes GetHeroClassFrom(CardClass cardClass)
        {
            switch (cardClass)
            {
                case CardClass.DRUID:
                    return Enums.Classes.Druid;
                case CardClass.HUNTER:
                    return Enums.Classes.Hunter;
                case CardClass.MAGE:
                    return Enums.Classes.Mage;
                case CardClass.PALADIN:
                    return Enums.Classes.Paladin;
                case CardClass.PRIEST:
                    return Enums.Classes.Priest;
                case CardClass.ROGUE:
                    return Enums.Classes.Rouge;
                case CardClass.SHAMAN:
                    return Enums.Classes.Shaman;
                case CardClass.WARLOCK:
                    return Enums.Classes.Warlock;
                case CardClass.WARRIOR:
                    return Enums.Classes.Warrior;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cardClass), cardClass, null);
            }
        }

        public static void TemporaryForTest(List<ReplayKeyPoint> keypoints)
        {
            var lastKeypoint = keypoints.Last();
            var heroPower = keypoints[0].Data.Where(x => x.IsHeroPower);
            var players = keypoints[0].Data.Where(x => x.Tags.ContainsKey(GameTag.PLAYER_ID));
            var defeat = keypoints.SingleOrDefault(x => x.Type == Enums.KeyPointType.Defeat);
            var victory = keypoints.SingleOrDefault(x => x.Type == Enums.KeyPointType.Victory);
        }
    }
}
