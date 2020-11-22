using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MobStats", menuName = "CreateStat", order =0)]

public class MobStat : ScriptableObject
{
    public Define.AttackType attackType = Define.AttackType.Cannon;

    public int HP;
    public int MaxHP;
    public int Damage;

    public bool enemy;

    public int Jewelry;

    public float moveSpeed;
    public float attackSpeed;
    public float attackCool;
}