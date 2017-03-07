namespace ReplayAnalyzer.Domain
{
    public class Enums
    {
        public enum ActivePlayer
        {
            Player,
            Opponent,
            None
        }

        public enum KeyPointType
        {
            Play,
            Draw,
            Mulligan,
            Death,
            HandDiscard,
            DeckDiscard,
            SecretPlayed,
            SecretTriggered,
            Turn,
            Attack,
            PlayToHand,
            PlayToDeck,
            Obtain,
            Summon,
            HandPos,
            BoardPos,
            PlaySpell,
            Weapon,
            WeaponDestroyed,
            HeroPower,
            Victory,
            Defeat,
            SecretStolen,
            CreateToDeck
        }

        public enum Classes
        {
            Druid, 
            Hunter, 
            Mage,
            Paladin, 
            Priest, 
            Rouge, 
            Shaman, 
            Warlock, 
            Warrior
        }

        public enum Results
        {
            Win, 
            Loss,
            Draw
        }
    }
}
