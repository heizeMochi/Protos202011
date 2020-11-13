using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public static GameObject objectPool;

    public List<MotherShip> MotherShip_Prefab;
    public List<ChildShip> ChildShip_Prefab;
    public List<Swimmer> Swimmer_Prefab;

    public List<GameObject> gos;

    private void Start()
    {
        instance = this;
        Init();
    }

    public void Init()
    {
        objectPool = gameObject;
        PrefabInit<MotherShip>(MotherShip_Prefab);
        PrefabInit<ChildShip>(ChildShip_Prefab);
        PrefabInit<Swimmer>(Swimmer_Prefab);
    }

    private void Update()
    {
    }

    public void Destroy(Transform mob)
    {
        if (objectPool == null)
            instance.Init();

        mob.gameObject.SetActive(false);
        mob.transform.SetParent(objectPool.transform);
        mob.localPosition = Vector2.zero;
        GameManager.RemoveMob(mob);
    }

    public void DisEmbark(List<Transform> embarker, int index , GameObject mother) 
    {
        GameObject go = embarker[index].gameObject;
        embarker[index].gameObject.SetActive(true);
        embarker[index].position = mother.transform.position + Vector3.one;
        go.transform.parent = null;
        embarker[index].GetComponent<ChildShip>().isEmbark = false;
        embarker.RemoveAt(index);

        GameManager.RemoveMob(go.transform);
    }

    public void PrefabInit<T>(List<T> obj) where T : MobBehavior
    {
        for (int i = 0; i < obj.Count; i++)
        {
            gos.Add(Instantiate<GameObject>(obj[i].gameObject, transform) as GameObject);
            gos[i].transform.localPosition = Vector2.zero;
            gos[i].SetActive(false);
        }
    }

    public static void PoolInstantiate<T>(List<T> obj, Vector3 vec, Team team) where T : MobBehavior
    {
        for (int i = 0; i < instance.gos.Count; i++)
        {
            if(instance.gos[i].GetComponent<T>() != null && instance.gos[i].activeSelf == false && instance.gos[i].GetComponent<T>().isEmbark == false)
            {
                instance.gos[i].SetActive(true);
                instance.gos[i].transform.position = vec;
                instance.gos[i].transform.parent = null;
                instance.gos[i].GetComponent<MobData>().SettingTeam(team);
                GameManager.AddMob(team, instance.gos[i].transform);
                return;
            }
        }
        Debug.ScrollLog("생성불가");
    }
}