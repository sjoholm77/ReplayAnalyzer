using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HearthDb.Enums;
using NUnit.Framework;
using ReplayAnalyzer.Domain;

namespace ReplayAnalyzer.UnitTests
{
    [TestFixture]
    public class ReplayKeypointTests
    {
        [Test]
        public void GetPlayerEntityReturnsCorrectPlayerEntity()
        {
            var sut = TestDataGenerator.GenerateKeyPointContainingBothPlayersAndTheirHeroPowers(Enums.Classes.Priest, Enums.Classes.Warlock, true);
            Assert.IsTrue(sut.GetPlayerEntity(1).Tags.ContainsKey(GameTag.PLAYER_ID) && sut.GetPlayerEntity(1).Tags[GameTag.PLAYER_ID] == 1);
        }
    }
}
