using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour {
    public Transform _ScoringObstacle;
	public List<Transform> Obstacles = new List<Transform>();
	public Transform spaceShip;
	float maxYvalue = 0f;

    private float distTravelled = 0f;


    public Vector2 _ScrollDirection = new Vector3(0, -1);
    public float _ScrollSpeed = 10f;

    public float _ObstactleDespawnY = -5f;

    private List<Transform> _activeObstacles = new List<Transform>();

    private GameplayManager _gameplayManager;

    // Use this for initialization
    void Start () {
        _gameplayManager = GameObject.Find("LevelController").GetComponent<GameplayManager>();
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

        _activeObstacles.Add(newObst);
        _activeObstacles.Add(newTrigger);
	}
		
	// Update is called once per frame
	void Update () {
        if(_gameplayManager.GetGameplayState() != GameplayManager.GameplayState.PLAYING)
        {
            return;
        }

        distTravelled += (_ScrollSpeed * Time.deltaTime);

        float distBetweenObs = 5f - Mathf.Min( 3f, Time.timeSinceLevelLoad * 0.03f );
		if (distTravelled >= maxYvalue + distBetweenObs )
        { 
			SpawnNewObstacle ();
			maxYvalue = distTravelled;
		}

        List<Transform> toDestroy = new List<Transform>();

        foreach(Transform t in _activeObstacles)
        {
            // Scroll the obstacles
            t.Translate(_ScrollDirection * (_ScrollSpeed * Time.deltaTime));


            // Clean up obstacles that have gone too far
            if(t.position.y < _ObstactleDespawnY)
            {
                toDestroy.Add(t);
            }
        }
        foreach(Transform t in toDestroy)
        {
            _activeObstacles.Remove(t);
            Destroy(t.gameObject);
        }

    }
}
