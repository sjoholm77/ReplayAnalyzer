namespace ReplayAnalyzer.Domain
{
    public class ReplayKeyPoint
    {
        public Entity[] Data { get; set; }
        public int Id { get; set; }
        public Enums.ActivePlayer Player { get; set; }
        public Enums.KeyPointType Type { get; set; }
        public int Turn { get; set; }
    }
}
