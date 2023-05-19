using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _playerAI;
    public GameObject _sliderOfPlayer;
    public Board_striker _player;

    private GameObject spawnedAIplayer;

    [SerializeField]
    private GameObject _AIspawnPoint;

    Vector3 newAIspawnPos;

    public bool _isPlayerAIscored = false;
   

    public void resetisPlayerScoredboolValue()
    {
        Invoke("playerscoreValue", 4f);
    }

    private void playerscoreValue()
    {
        _player._isplayerScored = false;
    }

    public void deactivatePlayerScript()
    {
        _player.enabled = false;
    }

    public void activatePlayerScript()
    {
        _player.enabled = true;
    }

    public void SpawnAIplayer()
    {
        newAIspawnPos = _AIspawnPoint.transform.position;
        newAIspawnPos.x = Random.Range(-1.8f, 1.8f);
        spawnedAIplayer = Instantiate(_playerAI, newAIspawnPos, Quaternion.identity);
    }

    public void destroyAIPlayer()
    {
        Destroy(spawnedAIplayer.gameObject);
    }

    public void checkforTurn()
    {
        if(_isPlayerAIscored == false)
        {
            changeTurnToPlayer();
        }
    }
    
    public IEnumerator DelayinDestroyingAIPlayerWhenScored()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(spawnedAIplayer.gameObject);
    }

    private void changeTurnToPlayer()
    {
        _sliderOfPlayer.SetActive(true);
        activatePlayerScript();
    }

}
