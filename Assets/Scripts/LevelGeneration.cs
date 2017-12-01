using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
	public List<Transform> Obstacles = new List<Transform>();
	public Transform spaceShip;
	float maxYvalue = 0f;

	// Use this for initialization
	void Start () {
		maxYvalue = spaceShip.position.y;
	}

	void SpawnNewObstacle(){
		int random = Random.Range(0,  Obstacles.Count - 1);
		Transform newObst = Instantiate (Obstacles [random]) as Transform;
		Vector3 newPos = spaceShip.position;
		newPos.y = newPos.y + 10;
		newObst.position = newPos;
	}
		
	// Update is called once per frame
	void Update () {
		if (spaceShip.position.y >= maxYvalue + 5){ 
			SpawnNewObstacle ();
			maxYvalue = spaceShip.position.y;
		}
	}
}
