using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<GameObject> mobs;

    public int unit_one_Count;
    public GameObject unit_one;
    public GameObject unit_one_enemy;

    public int unit_two_Count;
    public GameObject unit_two;
    public GameObject unit_two_enemy;

    public int unit_three_Count;
    public GameObject unit_three;
    public GameObject unit_three_enemy;

    public int unit_four_Count;
    public GameObject unit_four;
    public GameObject unit_four_enemy;

    public int unit_five_Count;
    public GameObject unit_five;
    public GameObject unit_five_enemy;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PrefabInit(unit_one, unit_one_Count);
        PrefabInit(unit_one_enemy, unit_one_Count);

        PrefabInit(unit_two, unit_two_Count);
        PrefabInit(unit_two_enemy, unit_two_Count);

        PrefabInit(unit_three, unit_three_Count);
        PrefabInit(unit_three_enemy, unit_three_Count);

        PrefabInit(unit_four, unit_four_Count);
        PrefabInit(unit_four_enemy, unit_four_Count);

        PrefabInit(unit_five, unit_five_Count);
        PrefabInit(unit_five_enemy, unit_five_Count);
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
            
            Mob SpawnMob;
            if ((SpawnMob = instance.mobs[i].GetComponent<T>()) == null)
                continue;
        if (SpawnMob.stat.enemy == mother.stat.enemy)
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