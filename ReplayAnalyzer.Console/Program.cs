using System.Linq;
using ReplayAnalyzer.Domain;

namespace ReplayAnalyzer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var keypoints = ReplayFileParser.Parse(@"D:\Fredrik\Project\Other\Replays\Cerebus(Warlock) vs nerokosovara(Rogue) 1348-050317.hdtreplay");
            GameReplayAnalyzer.TemporaryForTest(keypoints);
        }
    }
}
