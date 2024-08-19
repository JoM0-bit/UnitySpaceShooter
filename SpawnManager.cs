using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemyprefab;

    [SerializeField]
    private GameObject _Enemycontainer;

    [SerializeField]
    private bool isDead = false;

    [SerializeField]
    private GameObject[] powerups;

    [SerializeField]
    private GameObject[] Asteroids;

    [SerializeField]
    private Vector3[] SpawnPos;



    void Start()
    {
        //spawn bottom
        SpawnPos[0] = new Vector3(Random.Range(-9, 9), -6, 0);
        //Spawn right
        SpawnPos[1] = new Vector3(11, Random.Range(5.6f, -3.7f), 0);
        //spawn left
        SpawnPos[2] = new Vector3(-11, Random.Range(5.6f, -3.7f), 0);


        StartCoroutine(SpawnEnemyRoutine());
        StartCoroutine(SpawnPowerUpRoutine());
        StartCoroutine(SpawnAsterioidRoutine());
    }

    void Update()
    {

    }

    IEnumerator SpawnEnemyRoutine()
    {
        yield return new WaitForSeconds(1);
        while (isDead == false)
        {
            Vector3 PosOfSpawn = new Vector3(Random.Range(-9, 9), 8, 0);
            GameObject newEnemy = Instantiate(_Enemyprefab,PosOfSpawn,Quaternion.identity);
            newEnemy.transform.parent = _Enemycontainer.transform;
            yield return new WaitForSeconds(5f);
            

        }


    }

    IEnumerator SpawnPowerUpRoutine()
    {
        yield return new WaitForSeconds(5);
        while ( isDead == false)
        {
            Vector3 PosOfSpawn = new Vector3(-Random.Range(-9, 9),7,0);
            int randomPowerUp = Random.Range(0, 3);
            GameObject newPowerUp = Instantiate(powerups[randomPowerUp], PosOfSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(15,25));
        }
    }

    IEnumerator SpawnAsterioidRoutine()
    {
        //add cap to how many is spawning
        while(isDead == false)
        {
            int randomLocation = Random.Range(0, 3);
            int randomAsteriod = Random.Range(0, 3);
            GameObject newAsteriod = Instantiate(Asteroids[randomAsteriod], SpawnPos[randomLocation], Quaternion.identity);
            newAsteriod.gameObject.GetComponent<Asteroid>().updateMovment(randomLocation);
            yield return new WaitForSeconds(Random.Range(5,25));
        }
    }

    public void OnPlayerDeath()
    {
        isDead = true;
    }

}
