using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    void Init()
    {
        for (int i = 0; i < selectMenu; i++)
        {
            images[i].gameObject.SetActive(false);
            buttons[i].onClick.RemoveAllListeners();
            texts[i].text = "";
        }
    }

    public void DisEmbark(MotherShip ship)
    {
        MotherShip mother = GameManager.pickedMob.GetComponent<MotherShip>();
        Init();
        for (int i = 0; i < mother.embarker.Count; i++)
        {
            images[i].gameObject.SetActive(true);
            buttons[i].onClick.AddListener(() => mother.DisEmbark(i - 1));
        }
        disEm = true;
    }

    public void CancleBtn()
    {
        GameManager.pickedMob = null;
        DirectorModel.move = false;
    }

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
