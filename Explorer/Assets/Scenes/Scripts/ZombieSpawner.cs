using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] int enemyCount = 0;
    [SerializeField] int waveMaxEnemyCount = 2;
    [SerializeField] int time = 0;
    [SerializeField] GameObject spawnerLocation;
    [SerializeField] int firstEnemyMaxChange= 4;
    [SerializeField] int secondEnemyMaxChange = 6;
    [SerializeField] int thirdEnemyMaxChange = 8;
    [SerializeField] int fourthEnemyMaxChange = 10;
    [SerializeField] int fifthEnemyMaxChange = 12;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Timer());
    }

    // Update is called once per frame
    void Update()
    {
        ChangeMaxEnemies();
        SpawnEnemies();
    }
    private void ChangeMaxEnemies()
    {
        if (time <= 30)
        {
            return;
        }
        else if (time <= 60)
        {
            waveMaxEnemyCount = firstEnemyMaxChange;
        }
        else if (time <= 90)
        {
            waveMaxEnemyCount = secondEnemyMaxChange;
        }
        else if (time <= 105)
        {
            waveMaxEnemyCount = thirdEnemyMaxChange;
        }
        else if (time <= 120)
        {
            waveMaxEnemyCount = fourthEnemyMaxChange;
        }
        else if (time >= 135)
        {
            waveMaxEnemyCount = fifthEnemyMaxChange;
        }
        else { Debug.Log("Timer error"); }
    }
    private void SpawnEnemies()
    {
        if (enemyCount >= waveMaxEnemyCount){return;}
        else
        {
            Instantiate(enemyPrefab, spawnerLocation.transform.position, Quaternion.identity);
            enemyCount++;
        }
    }

    private IEnumerator Timer()
    {
        while(true)
        {
            time++;
            yield return new WaitForSeconds(1);
        }

    }
}
