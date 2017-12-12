using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameplayManager : MonoBehaviour {

    enum GameplayState
    {
        START_SCREEN,
        PLAYING,
        DEAD
    }

    public Text _startText;
    public Text _gameOverText;

    public AudioSource scoring;

    private int _score = 0;
    private static GameplayState _gameplayState = GameplayState.START_SCREEN;

    private MakePixels _makePixels;

    public void AddToScore(int score)
    {
        _score += score;
        scoring.Play();
    }

    public int GetScore() { return _score; }


    // Use this for initialization
    void Start () {
        _gameOverText.enabled = false;
        _makePixels = GameObject.Find("PlayerCharacter").GetComponent<MakePixels>();
    }
	
	// Update is called once per frame
	void Update () {
        if(_makePixels == null)
        {
            Debug.LogError("MakePixels could not be found!");
            return;
        }

        switch(_gameplayState)
        {
            case GameplayState.START_SCREEN:
                UpdateStartScreen();
                break;
            case GameplayState.PLAYING:
                UpdatePlaying();
                break;
            case GameplayState.DEAD:
                UpdateDead();
                break;
        }
    }

    private void UpdatePlaying()
    {
        _startText.enabled = false;

        if (_makePixels.getPixelCount() <= 0)
        {
            _gameplayState = GameplayState.DEAD;
        }
    }

    private void UpdateDead()
    {
        _gameOverText.enabled = true;

        if (Input.GetKey(KeyCode.Space))
        {
            // Reload the scene but skip the start screen
            _gameplayState = GameplayState.PLAYING;
            SceneManager.LoadScene("main");
        }
    }

    private void UpdateStartScreen()
    {
        _startText.enabled = true;

        if (Input.GetKey(KeyCode.Space))
        {
            _gameplayState = GameplayState.PLAYING;
        }
    }
}
