using HtmlAgilityPack;

namespace HltvParserr
{
	public class HltvParser
	{
		public async Task<List<Player>> GetTopPlayersAsync(int topCount)
		{
			string topPlayersLink = $"https://www.hltv.org/stats/players?rankingFilter=Top{topCount}";
			HttpClient httpClient = new HttpClient();
			var response = await httpClient.GetAsync(topPlayersLink);
			var pageContent = await response.Content.ReadAsStringAsync();
			HtmlDocument htmlDocument = new HtmlDocument();
			htmlDocument.LoadHtml(pageContent);

			var trNodes = htmlDocument.DocumentNode.SelectNodes("/html/body/div[2]/div[1]/div[2]/div[1]/div/table/tbody").ToList();

			List<Player> Players = new List<Player>();
			int count = 0;

			for (int i = 1; i < trNodes[0].ChildNodes.Count; i++)
			{
				string name = trNodes[0].ChildNodes[i].ChildNodes[1].InnerText;
				int maps = Convert.ToInt32(trNodes[0].ChildNodes[i].ChildNodes[5].InnerText);
				int rounds = Convert.ToInt32(trNodes[0].ChildNodes[i].ChildNodes[7].InnerText);
				string kddiff = trNodes[0].ChildNodes[i].ChildNodes[9].InnerText;
				string kd = trNodes[0].ChildNodes[i].ChildNodes[11].InnerText;
				string rating = trNodes[0].ChildNodes[i].ChildNodes[13].InnerText;

				Players.Add(new Player { Id = count, Name = name, Maps = maps, Rounds = rounds, KD_Diff = kddiff, KD = kd, Rating = rating });
				count++;
				i++;
			}

			return Players;

		}
	}
}