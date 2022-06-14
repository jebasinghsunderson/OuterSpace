using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int amountOfDamage;
    public int GetAmountOfDamage()
    {
        return amountOfDamage;
    }
    public void Hit()
    {
        Destroy(gameObject);
    }
}
