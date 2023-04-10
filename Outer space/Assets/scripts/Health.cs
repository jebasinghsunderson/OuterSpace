using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;

   [SerializeField] int health = 10,score =50;
    [SerializeField] ParticleSystem particle;
    [SerializeField] bool WillShake = false;

    AudioSound audioSound;
    ScoreKeeper scoreKeeper;
    CameraShake camera;
    startGame loadScene;
     void Awake()
    {
        loadScene = FindObjectOfType<startGame>();
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        audioSound = FindObjectOfType<AudioSound>();
        camera =Camera.main.GetComponent<CameraShake>();    
    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        DamageDealer missile = collider.GetComponent<DamageDealer>();
        if(missile != null)
        {
            missile.Hit();
            PlayParticle();
            Shake();
            audioSound.DamageTakenClip();
            TakeDamage(missile.GetAmountOfDamage());
        }
    }
    public int GetHealth()
    {
        return health;
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Die();
        }
    }
    public void Die()
    {
        if (!isPlayer)
        {
            scoreKeeper.IncreaseScore(score);
        }
        else
        {
            loadScene.EndScene();
        }
        Destroy(gameObject);
    }
    void PlayParticle()
    {
        ParticleSystem instance = Instantiate(particle,transform.position,Quaternion.identity,transform);
        Destroy(instance,instance.main.duration);
      
    }
    void Shake()
    {
        if(camera!=null && WillShake)
        {
            camera.Play();
        }
    }
}
