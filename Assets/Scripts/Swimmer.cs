using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Swimmer : MobBehavior
{
    public static bool SpawnPos;
    
    private void Update()
    {
        switch (myData.state)
        {
            case State.IDLE:
                IdleUpdate();
                break;
            case State.ATTACKING:
                AttackUpdate();
                break;
            case State.MOVING:
                TraceUpdate();
                break;
            case State.STAYING:
                break;
            default:
                break;
        }
        myData.SettingTeam(myData.team);
    }

    void IdleUpdate()
    {
    }

    void TraceUpdate()
    {
        MoveTo(myData.attackTarget.transform.position);

        float distance = (myData.attackTarget.transform.position - transform.position).magnitude;

        if (distance <= myData.defaultStat.attackRange)
        {
            StopAllCoroutines();
            myData.state = State.ATTACKING;
        }
    }

    void AttackUpdate()
    {
        Debug.Log("ATTACK");
    }
}