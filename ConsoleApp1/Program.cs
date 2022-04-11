using HltvParserr;

namespace testing
{
    public static class Program
    {
        //public static List<Player> _players = new List<Player>();
        public static async Task Main()
        {
            var result = await GetTopsAsync();

            foreach(var top in result)
            {
                Console.WriteLine(top.Name);
            }

            Console.WriteLine(result.Count);
            
        }

        

        public static async Task<List<Player>> GetTopsAsync()
        {
            HltvParser hltvParser = new HltvParser();
            var result = await hltvParser.GetTopPlayersAsync(100);

            return result;

        }
       
    }
    
}


