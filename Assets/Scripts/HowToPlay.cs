using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HowToPlay : MonoBehaviour
{
    [SerializeField]
    SceneChange ch;
    [SerializeField]
    GameObject[] textList;

    [SerializeField]
    Text page;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            GameObject on = null, off = null;

            for (int i = 0; i < textList.Length; i++)
            {
                if (!textList[i].activeSelf)
                {
                    off = textList[i];
                    page.text = $"<- {i + 1}/2 ->";
                }
                else if (textList[i].activeSelf)
                    on = textList[i];
            }

            off.SetActive(true);
            on.SetActive(false);
        }
        else if (Input.GetKeyDown(KeyCode.Escape))
        {
            foreach (var item in ch.selectmenu)
            {
                item.SetActive(true);
            }
            gameObject.SetActive(false);
            ch.ui = false;
        }
    }
}
