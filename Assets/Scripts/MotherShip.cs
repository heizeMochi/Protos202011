using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotherShip : MobBehavior, IShipBehavior
{
    public GameObject spawnChildShipUI;
    Button btn;

    public readonly int MAXIMUM_EMBARKER = 3;
    public List<Transform> embarker = new List<Transform>();
    public List<ChildShip> c_embarker = new List<ChildShip>();

    public bool m_SpawnPos;
    public static bool EmbarkSelect = false;

    public float isHealTime = 0;

    void Update()
    {
        isHealTime += Time.deltaTime;
        SpawnClick();
        EmbarkClick();
        Repair();

        myData.SettingTeam(myData.team);
    }

    void SpawnClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (m_SpawnPos)
            {
                Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                if (myData.embarkDistance < Vector3.Distance(transform.position, vec))
                {
                    Debug.ScrollLog("소환 가능한 최대거리를  초과하였습니다.");
                    return;
                }
                m_SpawnPos = false;
                ObjectPool.PoolInstantiate<ChildShip>(ObjectPool.instance.ChildShip_Prefab, new Vector3(vec.x, vec.y, 0), myData.team);
                GameManager.pickedMob = null;
            }
        }
    }

    void Repair()
    {
        for (int i = 0; i < c_embarker.Count; i++)
        {
            if (c_embarker[i].isHeal && isHealTime >= c_embarker[i].Data.defaultStat.repairTime)
            {
                if (c_embarker[i].Data.HP + c_embarker[i].Data.RepairHP > c_embarker[i].Data.MaxHP)
                {
                    //TODO 현재체력 + 회복체력이 최대체력보다 높은경우
                    continue;
                }

                if (GameManager.instance.Jewelry > c_embarker[i].Data.RepairGold)
                {
                    //TODO 돈이 부족할 경우
                    break;
                }
                c_embarker[i].Data.HP += c_embarker[i].Data.RepairHP;
                GameManager.instance.Jewelry -= c_embarker[i].Data.RepairGold;
            }
        }
        isHealTime = 0;
    }

    void EmbarkClick()
    {
        if (isEmbark)
        {
            if (GameManager.EmbarkMob == null && !EmbarkSelect)
            {
                EmbarkSelect = true;
            }

            else if (!EmbarkSelect && GameManager.EmbarkMob != null)
            {
                ChildShip ship = GameManager.EmbarkMob.GetComponent<ChildShip>();
                ship.MotherShip = gameObject;
                ship.isEmbark = true;
                isEmbark = false;
                GameManager.EmbarkMob = null;
            }
        }
    }

    public void IsEmbark()
    {
        isEmbark = true;
    }

    public void ChildShipSpawn()
    {
        m_SpawnPos = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.GetComponent<ChildShip>() != null)
        {
            ChildShip data = collision.gameObject.GetComponent<ChildShip>();
            if (data.GetComponent<MobData>().team == myData.team)
            {
                Embark(collision.transform);
                GameManager.pickedMob = null;
                EmbarkSelect = false;
            }
        }
    }

    //하선시키기
    public void DisEmbark(int index)
    {
        if (embarker.Count == 0)
        {
            Debug.ScrollLog("하선 시킬 수 있는 유닛이 없습니다.");
            return;
        }
        ObjectPool.instance.DisEmbark(embarker, index, this.gameObject);
        ControllMenuUI.disEm = false;
    }

    //승선 시키기
    public void Embark(Transform mob)
    {
        if ((embarker.Count + 1) <= MAXIMUM_EMBARKER)
        {
            embarker.Add(mob);
            ObjectPool.instance.Destroy(mob);
        }
        else Debug.ScrollLog("승선인원 초과! 탑승 불가");
            //TODO UI에 탑승 못했다고 표시

    }
    public void Embark(List<Transform> mobs)
    {
        int repeat = 0;

        //최대 승선인원 - 현재 승선인원 = 남은 자리 수
        //남은 자리수 - 탑승하려는 인원 = 탑승 못한 인원
        if ((MAXIMUM_EMBARKER - embarker.Count - mobs.Count) > 0) //탑승못한 인원이 있으면...
        {
            repeat = MAXIMUM_EMBARKER - embarker.Count;
            Debug.ScrollLog("승선인원 초과! " + repeat + "명만 탑승합니다.");

            //TODO UI에 탑승 못했다고 표시
        }
        else repeat = mobs.Count;

        for (int i = 0; i < repeat; i++)
        {
            embarker.Add(mobs[i]);
        }
    }
}
