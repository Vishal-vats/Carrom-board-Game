# Carrom-board-Game
It is Single-player 2D Carrom Game for Android Mobiles, in which you play against with the AI bot

How to Play:
-	Striker Shoot:

     o	Tap on Striker then release it after dragging backward
     
     o	The striker will go in opposite direction from where you drag
-	Striker Power:

     o	The more you drag the more the power for shoot 
-	Striker Movement:

     o	Below the Carrom Board there is slider from where you can change you initial position.

Instructions:
-	Match time is 2min
-	If you pot Queen you will get 2 points
-	If you  pot other pucks you will get 1 point 
-	You get one more chance after potting any puck

If you want to try this `Game Click on` https://github.com/Vishal-vats/Carrom-board-Game/releases/tag/v1.0 and download the Carrom.Game.zip file.

AI player:

It is a bot which can take simple Shots 
```
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
    ```
