using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyExplosionPrefab;
    //variable for Enemy's speed
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip _clip;
    private float _speed = 3.0f;
    [SerializeField]
    private GameObject _laserPrefab;
    private UIManager _uiManager;
    private float _fireRate = 3.0f;
    private float _canFire=-1;
    void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
      

    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        if(Time.time>_canFire)
        {
            _fireRate = Random.Range(3f , 7f);
            _canFire = Time.time + _fireRate;
           GameObject enemyLaser= Instantiate(_laserPrefab, transform.position, Quaternion.identity);
            Laser[] lasers = enemyLaser.GetComponentsInChildren<Laser>();
            for(int i=0;i<lasers.Length;i++)
            {
                lasers[i].AssignEnemyLaser();
            }
         
        }
    }

    void CalculateMovement()
    {
        //move down
        transform.Translate(Vector3.down * _speed * Time.deltaTime);

        //when off the screen on the bottom
        //respawn back on top with a new x position between the bounds of the screen
        if (transform.position.y < -7)
        {
            float randomX = Random.Range(-7f, 7f);
            transform.position = new Vector3(randomX, 7, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        
        if (other.tag == "Laser")
        {
            Destroy(other.gameObject); //Destroys Laser
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            _uiManager.UpdateScore();
            AudioSource.PlayClipAtPoint(_clip, transform.position,10000f);
            Destroy(this.gameObject);  //Destroys Enemy
        }
      else if (other.tag == "Player")
        {
            Player player = other.GetComponent<Player>();
            //Player explosion audio
     

            if(player != null)
            {
                player.Damage();

            }
            Instantiate(_enemyExplosionPrefab, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(_clip, transform.position);
            Destroy(this.gameObject); //Destroys Player
            
        }

    }
}
