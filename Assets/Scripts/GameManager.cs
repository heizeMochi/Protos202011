using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// 게임의 시스템 정보를 담을 클래스
public enum Team { RED, BLUE };
public class GameManager : MonoBehaviour
{
    public Camera _camera;
    public GameObject texture;
    public GameObject CommandUI;

    public int Jewelry;

    public static GameObject EmbarkMob;
    public static List<List<Transform>> everyMobList;
    public static List<Transform> redTeam;
    public static List<Transform> blueTeam;
    public static GameManager instance;
    public static GameObject selectedMob; // 마우스를 올렸을 때 사용하는 기능
    public static GameObject pickedMob; //마우스로 클릭 했을 때  


    private void Awake()
    {
        everyMobList = new List<List<Transform>>();
        redTeam = new List<Transform>();
        blueTeam = new List<Transform>();
        RegistTeam();
        CreateSingleton();

    }

    void Start()
    {
        MobData[] ships = GameObject.FindObjectsOfType<MobData>();
        for (int i = 0; i < ships.Length; i++)
        {
            AddMob(ships[i].team, ships[i].transform);
            ships[i].SettingTeam(ships[i].team);
        }
    }


    void Update()
    {
        // pickedMob ( 선택된 몹이 ) null이 아니라면
        // 해당 몹을 확대해서 보여주는 UI를 켜주고
        // null이라면 해당 UI를 끔
        if (pickedMob!=null && !MotherShip.EmbarkSelect)
        {
            _camera.enabled = false;
            _camera.transform.position = new Vector3(pickedMob.transform.position.x , pickedMob.transform.position.y, -1);
            _camera.enabled = true;
            texture.SetActive(true);
            CommandUI.SetActive(true);
        }
        else
        {
            _camera.enabled = false;
            texture.SetActive(false);
            CommandUI.SetActive(false);
        }
    }

    /*/////////////////////////////////
    ///
    /// public Method
    /// 
    /////////////////////////////////*/
    

    //오브젝트 픽킹
    //TODO UI에 pick된 상태인 object정보를 뿌려 주는 메소드

    //TODO UI에 select된 상태인 object를 하이라이팅해주는 메소드






    /*/////////////////////////////////
    ///
    /// public Static Method
    /// 
    /////////////////////////////////*/

    // 몹의 팀을 받아와서 해당 팀에 맞는 tag로 지정, 해당 팀의 List에 Transform 정보를 입력
    public static void AddMob(Team team, Transform obj)
    {
        switch (team)
        {
            case Team.RED:
                obj.tag = "RedTeam";
                redTeam.Add(obj);
                break;
            case Team.BLUE:
                obj.tag = "BlueTeam";
                blueTeam.Add(obj);
                break;
        }
    }

    // Transform obj를 입력받아 해당 유닛의 MobData.team에 접근하여 Team정보를 받아서
    // 레드팀인지 블루팀인지 확인 후
    // 해당 팀의 리스트를 순회하여 리스트에서 Remove시켜줌
    public static void RemoveMob(Transform obj)
    {
        Team team = obj.GetComponent<MobData>().team;

        switch (team)
        {
            case Team.RED:
                for (int i = 0; i < redTeam.Count; i++)
                {
                    if (redTeam[i] == obj)
                        redTeam.RemoveAt(i);
                }
                break;
            case Team.BLUE:
                for (int i = 0; i < blueTeam.Count; i++)
                {
                    if (blueTeam[i] == obj)
                        blueTeam.RemoveAt(i);
                }
                break;
        }
    }

    public static void SelectObj(GameObject obj) => selectedMob = obj;
    public static void UnSelectObj(GameObject obj) => selectedMob = null;
    public static void PickObj(GameObject obj) => pickedMob = obj;
    public static bool UnPickObj(GameObject obj)
    {
        if (ReferenceEquals(pickedMob, obj))
        {
            pickedMob = null;
            return true;
        }
        else return false;
    }
    public static void UnPickObj() => pickedMob = null;


    /*/////////////////////////////////
    ///
    /// private Method
    /// 
    /////////////////////////////////*/

    private void CreateSingleton()
    {
        if (instance is null) instance = this;
        else Destroy(this);
    }

    private void RegistTeam()
    {
        everyMobList.Add(blueTeam);
        everyMobList.Add(redTeam);
    }
}
