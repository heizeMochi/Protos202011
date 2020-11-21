﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public Mob[] mobs;
    public Image[] MobIconObj;
    public Sprite[] sprites;
    public Text[] JewelryText;

    private void Start()
    {
        for (int i = 0; i < MobIconObj.Length; i++)
        {
            MobIconObj[i].sprite = sprites[i];
        }
    }

    private void Update()
    {
        for (int i = 0; i < JewelryText.Length; i++)
        {
            JewelryText[i].text = mobs[i].stat.Jewelry.ToString();
        }
        for (int i = 0; i < MobIconObj.Length; i++)
        {
            if (mobs[i].stat.Jewelry > GameManager.jewelry)
            {
                MobIconObj[i].color = Color.black;
            }
            else
            {
                MobIconObj[i].color = Color.white;
            }
        }
    }
}
