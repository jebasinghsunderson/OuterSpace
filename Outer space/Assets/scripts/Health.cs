using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
   [SerializeField] int health = 10;
    [SerializeField] ParticleSystem particle;
     void OnTriggerEnter2D(Collider2D collider)
    {
        DamageDealer missile = collider.GetComponent<DamageDealer>();
        if(missile != null)
        {
            missile.Hit();
            PlayParticle();
            TakeDamage(missile.GetAmountOfDamage());
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
    void PlayParticle()
    {
        ParticleSystem instance = Instantiate(particle,transform.position,Quaternion.identity,transform);
        Destroy(instance,instance.main.duration);
    }
}
