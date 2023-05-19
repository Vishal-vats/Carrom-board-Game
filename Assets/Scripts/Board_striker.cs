using System.Collections;
using UnityEngine;

public class Board_striker : MonoBehaviour
{
    public bool _isplayerScored = false;
    private bool _strikerForce;

    [SerializeField]
    private Transform _lookAtPoint;

    [SerializeField]
    private SlideBar _slidebar;

    [SerializeField]
    private GameManager _gameManager;

    [SerializeField]
    private AudioSource _strikerSoundWhenForceApplied;

    private Rigidbody2D _rigid;
    private Vector3 _direction;
    private Vector3 _initialPos;
    RaycastHit2D hitInfo;

    private void Awake()
    {
        _strikerSoundWhenForceApplied = GetComponent<AudioSource>();
        _slidebar = GameObject.Find("SlideBar").GetComponent<SlideBar>();
        _initialPos = transform.position;
        _rigid = GetComponent<Rigidbody2D>();
    }


    private void OnMouseDrag()
    {
        Camera main = Camera.main;

        hitInfo = Physics2D.Raycast(main.ScreenToWorldPoint(Input.mousePosition), Vector3.up);

        

        if (hitInfo.transform.name == "Striker")
        {
            _strikerForce = true;
        }

        if (_strikerForce)
        {
            _lookAtPoint.LookAt(hitInfo.point);
            float distance = Vector3.Distance(transform.position, hitInfo.point);
            distance = Mathf.Clamp(distance, 0f, 1.8f);
            
            _lookAtPoint.localScale = new Vector3(distance + 0.5f, distance + 0.5f, distance + 0.5f);
        }
    }

    private void OnMouseUp()
    {
        _direction = new Vector3(hitInfo.point.x - transform.position.x, hitInfo.point.y - transform.position.y, 0);
        _direction = Vector3.ClampMagnitude(_direction, 2f);
        _rigid.AddForce(-_direction * 20, ForceMode2D.Impulse);

        _strikerSoundWhenForceApplied.Play();

        _strikerForce = false;
        _lookAtPoint.localScale = Vector3.zero;

        StartCoroutine(_slidebar.resetSlidePos()); // reset slider position
        StartCoroutine(resetStriker()); // reset Player Striker Position
        StartCoroutine(CheckIsScored());

    }

    IEnumerator CheckIsScored()
    {
        yield return new WaitForSeconds(3.7f);
        if(_isplayerScored == false)
        {
            _gameManager.SpawnAIplayer(); // cummunicate to Game Manager Script to Instantiate the AI player.
            _gameManager.deactivatePlayerScript();
            _slidebar.gameObject.SetActive(false);
            
        }
    }

    public IEnumerator resetStriker()
    {
        yield return new WaitForSeconds(3.4f);
        transform.position = _initialPos;
        _rigid.velocity = Vector2.zero;
       
    }
}
