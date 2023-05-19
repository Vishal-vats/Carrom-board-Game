using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    private UImanager _uiManager;
    private GameManager _gameManager;
    private AudioSource _collectPuckSound;

    public Board_striker _player;
    public AIplayer _AIplayer;

    private void Start()
    {
        _collectPuckSound = GetComponent<AudioSource>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.transform.tag == "Pucks")
        {
            if(_player.enabled == true)
            {
                _uiManager.updatePlayer1Score();
                _collectPuckSound.Play();
                if (other.transform.name == "queen")
                {
                    _uiManager.updatePlayer1Score();
                }
                Destroy(other.gameObject);
                _player._isplayerScored = true;
                _gameManager.resetisPlayerScoredboolValue(); //reset player position.

            }
            if(GameObject.FindGameObjectWithTag("AIplayer") != null)
            {
                _uiManager.updatePlayer2Score();
                _collectPuckSound.Play();
                if (other.transform.name == "queen")
                {
                    _uiManager.updatePlayer2Score();
                }
                Destroy(other.gameObject);
                _gameManager._isPlayerAIscored = true;
                Invoke("respawnAIplayer", 2f); // Delay in spawning AI player.
                StartCoroutine(_gameManager.DelayinDestroyingAIPlayerWhenScored()); // Destroy AI player
                Invoke("resetIsPlayerScoredValue", 3f);
            }


        }
    }

    private void respawnAIplayer()
    {
        _gameManager.SpawnAIplayer(); // respawn AI player to its position
    }

    private void resetIsPlayerScoredValue()
    {
        _gameManager._isPlayerAIscored = false;
    }

}
