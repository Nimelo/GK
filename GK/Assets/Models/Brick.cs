using System;
using UnityEngine;

namespace Models
{
	public class Brick
	{
	   public Vector3 Position {
			get;
			set;
		}

		public GameObject Object{
			get;
			set;
		}

		public Brick (Vector3 pos, GameObject obj)
		{
			this.Position = pos;
			this.Object = obj;
		}
	}
}

