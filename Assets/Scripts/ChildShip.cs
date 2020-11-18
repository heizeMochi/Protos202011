using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildShip : Mob
{
    bool canAttack = false;
    public Collider2D attackCollider;

    private void Update()
    {
        AttackCoolDown();
        DieCheck();

        if (isAlive)
        {
            switch (state)
            {
                case Define.State.MOVING:
                    OnMoving();
                    break;
                case Define.State.ATTACK:
                    OnAttack();
                    break;
            }
        }
    }

    void OnMoving()
    {
        attackCollider.enabled = true;
        if (!stat.enemy)
        {
            transform.position
                = new Vector2
                (transform.position.x + (stat.moveSpeed * Time.deltaTime),
                transform.position.y);
        }
        else if(stat.enemy)
        {
            transform.position 
                = new Vector2
                (transform.position.x + -(stat.moveSpeed * Time.deltaTime),
                transform.position.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    void AttackCoolDown()
    {
        if (!canAttack)
        {
            attackCool += Time.deltaTime;
            if (attackCool >= attackSpeed)
            {
                attackCool = 0;
                canAttack = true;
            }
        }
    }

    void OnAttack()
    {
        if (AttackTarget == null)
        {
            state = Define.State.MOVING;
            return;
        }
        attackCollider.enabled = false;
        if(AttackTarget.gameObject.activeSelf == false)
        {
            AttackTarget = null;
            state = Define.State.MOVING;
        }
        if (canAttack)
        {
            Attack(AttackTarget);
            canAttack = false;
        }
    }

    void Attack(Mob enemyStat)
    {
        enemyStat.HP -= Damage;
    }
}
