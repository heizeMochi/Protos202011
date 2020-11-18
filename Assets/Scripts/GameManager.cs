using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text jewelryText;

    public static int jewelry;
    public int maxJewlry;

    public float jewelryTime = 1;
    float elapsedTime = 0;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if(elapsedTime >= jewelryTime && jewelry < maxJewlry)
        {
            elapsedTime = 0;

            jewelry++;
        }

        jewelryText.text = $"{jewelry} / {maxJewlry}";
    }
}
