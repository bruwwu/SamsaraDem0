using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    Slider healthBar;
    TMP_Text healthText;

    public float maxHealth = 100;
    public float health;

    void Start()
    {
        healthBar.value = maxHealth;
        health = healthBar.value;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            healthBar.value -= 5f;
            health = healthBar.value;
        }
    }

    void Update()
    {
        healthText.text = health.ToString() + " %"; 
    }
   
}
