# HltvParserr
library to get top players from hltv, (Id,Name,KD, Maps played...)
![image](https://user-images.githubusercontent.com/52431123/162681399-97299510-709f-4182-8275-19fa5bc2536a.png)


        public static async Task Main()
        {
            var result = await GetProPlayers();

            foreach (var top in result)
            {
                Console.WriteLine(
                    "Rank {0}, Name {1}, Maps Played {2}, Rounds {3}, Player KD {4}, KD_Difference {5} , Rating {6}"
                    ,top.Id,top.Name,top.Maps,top.Rounds, top.KD, top.KD_Diff, top.Rating);
            }

            Console.WriteLine(result.Count);

        }

        public static async Task<List<Player>> GetProPlayers()
        {
            HltvParser parser = new HltvParser();
            var result = await parser.GetTopPlayersAsync(20);

            return result;
        }
        
