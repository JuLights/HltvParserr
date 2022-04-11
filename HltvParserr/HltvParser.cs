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

		//public static async Task<List<PlayersGear>> GetPlayersGearAsync()
		//{
		//	HtmlDocument htmlDocument = new HtmlDocument();
		//	var docPath = Environment.CurrentDirectory + "\\HtmlDoc\\gearList.html";
		//	htmlDocument.LoadHtml(await File.ReadAllTextAsync(docPath));

		//	var trPath = @"//*[@id=""table_1""]/tbody";
		//	var trNodes = htmlDocument.DocumentNode.SelectNodes(trPath).ToList();
		//	List<PlayersGear> PlayersGear = new List<PlayersGear>();
		//	int count = 0;

		//	for (int i = 1; i < trNodes[0].ChildNodes.Count; i++)
		//	{

		//		var nodes = trNodes[0].ChildNodes[i].ChildNodes;
		//		PlayersGear.Add(new PlayersGear
		//		{
		//			//Id = count,
		//			Team = nodes[0].InnerText,
		//			Name = nodes[1].InnerText,
		//			Role = nodes[2].InnerText,
		//			Mouse = nodes[3].InnerText,
		//			MouseHz = nodes[4].InnerText,
		//			DPI = nodes[5].InnerText,
		//			Sens = nodes[6].InnerText,
		//			eDPI = nodes[7].InnerText,
		//			ZoomSens = nodes[8].InnerText,
		//			Accel = nodes[9].InnerText,
		//			WinSens = nodes[10].InnerText,
		//			RawInput = nodes[11].InnerText,
		//			Monitor = nodes[12].InnerText,
		//			MonitorHz = nodes[13].InnerText,
		//			GPU = nodes[14].InnerText,
		//			Resolution = nodes[15].InnerText,
		//			AspectRatio = nodes[16].InnerText,
		//			ScalingMode = nodes[17].InnerText,
		//			MousePad = nodes[18].InnerText,
		//			KeyBoard = nodes[19].InnerText,
		//			Headset = nodes[20].InnerText,
		//			CFG = nodes[21].InnerText
		//		});
		//		count++;
		//	}

		//	return PlayersGear;
		//}

	}
}