using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArb : MonoBehaviour
{
    // Start is called before the first frame update
    public float health;
    private Animator animator;


    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    public void TakeDmg(float dmg)
    {
        health -= dmg;

        if (health <= 0) 
        {
            Dead();
        }
    }
    private void Dead()
    {
        animator.SetTrigger("Dead");
        GetComponent<Collider2D>().enabled = false;
        this.enabled = false;
    }
}
