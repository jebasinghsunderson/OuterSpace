using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] float magnitude = 1f;
    [SerializeField] float duration = 1f;

    [SerializeField] Vector3 initialPos;
    
    void Start()
    {
      initialPos = transform.position;
    }
    public void Play()
    {
        StartCoroutine(Shake());
    }
    IEnumerator Shake() 
    {
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            transform.position = initialPos + (Vector3)Random.insideUnitCircle * magnitude;
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = initialPos;
    }
}
