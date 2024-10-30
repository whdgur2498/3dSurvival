using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    public PlayerController controller;
    public PlayerCondition condition;

    public ItemData itemData;
    public Action additem;

    private void Awake()
    {
        CharacterManager.Instance.Player = this; 
        controller = GetComponent<PlayerController>();
        condition = GetComponent<PlayerCondition>();
    }
}
