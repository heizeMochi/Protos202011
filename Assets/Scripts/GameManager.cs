using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    bool left = false, right = false;

    public float SpawnTime;

    public Text jewelryText;
    public Text TimeText;

    public GameObject victory, defeat;

    public bool playing = false;

    [Tooltip("제한시간설정 : 해당 시간이 0이되면 게임패배")]
    public float time = 120;

    public static int jewelry;
    [Tooltip("보석의 최대보유가능갯수")]
    public int maxJewlry;

    [Tooltip("몇 초당 보석 획득할것인가")]
    public float jewelryTime = 1;
    [Tooltip("보석을 몇개씩 획득할것인가.")]
    public int getJewelry = 1;
    float elapsedTime = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playing = true;
        switch (AudioManager.instance.deffi)
        {
            case Define.Defficulty.Easy:
                time = 60;
                SpawnTime = 2f;
                getJewelry = 2;
                break;
            case Define.Defficulty.Normal:
                time = 80;
                SpawnTime = 1f;
                getJewelry = 2;
                break;
            case Define.Defficulty.Hard:
                time = 120;
                SpawnTime = 1.5f;
                getJewelry = 1;
                break;
        }
    }

    private void Update()
    {
        if (!playing)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadSceneAsync("Title");
                AudioManager.instance.backGround.UnPause();
                AudioManager.instance.effectSound = 0.03f;
            }
            return;
        }
        time -= Time.deltaTime;
        int i_time = Convert.ToInt32(time);
        TimeText.text = i_time.ToString();

        if (i_time == 0)
            Defeat();

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            left = true;
        else if (Input.GetKeyDown(KeyCode.RightArrow))
            right = true;

        if (left && right)
        {
            left = false;
            right = false;
            if (jewelry >= maxJewlry)
            {
                jewelry = maxJewlry;
                AudioManager.instance.SoundPlay("Failed");
                return;
            }
            jewelry += getJewelry;
            if (jewelry > maxJewlry)
                jewelry = maxJewlry;
            AudioManager.instance.SoundPlay("Coin");
        }
        jewelryText.text = $"{jewelry} / {maxJewlry}";
    }

    public static void Victory()
    {
        AudioManager.instance.backGround.Pause();
        AudioManager.instance.SoundPlay("Victory");
        Instance.playing = false;
        Instance.victory.SetActive(true);
    }

    public static void Defeat()
    {
        AudioManager.instance.backGround.Pause();
        AudioManager.instance.effectSound = 0.15f;
        AudioManager.instance.SoundPlay("Defeat");
        Instance.playing = false;
        Instance.defeat.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        playing = false;
    }
}
