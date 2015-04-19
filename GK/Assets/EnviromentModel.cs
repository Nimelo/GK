using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnviromentModel {

	private bool[,,] cubes;
	public int Size {
		get;
		private set;
	}

	public bool[,,] Cubes {
		get
		{
			return this.cubes;
		}
	}

	public EnviromentModel (int size)
	{	
		this.Size = size;
		this.cubes =  new bool[this.Size,this.Size, this.Size];

		this.cubes [0, 0, 0] = true;
		this.cubes [1, 0, 0] = true;
		this.cubes [0, 1, 0] = true;
	}

	public IList<Vector3> GetCubesPositions()
	{
		List<Vector3> returnList = new List<Vector3> ();
		for (int x = 0; x < this.Size; x++) {

			for (int y = 0; y < this.Size; y++) {
				for (int z = 0; z < this.Size; z++) {
					if(this.cubes[x,y,z])
						returnList.Add(new Vector3(x,y,z));					
					
				}
			}
		}
		return returnList;
	}
}

