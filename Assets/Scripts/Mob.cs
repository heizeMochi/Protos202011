using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Define.State state = Define.State.MOVING;
    public bool isAlive = false;
    public MobStat stat;
    public Mob AttackTarget;
    public Animator anim;
    protected Define.AttackType attackType = Define.AttackType.Cannon;


    public int HP, MaxHP, Damage, Jewelry;
    public float attackSpeed;
    public float attackCool;

    protected bool DieCheck()
    {
        if(HP <= 0)
        {
            isAlive = false;
            ObjectPool.DestroyMob(gameObject);
            return true;
        }
        return false;
    }

    private void OnDisable()
    {
        AudioManager.instance.SoundPlay("Scream");
    }

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        HP = stat.HP;
        MaxHP = stat.MaxHP;
        Damage = stat.Damage;
        Jewelry = stat.Jewelry;
        attackSpeed = stat.attackSpeed;
        attackCool = stat.attackCool;
        anim = transform.GetComponent<Animator>();
        attackType = stat.attackType;
        AttackTarget = null;
    }
}
