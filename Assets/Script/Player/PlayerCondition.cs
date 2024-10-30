using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageIbe
{
    void TakePhsicalDamage(int damage);
}

public class PlayerCondition : MonoBehaviour, IDamageIbe
{
    public UICondition uiCondition;

    Condition health { get { return uiCondition.health; } }

    Condition hunger { get { return uiCondition.hunger; } }

    Condition stamina { get { return uiCondition.stamina; } }

    public float noHungerHealthDecay;

    public event Action onTakeDamage;

    void Update()
    {
        hunger.Subtract(hunger.passiveValue * Time.deltaTime);
        stamina.Add(stamina.passiveValue * Time.deltaTime);

        if(hunger.curValue == 0f)
        {
            health.Subtract(noHungerHealthDecay * Time.deltaTime);
        }

        if(health.curValue == 0f)
        {
            Die();
        }
    }

    public void Heal(float amout)
    {
        health.Add(amout);
    }

    public void Eat(float amout) 
    {
        hunger.Add(amout);
    }

    public void Die()
    {
        Debug.Log("�׾���!");
    }

    public void TakePhsicalDamage(int damage)
    {
        health.Subtract(damage);
        onTakeDamage?.Invoke();
    }
}
