using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameplayManager : MonoBehaviour {

    public enum GameplayState
    {
        START_SCREEN,
        PLAYING,
        DEAD
    }

    public Text _startText;
    public Text _gameOverText;
    public Text _scoreboardTextContainer;
    private InputField _inputField;

    public AudioSource scoring;

    private int _score = 0;
    private static GameplayState _gameplayState = GameplayState.START_SCREEN;
    private static List<ScoreboardEntry> _scoreboard = new List<ScoreboardEntry>();

    public GameplayState GetGameplayState()
    {
        return _gameplayState;
    }

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
        _scoreboardTextContainer.enabled = false;
        _makePixels = GameObject.Find("PlayerCharacter").GetComponent<MakePixels>();
        _inputField = GameObject.Find("Canvas").GetComponent<InputField>();
        _inputField.enabled = false;
        _inputField.textComponent.enabled = false;

        _scoreboard.Add(new ScoreboardEntry("STU", 9000));
        _scoreboard.Add(new ScoreboardEntry("DIO", 8000));
        _scoreboard.Add(new ScoreboardEntry("GOB", 7000));
        _scoreboard.Add(new ScoreboardEntry("OOO", 6000));
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


        if (_makePixels.GetHasSpawned() && _makePixels.getPixelCount() <= 0)
        {
            _gameplayState = GameplayState.DEAD;

            _scoreboard.Sort(new ScoreboardComparer());
            _scoreboard.Reverse();

            string scoreText = "SCORES:\n";
            foreach(ScoreboardEntry s in _scoreboard)
            {
                scoreText += s.Name + " .......... " + s.Score.ToString() + "\n";
            }
            _scoreboardTextContainer.text = scoreText;
        }
    }

    private void UpdateDead()
    {
        _gameOverText.enabled = true;
        _scoreboardTextContainer.enabled = true;
        _inputField.enabled = true;
        _inputField.textComponent.enabled = true;

        EventSystem.current.SetSelectedGameObject(_inputField.gameObject, null);

        if (Input.GetKey(KeyCode.Space))
        {
            _scoreboard.Add(new ScoreboardEntry(_inputField.text, _score));

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
