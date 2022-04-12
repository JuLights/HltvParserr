using HltvParserr;

namespace testing
{
    public static class Program
    {
        public static async Task Main()
        {
            HltvParser hltvParser = new HltvParser();
            var result = await hltvParser.GetTopPlayersAsync(100);

            foreach (var topPlayer in result)
            {
                Console.WriteLine(
                "Rank {0}, Name {1}, Maps Played {2}, Rounds {3}, Player KD {4}, KD_Difference {5} , Rating {6}"
                , topPlayer.Id, topPlayer.Name, topPlayer.Maps, topPlayer.Rounds, topPlayer.KD, topPlayer.KD_Diff, topPlayer.Rating
                );
            }

            Console.WriteLine(result.Count);
            Console.ReadLine();
            
        }
       
    }
    
}


