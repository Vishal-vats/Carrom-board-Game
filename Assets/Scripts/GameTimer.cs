using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    [SerializeField]
    private Text _secondText;

    [SerializeField]
    private Text _minuteText;

    [SerializeField]
    private AudioClip _gameOverSound;

    private UImanager _uiManager;

    private int Seconds;
    private int minutes;
    bool _isGameOverSoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UImanager>();

        _secondText.text = Seconds.ToString();
        StartCoroutine(StartTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
        if(minutes == 2)
        {
            _uiManager.showTimeOverPanel();
            if (_isGameOverSoundPlayed == false)
            {
                AudioSource.PlayClipAtPoint(_gameOverSound, Camera.main.transform.position, 1f);
                _isGameOverSoundPlayed = true;
            }
            Time.timeScale = 0;
        }

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(1f);
        Seconds++;
        if(Seconds > 59)
        {
            minutes++;
            _minuteText.text = minutes.ToString();
            Seconds = 0;
        }
        Start();
    }

}
