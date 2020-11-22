﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Defficulty : MonoBehaviour
{
    public Transform selectImg;
    public List<Transform> select = new List<Transform>();
    public int sel = 0;

    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && sel != 2)
        {
            sel++;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && sel != 0)
        {
            sel--;
        }

        selectImg.position = new Vector2(selectImg.position.x, select[sel].position.y);

        if (Input.GetKeyDown(KeyCode.Return))
        {
            switch (sel)
            {
                case 0: // EASY
                    break;
                case 1: // NORMAL
                    break;
                case 2: // HARD
                    break;
            }
            SceneManager.LoadSceneAsync("GameScene");
        }
    }
}
