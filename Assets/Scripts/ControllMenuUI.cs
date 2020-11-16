using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI 를 껏다켰다하기위해 만든 클래스
public class ControllMenuUI : MonoBehaviour
{
    ControllMenuUI instance;

    public static bool disEm = false;

    int selectMenu = 9;

    public Button[] buttons = new Button[9];
    public Image[] images = new Image[9];
    public Text[] texts = new Text[9];


    private void Start()
    {
        instance = this;
        for (int i = 0; i < buttons.Length; i++)
        {
            Transform tf = transform.GetChild(i);
            images[i] = tf.GetComponent<Image>();
            tf = tf.GetChild(0);
            buttons[i] = tf.GetComponent<Button>();
            tf = tf.GetChild(0);
            texts[i] = tf.GetComponent<Text>();
        }
    }

    // 현재 선택된 유닛의 layer를 검사해 어떤 타입의 유닛인지 검사후
    // 해당 유닛의 SpawnPos 을 활성화하여 소환위치를 받을 준비를 함
    public void SpawnPos()
    {
        if (GameManager.pickedMob.layer == 8)
        {
            MotherShip ship = GameManager.pickedMob.GetComponent<MotherShip>();
            ship.m_SpawnPos = true;
        }
        if (GameManager.pickedMob.layer == 9)
        {
            ChildShip ship = GameManager.pickedMob.GetComponent<ChildShip>();
            ship.c_SpawnPos = true;
        }
        if (GameManager.pickedMob.layer == 10)
        {

        }
    }

    // 초기화
    void Init()
    {
        for (int i = 0; i < selectMenu; i++)
        {
            images[i].gameObject.SetActive(false);
            buttons[i].onClick.RemoveAllListeners();
            texts[i].text = "";
        }
    }

    // 하선
    public void DisEmbark(MotherShip ship)
    {
        if (ship.embarker.Count == 0)
        {
            GameManager.pickedMob = null;
            return;
        }
        Init();
        for (int i = 0; i < ship.embarker.Count; i++)
        {
            images[i].gameObject.SetActive(true);
            buttons[i].onClick.AddListener(() => ship.DisEmbark(i - 1));
        }
        disEm = true;
    }

    // 취소
    public void CancleBtn()
    {
        GameManager.pickedMob = null;
        DirectorModel.move = false;
    }
    
    // 수리
    public void Repair(MotherShip ship)
    {
        ship.c_embarker.Clear();
        ship.isHealTime = 0f;
        for (int i = 0; i < ship.embarker.Count; i++)
        {
            ChildShip child = ship.embarker[i].GetComponent<ChildShip>();

            child.Repair();
            ship.c_embarker.Add(child);
        }
    }

    // GameManager.pickedMob ( 선택된 오브젝트 ) 가 있을때
    // 해당 gameObject의 layer값을 받아서 UI버튼을 초기화
    void Update()
    {
        if (GameManager.pickedMob != null)
        {
            if (GameManager.pickedMob.layer == 8 && disEm == false) // MotherShip
            {
                Init();
                MotherShip ship = GameManager.pickedMob.GetComponent<MotherShip>();
                if (ship.Enemy)
                    return;
                images[0].gameObject.SetActive(true);
                buttons[0].onClick.RemoveAllListeners();
                buttons[0].onClick.AddListener(SpawnPos);
                texts[0].text = "유닛생성";

                images[1].gameObject.SetActive(true);
                buttons[1].onClick.RemoveAllListeners();
                buttons[1].onClick.AddListener(ship.IsEmbark);
                texts[1].text = "승선";

                images[2].gameObject.SetActive(true);
                buttons[2].onClick.RemoveAllListeners();
                buttons[2].onClick.AddListener(() => DisEmbark(ship));
                texts[2].text = "하선";

                images[3].gameObject.SetActive(true);
                buttons[3].onClick.RemoveAllListeners();
                buttons[3].onClick.AddListener(() => DirectorModel.move = true);
                texts[3].text = "이동";

                images[4].gameObject.SetActive(true);
                buttons[4].onClick.RemoveAllListeners();
                buttons[4].onClick.AddListener(CancleBtn);
                texts[4].text = "취소";

                images[5].gameObject.SetActive(true);
                buttons[5].onClick.RemoveAllListeners();
                buttons[5].onClick.AddListener(() => Repair(ship));
                texts[5].text = "수리";

            }
            else if (GameManager.pickedMob.layer == 9) // ChildShip
            {
                Init();
                ChildShip ship = GameManager.pickedMob.GetComponent<ChildShip>();
                if (ship.Enemy)
                    return;
                images[0].gameObject.SetActive(true);
                buttons[0].onClick.RemoveAllListeners();
                buttons[0].onClick.AddListener(SpawnPos);
                texts[0].text = "유닛생성";

                images[3].gameObject.SetActive(true);
                buttons[3].onClick.RemoveAllListeners();
                buttons[3].onClick.AddListener(() => DirectorModel.move = true);
                texts[3].text = "이동";

                images[4].gameObject.SetActive(true);
                buttons[4].onClick.RemoveAllListeners();
                buttons[4].onClick.AddListener(CancleBtn);
                texts[4].text = "취소";
            }
            else if (GameManager.pickedMob.layer == 10) // Swimmer
            {
                Init();

                images[3].gameObject.SetActive(true);
                buttons[3].onClick.RemoveAllListeners();
                buttons[3].onClick.AddListener(() => DirectorModel.move = true);
                texts[3].text = "이동";

                images[4].gameObject.SetActive(true);
                buttons[4].onClick.RemoveAllListeners();
                buttons[4].onClick.AddListener(CancleBtn);
                texts[4].text = "취소";
            }
        }
        else
        {
            for (int i = 0; i < selectMenu; i++)
            {
                images[i].gameObject.SetActive(false);
            }
        }
    }
}
