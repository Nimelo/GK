using System.Diagnostics;
using System;
namespace Models
{
	public class LevelStopwatch : Stopwatch
	{
		private static LevelStopwatch lvlstopwatch;


		public static LevelStopwatch Instance
		{
			get
			{
				if(lvlstopwatch == null)
					lvlstopwatch = new LevelStopwatch();
				return lvlstopwatch;
			}
		}


	}
}

