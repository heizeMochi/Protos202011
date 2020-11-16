using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// 자식선이 담고 있는 정보

public class ChildShip : MobBehavior
{
    public GameObject SpawnSwimmerUI;
    public GameObject MotherShip;

    Button btn;
    public bool c_SpawnPos = false;

    // 하선 시 isHeal을 비활성화
    private void OnEnable()
    {
        isHeal = false;
    }

    void Update()
    {
        // c_SpawnPos 가 활성화 되어있을때 마우스클릭을 하면
        // c_SpawnPos 를 비활성화 -> 해당 위치에 Swimmer 소환 -> GameManager.pickedMob을 null로
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

        // MotherShip 에게 승선명령이 떨어지면 해당 MotherShip에게 이동
        if (isEmbark)
        {
            MoveTo(MotherShip.transform.position);
        }
        myData.SettingTeam(myData.team);

        //AttackTargetSetting();
    }

    public void Repair()
    {
        if (myData.HP >= myData.MaxHP)
            return;
        isHeal = true;
    }

    public void SwimmerSpawn()
    {
        c_SpawnPos = true;
    }

    // ChildShip의 MobData를 외부에서 접근하기위한 프로퍼티
    public MobData Data
    {
        get
        {
            return myData;
        }
    }
}