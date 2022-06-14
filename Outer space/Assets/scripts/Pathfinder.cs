using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    [SerializeField]
    Wavepoint wave;


    List<Transform> wavepoint ;
    Enemyspawn enemyspawn;
    int wavepointIndex = 0;

     void Awake()
    {
        enemyspawn = FindObjectOfType<Enemyspawn>();   
    }
    void Start()
    {
        wave= enemyspawn.GetCurrentWavepoint();
        wavepoint = wave.GetWaypoints();
        transform.position = wavepoint[wavepointIndex].position;
    }
   
    void Update()
    {
        FollowWayPoint();
    }
    public void FollowWayPoint()
    {
        if(wavepointIndex < wavepoint.Count)
        {
            Vector3 transformPos = wavepoint[wavepointIndex].position;
            float speed = wave.Getspeed() * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position,transformPos,speed);
            if(transform.position == transformPos)
            {
                wavepointIndex ++;
            }
        }
        else
        {
           Destroy(gameObject);

        }
    }
  
}
