using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AIplayer : MonoBehaviour
{
    [SerializeField]
    private AudioSource _pushSoundWhenForceApplied;
    
    private Rigidbody2D _rigidbody;
    public GameObject[] _allPucks;
    private GameManager _gameManager;


    Vector3 direction;
    float force;

    void Awake()
    {
        _pushSoundWhenForceApplied= GetComponent<AudioSource>(); ;
        _gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        _rigidbody = GetComponent<Rigidbody2D>(); 

        
        int i = Random.Range(0, _allPucks.Length);
        
        while (_allPucks[i] == null)
        {
            i = Random.Range(0, _allPucks.Length);
        }

        GameObject _pucks = _allPucks[i];
        direction = (_pucks.transform.position - transform.position);
        Debug.Log(direction);
        force = Random.Range(1f, 1.8f) * 350;

        StartCoroutine(applyForce());
        // Check whether AI player scored or not. communicating game Manager script.

    }

    IEnumerator applyForce()
    {
        yield return new WaitForSeconds(1f);
        _pushSoundWhenForceApplied.Play();
        _rigidbody.AddForce(direction * force);

        yield return new WaitForSeconds(4.5f);
        _gameManager.checkforTurn();
        _gameManager.destroyAIPlayer();
    }
        

}
