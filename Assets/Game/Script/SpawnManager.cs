using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyShipPrefab;
    [SerializeField]
    private GameObject[] powerups;

    private GameManager _gameManager;
   
    // Start is called before the first frame update
 


    public void StartSpawnRoutines()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(EnemySpawnRoutine());
        StartCoroutine(PowerupSpawnRoutine());
    }
    //create a coroutine to spawn the Enemy every 5 seconds
    IEnumerator EnemySpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);
       while(_gameManager.gameOver==false)
        {
            Instantiate(enemyShipPrefab, new Vector3(Random.Range(-7f, 7f), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }
    }
    IEnumerator PowerupSpawnRoutine()
    {
        yield return new WaitForSeconds(3.0f);
        while (_gameManager.gameOver==false)
        {
            int randomPowerup = Random.Range(0, 3);
            Instantiate(powerups[randomPowerup], new Vector3(Random.Range(-7, 7), 7, 0), Quaternion.identity);
            yield return new WaitForSeconds(5.0f);
        }

    }

}
