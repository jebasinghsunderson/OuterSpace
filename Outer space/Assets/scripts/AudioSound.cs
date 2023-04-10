using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSound : MonoBehaviour
{
    [SerializeField] AudioClip shootingSound, DamageSound;
    [SerializeField] [Range(0f,1f)] float Volume = 1f, DamageVolume = 1f;

    void Awake()
    {
        SingletonAudio();

    }
    void SingletonAudio()
    {
        int instance = FindObjectsOfType(GetType()).Length;
        if (instance > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
            DontDestroyOnLoad(gameObject);

    }
    public void PlayshootingClip()
    {
        if (shootingSound != null)
        {
            AudioSource.PlayClipAtPoint(shootingSound, Camera.main.transform.position,Volume);
        }
    }
    public void DamageTakenClip()
    {
        if(DamageSound != null)
        {
            AudioSource.PlayClipAtPoint(DamageSound, Camera.main.transform.position, DamageVolume);
        }
    }
}
