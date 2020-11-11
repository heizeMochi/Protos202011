using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="MobStats", menuName ="Create Mob Stats", order =0)]

/// <summary>
/// MOb의 기본값을 정의입니다.
/// </summary>
public class MobStats : ScriptableObject
{
    public int HP;
    public float moveSpeed;
    public float ATK;
    public float atk_coolDownTick;
    public float atk_actionTick;
    public float attackRange;
}
