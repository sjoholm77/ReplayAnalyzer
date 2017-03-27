using System.Collections.Generic;
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
}
