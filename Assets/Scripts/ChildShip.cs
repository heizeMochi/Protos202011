using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildShip : Mob
{
    bool canAttack = false;

    private void Update()
    {
        AttackCoolDown();
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

    void OnMoving()
    {
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
            stat.attackCool += Time.deltaTime;
            if (stat.attackCool >= stat.attackSpeed)
            {
                stat.attackCool = 0;
                canAttack = true;
            }
        }
    }

    void OnAttack()
    {
        if (canAttack)
        {
            Attack(AttackTarget);
            canAttack = false;
        }
    }

    void Attack(Mob enemyStat)
    {
        enemyStat.stat.HP -= stat.Damage;
    }
}
