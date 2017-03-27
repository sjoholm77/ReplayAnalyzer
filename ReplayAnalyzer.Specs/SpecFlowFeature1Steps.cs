using System;
using System.Collections.Generic;
using ReplayAnalyzer.Domain;
using TechTalk.SpecFlow;
using Xunit;

namespace ReplayAnalyzer.Specs
{
    [Binding]
    public class SpecFlowFeature1Steps
    {
        private List<ReplayKeyPoint> parsedKeypoints;
        private GameMetadata generatedMetadata;

        [Given(@"I have parsed file with path (.*)")]
        public void GivenIHaveParsedFileWithPath(string p0)
        {
            parsedKeypoints = ReplayFileParser.Parse(p0);
        }
        
        [Given(@"I have generated metadata for the keypoints")]
        public void GivenIHaveGeneratedMetadataForTheKeypoints()
        {
            generatedMetadata = GameReplayAnalyzer.GenerateMetadata(parsedKeypoints);
        }
        
        [Then(@"Opponent class should be (.*)")]
        public void ThenOpponentClassShouldBe(Enums.Classes c)
        {
            Assert.Equal(c, generatedMetadata.OpponentClass);
        }

        [Then(@"Player Class should be (.*)")]
        public void ThenPlayerClassShouldBe(Enums.Classes c)
        {
            Assert.Equal(c, generatedMetadata.PlayerClass);
        }

        [Then(@"Result should be (.*)")]
        public void ThenResultShouldBe(Enums.Results result)
        {
            Assert.Equal(result, generatedMetadata.Result);
        }

        [Then(@"Player mana spent should be (.*)")]
        public void ThenPlayerManaSpentShouldBe(int manaSpent)
        {
            Assert.Equal(manaSpent, generatedMetadata.PlayerManaSpent);
        }

        [Then(@"Opponent mana spent should be (.*)")]
        public void ThenOpponentManaSpentShouldBe(int manaSpent)
        {
            Assert.Equal(manaSpent, generatedMetadata.OpponentManaSpent);
        }


    }
}
