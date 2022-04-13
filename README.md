# HltvParserr
library to get top players from hltv, (Id,Name,KD, Maps played...)\
(NuGet Package) PM> Install-Package HltvParserr -Version 1.0.3

https://www.nuget.org/packages/HltvParserr/1.0.3

![image](https://user-images.githubusercontent.com/52431123/162681399-97299510-709f-4182-8275-19fa5bc2536a.png)


        public static async Task Main()
        {
            HltvParser parser = new HltvParser();
            var result = await parser.GetTopPlayersAsync(100);

            foreach (var topPlayer in result)
            {
                Console.WriteLine(
                    "Rank {0}, Name {1}, Maps Played {2}, Rounds {3}, Player KD {4}, KD_Difference {5} , Rating {6}"
                    ,topPlayer.Id,topPlayer.Name,topPlayer.Maps,topPlayer.Rounds, topPlayer.KD, topPlayer.KD_Diff, topPlayer.Rating);
            }

            Console.WriteLine(result.Count);

        }
        
