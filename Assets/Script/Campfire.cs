using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Campfire : MonoBehaviour
{
    public int damage;
    public float damageRate;

    List<IDamageIbe> things = new List<IDamageIbe>();

    void Start()
    {
        InvokeRepeating("DealDamage", 0, damageRate);
    }

    void DealDamage() 
    {
        for (int i = 0; i < things.Count; i++) 
        {
            things[i].TakePhsicalDamage(damage);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IDamageIbe damageIbe)) 
        {
            things.Add(damageIbe);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IDamageIbe damageIbe)) 
        {
            things.Remove(damageIbe);
        }
    }
}
