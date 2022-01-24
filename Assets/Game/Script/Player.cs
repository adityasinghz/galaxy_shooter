using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public bool canTripleShot = false;
    public bool isSpeedBoostActive = false;
    public bool shieldsActive=false;
    public bool isPlayerOne = false;
    public bool isPlayerTwo = false;

    public int lives = 3;
    [SerializeField]
    private GameObject _explosionPrefab;
    [SerializeField]
    private GameObject _laserPrefab;
    [SerializeField]
    private GameObject _tripleShotPrefab;
    [SerializeField]
    private GameObject _shieldGameObject;
    [SerializeField]
    private GameObject _left_Engine,_rightEngine;
    [SerializeField]
    private float _fireRate=0.25f;
    private float _canFire=0.0f;
    
    //fireRate is 0.25f
    //canFire---has the amount of time between firing passed?

    [SerializeField]
    private float _speed=5.0f;

    private UIManager _uiManager;
    private GameManager _gameManager;
    private SpawnManager _spawnManager;
    //variable to store the audio clip
    [SerializeField]
    private AudioClip _laserSoundClip;
    [SerializeField]
    private AudioSource _audioSource;

    private void Start()
    {
    
 
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        _audioSource = GetComponent<AudioSource>();

        if(_uiManager!=null)
        {
            _uiManager.UpdateLives(lives);
        }
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("Spawn_Manager").GetComponent<SpawnManager>();

       /* if(_spawnManager!=null)
        {
            _spawnManager.StartSpawnRoutines();
        }
       */
       if(_audioSource==null)
        {
            Debug.LogError("AudioSource on the player is Null!");
        }
       else
        {
            _audioSource.clip = _laserSoundClip;
        }
        if (_gameManager.isCoopMode == false)
        {
            transform.position = new Vector3(0, 0, 0);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (isPlayerOne == true)
        {
            Movement();
            if (Input.GetKeyDown(KeyCode.Space))
                Shoot();
        }
        if(isPlayerTwo==true)
        {
            //  PlayerTwoMovement();
            PlayerTwoMovement();
            //if space key pressed
            //spawn laser at player position
            if (Input.GetKeyDown(KeyCode.G))
                Shoot();
            //spawn my laser

        }
    }
private void Shoot()
{  
    //if tripleshoot shoots 
    //shoot 3 lasers
    //else 
    //shoot 1 laser
    if(Time.time>_canFire){
        if(canTripleShot==true){
          /*  //left
            Instantiate(_laserPrefab,transform.position + new Vector3(0.55f,0.06f,0),Quaternion.identity);
            //center
               Instantiate(_laserPrefab,transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
            //right
            Instantiate(_laserPrefab,transform.position + new Vector3(-0.55f,0.06f,0),Quaternion.identity);
            */
            Instantiate(_tripleShotPrefab,transform.position,Quaternion.identity);
        }
 else       {      
            Instantiate(_laserPrefab,transform.position + new Vector3(0,0.88f,0),Quaternion.identity);
             }
            _canFire=Time.time+_fireRate;
    }
        _audioSource.Play();
    //play the laser audio clip
}



private void Movement()
{
    
 

     //if speed boost enabled
     //move 1.5x the normal speed
     //else
     //move normal speed
     if(isSpeedBoostActive==true){
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed * 1.5f);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed * 1.5f);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed * 1.5f);
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed * 1.5f);
            }
        }


    else{
            if (Input.GetKey(KeyCode.W))
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
            }
            if(Input.GetKey(KeyCode.A))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }
        }
    
    //if player on the y is greater than 0
    //set player position to 0
    if(transform.position.x>9.07f)
    transform.position=new Vector3(9.07f,transform.position.y,0);
    if(transform.position.x<-9)
    transform.position=new Vector3(-9,transform.position.y,0);
    if(transform.position.y>4.2f)
    transform.position=new Vector3(transform.position.x,4.2f,0);
    if(transform.position.y<-4.3f)
    transform.position=new Vector3(transform.position.x,-4.2f,0);
}

    private void PlayerTwoMovement()
    {
       
        //if speed boost enabled
        //move 1.5x the normal speed
        //else
        //move normal speed
        //Updated
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        if (isSpeedBoostActive == true)
        {
           // if (Input.GetKey(KeyCode.UpArrow))
            if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed*1.5f);
            }
           // if (Input.GetKey(KeyCode.RightArrow))
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed*1.5f);
            }
          //  if (Input.GetKey(KeyCode.DownArrow))
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed*1.5f);
            }
          //  if (Input.GetKey(KeyCode.LeftArrow))
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed*1.5f);
            }
        }


        else
        {
           // if (Input.GetKey(KeyCode.UpArrow))
           if (Input.GetKey(KeyCode.Keypad8))
            {
                transform.Translate(Vector3.up * Time.deltaTime * _speed);
            }
            //if (Input.GetKey(KeyCode.RightArrow))
            if (Input.GetKey(KeyCode.Keypad6))
            {
                transform.Translate(Vector3.right * Time.deltaTime * _speed);
            }
           // if (Input.GetKey(KeyCode.DownArrow))
            if (Input.GetKey(KeyCode.Keypad5))
            {
                transform.Translate(Vector3.down * Time.deltaTime * _speed);
            }
          //  if (Input.GetKey(KeyCode.LeftArrow))
            if (Input.GetKey(KeyCode.Keypad4))
            {
                transform.Translate(Vector3.left * Time.deltaTime * _speed);
            }
        }

        //if player on the y is greater than 0
        //set player position to 0
        if (transform.position.x > 9.07f)
            transform.position = new Vector3(9.07f, transform.position.y, 0);
        if (transform.position.x < -9)
            transform.position = new Vector3(-9, transform.position.y, 0);
        if (transform.position.y > 4.2f)
            transform.position = new Vector3(transform.position.x, 4.2f, 0);
        if (transform.position.y < -4.3f)
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
    }

    public void Damage()
    {
        //subtract 1 life from the player
        //donot subtract if shield collides with player
        //do nothing
        if (shieldsActive == true)
        {
            shieldsActive = false;
            _shieldGameObject.SetActive(false);
            return;
        }
        lives--;
        if(lives==2)
        {
            _left_Engine.SetActive(true);
        }
        else if(lives==1)
        {
            _rightEngine.SetActive(true);
        }
        _uiManager.UpdateLives(lives);
       // if lives < 1 (meaning 0 )
       //Destroy the player object
       if (lives <1)
        {
            Instantiate(_explosionPrefab, transform.position, Quaternion.identity);
            _gameManager.gameOver = true;
            _uiManager.ShowTitleScreen();
            _uiManager.CheckForBestkills();
            Destroy(this.gameObject);
        }
    }
public void TripleShotPowerupOn()
{
    canTripleShot=true;
    StartCoroutine(TripleShotPowerDownRoutine());
}
 //method to triple shot powerup 
 public void SpeedBoostPowerupOn()
 {
//coroutine method (ienumerator) to powerdown the speed boost
isSpeedBoostActive=true;
StartCoroutine(SpeedBoostPowerDownRoutine());
 }
 
    public void EnableShields()
    {
        shieldsActive=true;
        _shieldGameObject.SetActive(true);
    }
public IEnumerator TripleShotPowerDownRoutine()   //necessary for Coroutine
{
    yield return new WaitForSeconds(5.0f);
    canTripleShot = false; 
}
public IEnumerator SpeedBoostPowerDownRoutine()
{
    yield return new WaitForSeconds(5.0f);
    isSpeedBoostActive = false;
}
}
