using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectUI : MonoBehaviour
{
    public Mob[] mobs;
    public Image[] MobIconObj;
    public Sprite[] sprite;
    public Text[] JewelryText;

    private void Update()
    {
        for (int i = 0; i < JewelryText.Length; i++)
        {
            JewelryText[i].text = mobs[i].stat.Jewelry.ToString();
        }
    }
}
