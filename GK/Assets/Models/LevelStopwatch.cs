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

		TimeSpan _offsetTimeSpan;

		public void Add(TimeSpan ts)
		{
			this._offsetTimeSpan = this._offsetTimeSpan.Add (ts);
		}

		public TimeSpan ElapsedTimeSpan
		{
			get
			{
				return lvlstopwatch.Elapsed + _offsetTimeSpan;
			}
			set
			{
				_offsetTimeSpan = value;
			}
		}


		
	}
}

