# HltvParserr
library to get top players from hltv, (Id,Name,KD, Maps played...)\
(NuGet Package) PM> Install-Package HltvParserr -Version 1.0.1

![image](https://user-images.githubusercontent.com/52431123/162681399-97299510-709f-4182-8275-19fa5bc2536a.png)


        public static async Task Main()
        {
            HltvParser parser = new HltvParser();
            var result = await parser.GetTopPlayersAsync(100);

            foreach (var top in result)
            {
                Console.WriteLine(
                    "Rank {0}, Name {1}, Maps Played {2}, Rounds {3}, Player KD {4}, KD_Difference {5} , Rating {6}"
                    ,top.Id,top.Name,top.Maps,top.Rounds, top.KD, top.KD_Diff, top.Rating);
            }

            Console.WriteLine(result.Count);

        }
        
        public class Player
        {
		public int Id { get; set; }
		public string? Name { get; set; }
		public int Maps { get; set; }
		public int Rounds { get; set; }
		public string? KD_Diff { get; set; }
		public string? KD { get; set; }
		public string? Rating { get; set; }
	}
