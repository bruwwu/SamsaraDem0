using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControl : MonoBehaviour
{
    private Animator animator;
    public Transform AttackPoint;
    public LayerMask enemyLayers;

    public int attackD = 6;
    public float attackRange = 0.5f;
   
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    public float CritDmg = 0f;
    public float CritChance = 0f;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Attack()
    {
        animator.SetTrigger("Attack");
        Collider2D[] DealDmg = Physics2D.OverlapCircleAll(AttackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in DealDmg)
        {
            enemy.GetComponent<EnemyArb>().TakeDmg(attackD);
        }
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        if (AttackPoint == null)
            return;

        Gizmos.DrawSphere(AttackPoint.position, attackRange);
    }
}
