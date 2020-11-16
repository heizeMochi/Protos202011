using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 몹의 스텟
[CreateAssetMenu(fileName ="MobStats", menuName ="Create Mob Stats", order =0)]

/// <summary>
/// MOb의 기본값을 정의입니다.
/// </summary>
public class MobStats : ScriptableObject
{
    public int HP;
    public int MaxHP;
    public int RepairHP;
    public int RepairGold;
    public float moveSpeed;
    public float ATK;
    public float atk_coolDownTick;
    public float atk_actionTick;
    public float attackRange;
    public float repairTime;
}
