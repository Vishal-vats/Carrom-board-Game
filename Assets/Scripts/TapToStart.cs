using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapToStart : MonoBehaviour
{
    [SerializeField]
    private GameObject _TaptoStartPanel;

    // Start is called before the first frame update
    void Start()
    {
        _TaptoStartPanel.SetActive(true);
        Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Time.timeScale = 1f;
            _TaptoStartPanel.SetActive(false);
        }

    }
}
