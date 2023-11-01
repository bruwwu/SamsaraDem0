using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttributeMng : MonoBehaviour
{
    public float maxHealth = 100;
    public float health;
    public int attack;

    public void TakeDmg(int amount)
    {
        health -= amount;

        if(health <= 0)
        {
            Die();
        }
    }

    public void DealDmg(GameObject target)
    {
        var atm = target.GetComponent<AttributeMng>();
        if (atm != null )
        {
            atm.TakeDmg(attack);
        }

    }
    void Die()
    {
        Debug.Log("Muerto");
        //Llamar animacion de muerte
        //Desactivar enemigo o jugardor
    }
}
