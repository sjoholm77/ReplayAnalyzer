using System;
using System.Collections.Generic;
using HearthDb.Enums;
using NUnit.Framework;
using ReplayAnalyzer.Domain;

namespace ReplayAnalyzer.UnitTests
{
    [TestFixture]
    public class GameReplayAnalyzerTests
    {
        [Test]
        public void If_PlayerIsPriest_Then_GameReplayAnalyzerGenereatesMetadataCorrectly()
        {
            var entities = TestDataGenerator.GeneratePlayerAndOpponentWithHeroPowers(Enums.Classes.Priest, Enums.Classes.Warlock, true);
            var keypoints = new List<ReplayKeyPoint> { new ReplayKeyPoint { Data = entities.ToArray() } };
            var res = GameReplayAnalyzer.GenerateMetadata(keypoints);
            Assert.AreEqual(Enums.Classes.Priest, res.PlayerClass);
        }

        [Test]
        public void If_OpponentIsWarlock_Then_GameReplayAnalyzerGenereatesMetadataCorrectly()
        {
            var entities = TestDataGenerator.GeneratePlayerAndOpponentWithHeroPowers(Enums.Classes.Priest, Enums.Classes.Warlock, true);
            var keypoints = new List<ReplayKeyPoint> { new ReplayKeyPoint { Data = entities.ToArray() } };
            var res = GameReplayAnalyzer.GenerateMetadata(keypoints);
            Assert.AreEqual(Enums.Classes.Warlock, res.OpponentClass);
        }

        [Test]
        public void If_KeypointsContainDefeat_Then_MetadataResultIsLoss()
        {
            var entities = TestDataGenerator.GeneratePlayerAndOpponentWithHeroPowers(Enums.Classes.Priest, Enums.Classes.Warlock, true);
            var keypoints = new List<ReplayKeyPoint> { new ReplayKeyPoint { Data = entities.ToArray() } };
            keypoints.Add(TestDataGenerator.GenerateDefeatKeypoint());
            var res = GameReplayAnalyzer.GenerateMetadata(keypoints);
            Assert.AreEqual(Enums.Results.Loss, res.Result);
        }

        [Test]
        public void If_KeypointsContainVictory_Then_MetadataResultIsWin()
        {
            var entities = TestDataGenerator.GeneratePlayerAndOpponentWithHeroPowers(Enums.Classes.Priest, Enums.Classes.Warlock, true);
            var keypoints = new List<ReplayKeyPoint> { new ReplayKeyPoint { Data = entities.ToArray() } };
            keypoints.Add(TestDataGenerator.GenerateVictoryKeypoint());
            var res = GameReplayAnalyzer.GenerateMetadata(keypoints);
            Assert.AreEqual(Enums.Results.Win, res.Result);
        }
    }

    class TestDataGenerator
    {
        public static List<Entity> GeneratePlayerAndOpponentWithHeroPowers(Enums.Classes playerClass, Enums.Classes opponentClass, bool playerHasCoin)
        {
            var entities = new List<Entity>();
            var player = GeneratePlayer(playerHasCoin);
            var opponent = GenerateOpponent(!playerHasCoin);
            var playerHeroPower = GenerateHeroPower(playerClass);
            playerHeroPower.Tags.Add(GameTag.CONTROLLER, player.Tags[GameTag.PLAYER_ID]);
            var opponentHeroPower = GenerateHeroPower(opponentClass);
            opponentHeroPower.Tags.Add(GameTag.CONTROLLER, opponent.Tags[GameTag.PLAYER_ID]);
            entities.Add(player);
            entities.Add(playerHeroPower);
            entities.Add(opponent);
            entities.Add(opponentHeroPower);
            return entities;
        }

        public static Entity GenerateHeroPower(Enums.Classes theClass)
        {
            switch (theClass)
            {
                case Enums.Classes.Priest:
                    return new Entity { CardId = "CS1h_001", IsHeroPower = true };
                case Enums.Classes.Warlock:
                    return new Entity { CardId = "CS2_056", IsHeroPower = true };
                case Enums.Classes.Druid:
                case Enums.Classes.Hunter:
                case Enums.Classes.Mage:
                case Enums.Classes.Paladin:
                case Enums.Classes.Rouge:
                case Enums.Classes.Shaman:
                case Enums.Classes.Warrior:
                default:
                    throw new ArgumentOutOfRangeException(nameof(theClass), theClass, null);
            }
        }

        public static Entity GeneratePlayer(bool hasCoin)
        {
            var playerEntity = new Entity {IsPlayer = true};
            playerEntity.Tags.Add(GameTag.PLAYER_ID, hasCoin ? 2 : 1);
            return playerEntity;
        }

        public static Entity GenerateOpponent(bool hasCoin)
        {
            var opponentEntity = new Entity();
            opponentEntity.Tags.Add(GameTag.PLAYER_ID, hasCoin ? 2 : 1);
            return opponentEntity;
        }

        public static ReplayKeyPoint GenerateDefeatKeypoint()
        {
            return new ReplayKeyPoint
            {
                Type = Enums.KeyPointType.Defeat,
                Player = Enums.ActivePlayer.Player
            };
        }

        public static ReplayKeyPoint GenerateVictoryKeypoint()
        {
            return new ReplayKeyPoint
            {
                Type = Enums.KeyPointType.Victory,
                Player = Enums.ActivePlayer.Player
            };
        }
    }
}
