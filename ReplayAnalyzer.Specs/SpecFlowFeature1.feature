Feature: SpecFlowFeature1
	In order to avoid silly mistakes
	As a math idiot
	I want to be told the sum of two numbers

@mytag
Scenario: Generate metadata from loss
	Given I have parsed file with path D:\Fredrik\Project\Other\ReplayAnalyzer\ReplayAnalyzer.Specs\TestFiles\WarlockLossVsPriest.hdtreplay
	And I have generated metadata for the keypoints
	Then Player Class should be Warlock
	Then Opponent class should be Priest
	Then Result should be Loss
	Then Player mana spent should be 119
	Then Opponent mana spent should be 129

Scenario: Generate metadata from win
	Given I have parsed file with path D:\Fredrik\Project\Other\ReplayAnalyzer\ReplayAnalyzer.Specs\TestFiles\WarlockWinVsRouge.hdtreplay
	And I have generated metadata for the keypoints
	Then Player Class should be Warlock
	Then Opponent class should be Rouge
	Then Result should be Win
	Then Player mana spent should be 36
	Then Opponent mana spent should be 41
	
