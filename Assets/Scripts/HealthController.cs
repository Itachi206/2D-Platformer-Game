﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int playerHealth;
    private int maximumHelath;
    [SerializeField] private Image[] hearts;

    private void Start()
    {
        UpdateHealth();
    }

    public void UpdateHealth()
    {
        for (int i = 0; i < hearts.Length; i++)
            {
            if (i < playerHealth)
            {
                hearts[i].color = Color.red;
            }
            else
            {
                hearts[i].color = Color.black;
            }
        }
    }
}
