using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PixelScoreAdder : MonoBehaviour {
    private List<GameObject> _pixelsBeenHit;
    private GameplayManager _gameplayManager;

	// Use this for initialization
	void Start () {
        _gameplayManager = GameObject.Find("LevelController").GetComponent<GameplayManager>();
        _pixelsBeenHit = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        foreach(GameObject o in _pixelsBeenHit)
        {
            if( other.gameObject == o)
            {
                return;
            }
        }
        _pixelsBeenHit.Add(other.gameObject);
        _gameplayManager.AddToScore(10);

    }
}
