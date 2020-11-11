using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChildShip : MobBehavior
{
    public GameObject SpawnSwimmerUI;
    public GameObject MotherShip;
    Button btn;
    public bool c_SpawnPos = false;

    void Update()
    {
        if (c_SpawnPos)
        {
            if (Input.GetMouseButtonDown(0))
            {
                c_SpawnPos = false;
                Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ObjectPool.PoolInstantiate<Swimmer>(ObjectPool.instance.Swimmer_Prefab, new Vector3(vec.x, vec.y, 0), myData.team);
                GameManager.pickedMob = null;
            }
        }

        if (isEmbark)
        {
            MoveTo(MotherShip.transform.position);
        }
        myData.SettingTeam(myData.team);

        AttackTargetSetting();
    }



    public void SwimmerSpawn()
    {
        c_SpawnPos = true;
    }
}