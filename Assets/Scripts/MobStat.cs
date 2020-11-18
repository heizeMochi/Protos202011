using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MobStats", menuName = "CreateStat", order =0)]

public class MobStat : ScriptableObject
{
    public int HP;
    public int MaxHP;
    public int Damage;

    public float moveSpeed;
    public float attackSpeed;
}