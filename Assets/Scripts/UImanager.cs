using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    [SerializeField]
    private Text _player1scoreText;

    [SerializeField]
    private Text _player2ScoreText;

    [SerializeField]
    private GameObject _timeOverPaner;

    private int _scoreForPlayer;
    private int _scoreForAIplayer;

    private void Start()
    {
        _timeOverPaner.SetActive(false);
    }

    public void updatePlayer1Score()
    {
        _scoreForPlayer++;
        _player1scoreText.text = "Score: " + _scoreForPlayer;
    }

    public void updatePlayer2Score()
    {
        _scoreForAIplayer++;
        _player2ScoreText.text = "Score: " + _scoreForAIplayer;
    }

    public void showTimeOverPanel()
    {
        _timeOverPaner.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
