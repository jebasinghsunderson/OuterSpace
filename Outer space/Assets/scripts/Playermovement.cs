using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Playermovement : MonoBehaviour
{
    [SerializeField] 
    float speed;

   
    Vector2 KeyInput, minBound, maxBound;       
    bulletspawn bullet;
    private void Awake()
    {
      //  animator = GetComponent<Animator>
        bullet = GetComponent<bulletspawn>();   
    }
    void Start()
    {
        InsideBound();     
    }
    void Update()
    {
        Movement();
    }

    void InsideBound()
    {
        Camera camera = Camera.main;
        minBound = camera.ViewportToWorldPoint(new Vector2 (0,0));
        maxBound = camera.ViewportToWorldPoint(new Vector2(1,1));
    }
     void Movement()
    {
        Vector2 movement = KeyInput * speed * Time.deltaTime;
        Vector2 pos = new Vector2();

        pos.x=Mathf.Clamp(transform.position.x+movement.x, minBound.x + 0.8f, maxBound.x - 0.8f);
        pos.y = Mathf.Clamp(transform.position.y+movement.y, minBound.y + 2f, maxBound.y -5f);
        transform.position = pos;
    }

    void OnMove(InputValue value){
        KeyInput = value.Get<Vector2>();
        
    }
    void OnFire(InputValue value)
    {
        if (bullet != null)
        {
            bullet.isFiring = value.isPressed;
        }

    }

}
