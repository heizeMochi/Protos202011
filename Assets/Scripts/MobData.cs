using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MobType { SHIP, SWIMMER }
public enum State { IDLE, ATTACKING, MOVING, STAYING }
/// <summary>
/// 몹의 정보를 저장하는 class입니다.
/// 이 class는 상속을 고려하며 작성하므로, 내부에서 start나 update문은 사용금지입니다.
/// 사용하려고 하신다면 상속을 받는 말단 class에서 사용해 주세요!
/// </summary>
public class MobData : MonoBehaviour
{
    public int ID;
    public Team team;
    public MobStats defaultStat;

    public int HP;
    public int MaxHP;
    public int RepairHP;
    public int RepairGold;
    public float moveSpeed;
    public float ATK;
    public float atk_coolDownTick;
    public float atk_actionTick;
    public float embarkDistance;
    public Transform attackTarget = null;

    public List<Transform> enemyList;

    public bool isDead = false;
    public MobType mobtype;
    public State state = State.IDLE;

    private void Start()
    {
        InitStats();
    }
    /*/////////////////////////////////
    ///
    /// public Method
    /// 
    /////////////////////////////////*/
    public void SetState(State value)
    {
        this.state = value;
    }
    public void SettingTeam(Team _team)
    {
        team = _team;
        enemyList.Clear();
        switch (_team)
        {
            case Team.RED:
                foreach (var item in GameManager.blueTeam)
                {
                    enemyList.Add(item);
                }
                break;
            case Team.BLUE:
                foreach (var item in GameManager.redTeam)
                {
                    enemyList.Add(item);
                }
                break;
        }
    }
    public void InitStats()
    {
        if (defaultStat is null) Debug.LogError("DefaultStat info is null in MobData");
        HP = defaultStat.HP;
        moveSpeed = defaultStat.moveSpeed;
        ATK = defaultStat.ATK;
        atk_actionTick = defaultStat.atk_actionTick;
        atk_coolDownTick = defaultStat.atk_coolDownTick;
        MaxHP = defaultStat.MaxHP;
        RepairHP = defaultStat.RepairHP;
        RepairGold = defaultStat.RepairGold;
    }
}
