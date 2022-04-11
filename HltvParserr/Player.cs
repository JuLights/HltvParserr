using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HltvParserr
{
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
}
