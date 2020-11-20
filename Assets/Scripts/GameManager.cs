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

    public float time = 120;

    public static int jewelry;
    public int maxJewlry;

    public float jewelryTime = 1;
    float elapsedTime = 0;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (!playing)
            return;
        time -= Time.deltaTime;
        int i_time = Convert.ToInt32(time);
        TimeText.text = i_time.ToString();

        if (i_time == 0)
            Defeat();

        elapsedTime += Time.deltaTime;

        if(elapsedTime >= jewelryTime && jewelry < maxJewlry)
        {
            elapsedTime = 0;

            jewelry++;
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
