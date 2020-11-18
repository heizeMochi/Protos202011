using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> mobs;

    public int childShipCount;
    public GameObject childShip;
    public int enemyChildShipCount;
    public GameObject enemyChildShip;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PrefabInit(childShip, childShipCount);
        PrefabInit(enemyChildShip, enemyChildShipCount);
    }

    void PrefabInit(GameObject go, int count)
    {
        for (int i = 0; i < count; i++)
        {
            mobs.Add(Instantiate(go));
        }
    }

    public static void InstantiateMob<T>(Mob mother, bool Enemy) where T : Mob
    {
        for (int i = 0; i < instance.mobs.Count; i++)
        {
            Mob SpawnMob = instance.mobs[i].GetComponent<T>();

            if(SpawnMob.stat.enemy == mother.stat.enemy)
            {
                if (GameManager.jewelry < SpawnMob.stat.Jewelry)
                    return;
                instance.mobs.RemoveAt(i);
                SpawnMob.Init();
                GameManager.jewelry -= SpawnMob.Jewelry;
                SpawnMob.gameObject.SetActive(true);
                SpawnMob.transform.position = mother.transform.position;
                SpawnMob.isAlive = true;
                return;
            }
        }
    }

    public static void DestroyMob(GameObject go)
    {
        instance.mobs.Add(go);
        go.SetActive(false);
    }
}