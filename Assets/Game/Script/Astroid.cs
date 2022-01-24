using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Astroid : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private float _rotateSpeed = 19f;
    [SerializeField]
    private GameObject _explosionPrefab;
    // Update is called once per frame
    void Update()
    {
       //Rotate the astroid
        transform.Rotate(Vector3.forward * _rotateSpeed * Time.deltaTime);
    }
    //check for Laser colllision (Trigger)
    //Instantiate explosion at the position of astroid (us)
    //destroy the explosion after 3 seconds
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Laser")
        {
            Instantiate(_explosionPrefab,transform.position,Quaternion.identity);
            Destroy(other.gameObject);
            Destroy(this.gameObject, 0.25f);
        }
    }
}
