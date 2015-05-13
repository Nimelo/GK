using System.Timers;
using System;
namespace Models
{
	public class LevelTimer :Timer
	{
		private static LevelTimer lvlstopwatch;
		
		
		public static LevelTimer Instance
		{
			get
			{
				if(lvlstopwatch == null)
					lvlstopwatch = new LevelTimer();
				return lvlstopwatch;
			}
		}

		public TimeSpan Added = new TimeSpan();

		public void Add(int seconds)
		{
			this.Added.Add (new TimeSpan (0, 0, seconds));
		}
	}
}

