using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text jewelryText;
    public Text TimeText;

    public GameObject victory, defeat;

    public bool playing = true;

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
        instance = this;
    }

    //void Update()
    //{
    //    if (!playing)
    //        return;
    //    time -= Time.deltaTime;
    //    int i_time = Convert.ToInt32(time);
    //    TimeText.text = i_time.ToString();

    //    if (i_time == 0)
    //        Defeat();

    //    elapsedTime += Time.deltaTime;

    //    if(elapsedTime >= jewelryTime && jewelry + getJewelry < maxJewlry)
    //    {
    //        elapsedTime = 0;

    //        jewelry += getJewelry;
    //    }else if(elapsedTime >= jewelryTime && jewelry + getJewelry >= maxJewlry)
    //    {
    //        elapsedTime = 0;

    //        jewelry = maxJewlry;
    //    }

    //    jewelryText.text = $"{jewelry} / {maxJewlry}";

    //}

    private void Update()
    {
        if (!playing)
            return;
        time -= Time.deltaTime;
        int i_time = Convert.ToInt32(time);
        TimeText.text = i_time.ToString();

        if (i_time == 0)
            Defeat();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (jewelry >= maxJewlry)
                return;
                jewelry += getJewelry;
        }
        jewelryText.text = $"{jewelry} / {maxJewlry}";
    }

    public static void Victory()
    {
        instance.playing = false;
        instance.victory.SetActive(true);
    }

    public static void Defeat()
    {
        instance.playing = false;
        instance.defeat.SetActive(true);
    }
}
