using System;
using System.IO;
using System.Linq;
using ReplayAnalyzer.Domain;

namespace ReplayAnalyzer.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var files = Directory.GetFiles(@"D:\Fredrik\Project\Other\Replays\", "*.hdtreplay");
            foreach (var file in files)
            {
                var keypoints = ReplayFileParser.Parse(file);
                var metadata = GameReplayAnalyzer.GenerateMetadata(keypoints);
                System.Console.WriteLine($"{metadata.PlayerManaSpent} - {metadata.OpponentManaSpent} = {metadata.PlayerManaSpent - metadata.OpponentManaSpent} => {metadata.Result}");
            }
            System.Console.Read();
        }
    }
}
