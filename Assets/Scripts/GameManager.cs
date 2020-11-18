using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Text jewelryText;

    public GameObject victory, defeat;

    bool playing = true;

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
        instance.victory.SetActive(true);
    }

    public static void Defeat()
    {
        instance.defeat.SetActive(true);
    }
}
