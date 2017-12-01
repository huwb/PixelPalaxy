using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public Transform _ScoringObstacle;
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

		if (Random.Range (0f, 1f) >= 0.75) {
			Vector3 rotation = newObst.rotation.ToEulerAngles();
			rotation.z = rotation.z + Random.Range(-7.5f, 7.5f);
			newObst.rotation = Quaternion.Euler (rotation);
		}

        Transform newTrigger = Instantiate(_ScoringObstacle) as Transform;
        newTrigger.position = newPos + Vector3.up * 1f;

	}
		
	// Update is called once per frame
	void Update () {
        float distBetweenObs = 5f - Mathf.Min( 3f, Time.timeSinceLevelLoad * 0.03f );
		if (spaceShip.position.y >= maxYvalue + distBetweenObs )
        { 
			SpawnNewObstacle ();
			maxYvalue = spaceShip.position.y;
		}
	}
}
