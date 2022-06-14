using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemyspawn : MonoBehaviour
{
    Wavepoint currentwave;
    [SerializeField]
    List<Wavepoint> NoOfWaves;

    [SerializeField] 
    float TimBetWave;
    [SerializeField]
    bool isLooping = true;
    void Start()
    {
        StartCoroutine(SpawnEnemyWave());
    }
    public Wavepoint GetCurrentWavepoint()
    { 
    return currentwave;
    }

    IEnumerator SpawnEnemyWave()
    {
        do
        {
            foreach (Wavepoint wave in NoOfWaves)
            {
                currentwave = wave;
                for (int i = 0; i < currentwave.GetEnemyCount(); i++)
                {
                    Instantiate(currentwave.GetEnemyIndex(i),
                        currentwave.GetFirstWayPoint().position,
                        Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentwave.RandomTimebetweenSpawn());
                }
                yield return new WaitForSeconds(TimBetWave);
            }
        } while (isLooping==true);
      
        
    }
}
