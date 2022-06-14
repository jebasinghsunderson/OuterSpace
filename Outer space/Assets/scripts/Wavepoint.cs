using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave", fileName ="new Way point")]
public class Wavepoint : ScriptableObject
{
   [SerializeField] 
    Transform path;

    [SerializeField]
    List<GameObject> enemyprefab;

    [SerializeField]
    int speed = 5;

    [SerializeField]
    float timeBetweenSpawn = 1f,  minRange = 0.2f,  speedofSpawn = 0f;

    public int GetEnemyCount()
    {
        return enemyprefab.Count;
    }
    public GameObject GetEnemyIndex(int index)
    {
        return enemyprefab[index];
    }
    public Transform GetFirstWayPoint()
    {
        return path.GetChild(0);
    }
    public List<Transform> GetWaypoints()
    {
        List<Transform> waypoints = new List<Transform>();   
        foreach (Transform child in path)
        {
            waypoints.Add(child);
        }
        return waypoints;
    }
    public int Getspeed()  
    { 
        return speed;
    }
    public float RandomTimebetweenSpawn()
    {
        speedofSpawn = Random.Range(timeBetweenSpawn+minRange,timeBetweenSpawn-minRange);
        return Mathf.Clamp(speedofSpawn,minRange, timeBetweenSpawn + minRange);
    }
}
