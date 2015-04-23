using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Models;

public class EnvironmentModel {

	private List<Brick> bricks;
	public Vector3 Offset{ get; set;}
	public int CurrentLevel { get; set; }
	public List<Brick> Bricks {
		get
		{
			return new List<Brick>(this.bricks);
		}
	}

	private static void CreateModel ()
	{	
		model = new EnvironmentModel ();
		model.Offset = new Vector3 (0, 0, 0);
		model.bricks = new List<Brick> ();
		model.CurrentLevel = 0;
	}


	private static EnvironmentModel model;

	public static EnvironmentModel Instance
	{
		get
		{
			if (model == null)
				CreateModel ();
			return model;
		}

	}

	public IEnumerable<Vector3> GetBricksPositions()
	{
		return this.Bricks.Select(x=>x.Position);
	}

	public void AddBrick(GameObject obj)
	{
		this.bricks.Add (new Brick (obj.transform.position, obj));			
	}
	
	public delegate void DestroyGameObjectHandler(GameObject obj);
	public event DestroyGameObjectHandler DestroyGameObjectEvent;

	public bool RemoveBrick(Vector3 pos)
	{
		Brick toRemove = this.bricks.Where (x => x.Position - this.Offset == pos).SingleOrDefault ();
		if (toRemove != null) {
			if(toRemove.Object.transform.localScale.x > 0.21f)
			{
				toRemove.Object.transform.localScale = toRemove.Object.transform.localScale - new Vector3(0.2f, 0.2f, 0.2f);
				return false;
			}
			else
			{
				this.bricks.Remove (toRemove);
				
				DestroyGameObjectEvent(toRemove.Object);
				return true;
			}
		}
		return false;
	}

	public void RemoveAll()
	{
		this.bricks.ForEach (x => DestroyGameObjectEvent (x.Object));
		this.bricks = new List<Brick> ();

	}

	public void Generate(int amountOfBricks, int radiusX, int radiusY, int radiusZ)
	{
		System.Random rnd = new System.Random (System.DateTime.Now.Second);

		int bricks = 0;
		while (bricks < amountOfBricks) {
			var pos = new Vector3(rnd.Next(2* radiusX) - radiusX, rnd.Next(radiusY), rnd.Next(2* radiusZ) - radiusZ);
			if(!this.bricks.Exists(x=>x.Position == pos))
			{

			var obj =  GameObject.CreatePrimitive(PrimitiveType.Cube);
			obj.GetComponent<Renderer>().material.color = this.getRandColor();
			obj.transform.position = pos + this.Offset;

				this.AddBrick(obj);

			bricks++;
			}		
		}

	}

	 private Color getRandColor(){
				float r = Random.value;
				float g = Random.value;
				float b = Random.value;
				return new Color(r,g,b);
			}

	public bool CanInsertAtPosition(Vector3 position){
			if (this.Bricks.Exists (x => x.Position - this.Offset == position))
			return false;

		if (position.y == 0)
			return true;

		Vector3 tmp = new Vector3 (position.x, position.y, position.z);

		 return this.Bricks.Select(x=>x.Position - this.Offset).ToList().Exists (x => {

			//Underneath
			tmp.y -= 1;
			if(x != tmp)
			{
				tmp.y ++;
				tmp.x --;
				//OnLeft
				if(x != tmp)
				{
					tmp.x += 2;
					//OnRight
					if(x != tmp)
					{
						tmp.x --;
						tmp.z --;
						//OnFront
						if(x != tmp)
						{
							tmp.z += 2;
							//OnRear
							if(x != tmp)
							{
								tmp.z --;
								return false;	
							} 
						} 
					} 
				} 			
			}
			return true;
		}); 

	}
}

