using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mob : MonoBehaviour
{
    public Define.State state = Define.State.MOVING;
    public MobStat stat;
    public Mob AttackTarget;
}
