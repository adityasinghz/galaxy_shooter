using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    [SerializeField]
    private float _speed=3.0f;
    [SerializeField]
    private int powerupID;//0 = tripleshot 1 = speed boost , 2 =  shield
    // Start is called before the first frame update
    [SerializeField]
    private AudioClip _clip;

    // Update is called once per frame
    void Update()
    {
      transform.Translate(Vector3.down*Time.deltaTime*_speed);   
        if(transform.position.y<-7)
        {
            Destroy(this.gameObject);
        }
    }

    //Script Communication
      //turn the triple shot bool to true
        //destroy our selves
        //handle to the component
        //access to the component 
    private void OnTriggerEnter2D(Collider2D other)  // To Identify that which object is collided with our triple shot object
    {
        Debug.Log("Collided with: "+ other.name);
        //access the player
        if(other.tag=="Player"){  //Player is a tagname
       
        Player player=other.GetComponent<Player>();  //how the object will collide

         AudioSource.PlayClipAtPoint(_clip, transform.position);
        if(player!=null){ 
              //we enabled triple shot
        //player.canTripleShot = true;
        //if powerupid=0
        if(powerupID==0)
        player.TripleShotPowerupOn(); 

        if(powerupID==1)
        {
        //enable speed booster        
        player.SpeedBoostPowerupOn();}

        if(powerupID==2){
                    player.EnableShields();
                }

        
        //enable shields
        }
      //  StartCoroutine(player.TripleShotPowerDownRoutine());
         //destroyed triple shot
        Destroy(this.gameObject);
       

        }

    
    }
}
