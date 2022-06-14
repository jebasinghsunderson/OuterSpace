using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletspawn : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float timeBetweenSpawn, firingRate, projectileLifetime, projectileSpeed;
    public bool isFiring=false;
    [SerializeField]
    bool isAI;
    Coroutine firingCoroutine;
    private void Start()
    {
        if (isAI) 
        {
            isFiring = true;
        }
       
    }
    void Update()
    {
        Fire();  
    }
    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            GameObject instance = Instantiate(projectilePrefab,
                                            transform.position,
                                            Quaternion.identity);

            Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = transform.up * projectileSpeed;
            }
            if (isAI)
            {
                rb.velocity = new Vector2 (rb.velocity.x , rb.velocity.y *-1);
            }
            Destroy(instance, projectileLifetime);
            yield return new WaitForSeconds(firingRate);
        }
    }


}
