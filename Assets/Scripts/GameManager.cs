using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject _playerAI;
    public Board_striker _player;
    public GameObject _sliderOfPlayer;
    [SerializeField]
    private GameObject _AIspawnPoint;
    private AIplayer _aiPlayerScript;
    GameObject spawnedAIplayer;

    Vector3 newAIspawnPos;

    public bool _isPlayerAIscored = false;
    

    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("AIplayer") != null)
        {
            _aiPlayerScript = GameObject.FindGameObjectWithTag("AIplayer").GetComponent<AIplayer>(); 
        }

        if(GameObject.FindGameObjectWithTag("AIplayer") == null)
        {
            _aiPlayerScript = null;
        }
        //if(_player._isplayerScored == true)
        //{
        //    StartCoroutine(_player.resetStriker());
        //    _player._isplayerScored = false;
        //}
        //else
        //{
        //    _player.gameObject.SetActive(false);
        //    newAIspawnPos.x = Random.Range(-1.82f, 1.82f);
        //    Instantiate(_playerAI.gameObject, newAIspawnPos, Quaternion.identity);
        //}

        //if(_playerAI._isAIplayerScored == true)
        //{
        //    newAIspawnPos.x = Random.Range(-1.82f, 1.82f);
        //    Instantiate(_playerAI.gameObject, newAIspawnPos, Quaternion.identity);
        //    _playerAI._isAIplayerScored = false;
        //}
        //else
        //{

        //    Destroy(_playerAI.gameObject);
        //    _player.gameObject.SetActive(true);
        //}
    }

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

    //public void AIplayer()
    //{
    //    SpawnAIplayer();
        
    //}


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
            StartCoroutine(changeTurnToPlayer());
        }
    }
    

    public IEnumerator DelayinDestroyingAIPlayerWhenScored()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(spawnedAIplayer.gameObject);
    }

    IEnumerator changeTurnToPlayer()
    {
        yield return new WaitForSeconds(0.5f);
        _sliderOfPlayer.SetActive(true);
        activatePlayerScript();
    }

}
