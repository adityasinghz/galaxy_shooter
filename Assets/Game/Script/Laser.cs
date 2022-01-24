using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]
    private float _speed=10.0f;
    private bool _isEnemyLaser = false;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (_isEnemyLaser == false)
        {
            MoveUp();
        }
        else
        {
            MoveDown();
        }
    }
    void MoveUp()
    {
        //move up at 10 speed   
        transform.Translate(Vector3.up * _speed * Time.deltaTime);
        //if position on the y of my laser is greater than or equal to 5.58
        //destroy the laser
        if (transform.position.y > 5.58f)
            Destroy(this.gameObject); //this means if this script(laser) is attached in
    }
    void MoveDown()
    {
        //move up at 10 speed   
        transform.Translate(Vector3.down * _speed * Time.deltaTime);
        //if position on the y of my laser is greater than or equal to 5.58
        //destroy the laser
        if (transform.position.y < -5.58f)
            Destroy(this.gameObject); //this means if this script(laser) is attached in
    }

    public void AssignEnemyLaser()
    {
        _isEnemyLaser = true;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player" && _isEnemyLaser)
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                player.Damage();
            }
            Destroy(this.gameObject);
        }
    }
}
