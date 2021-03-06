﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : Mob
{
    bool canAttack = false;
    public Collider2D attackCollider;

    private void Update()
    {
        if (!GameManager.Instance.playing)
            return;
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
            switch (attackType)
            {
                case Define.AttackType.Cannon:
                    NormalAttack(AttackTarget);
                    break;
                case Define.AttackType.SplashCannon:
                    SplashAttack(AttackTarget);
                    break;
                default:
                    break;
            }
            canAttack = false;
        }
    }

    void SplashAttack(Mob mob)
    {
        SplashCannon cannon = Instantiate<SplashCannon>(Resources.Load<SplashCannon>("Prefabs/SplashCannon"), transform);
        cannon.transform.localPosition = Vector3.zero;
        cannon.transform.parent = null;
        cannon.attackDamage = Damage;
        cannon.attackTarget = mob.gameObject;
        AudioManager.instance.SoundPlay("explodemini");
    }
    void NormalAttack(Mob mob)
    {
        Cannon cannon = Instantiate<Cannon>(Resources.Load<Cannon>("Prefabs/Cannon"), transform);
        cannon.transform.localPosition = Vector3.zero;
        cannon.transform.parent = null;
        cannon.attackDamage = Damage;
        cannon.attackTarget = mob.gameObject;
        AudioManager.instance.SoundPlay("explodemini");
    }
}
