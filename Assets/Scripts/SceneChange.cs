using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public Text PressEnter;
    public GameObject go;

    public bool ui = false;

    bool Light = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && ui == false)
        {
            PressEnter.color = new Color(1, 1, 1, 0);
            go.SetActive(true);
            ui = true;
        }
        TextLight();
    }

    void TextLight()
    {
        if (ui == false)
        {
            if (PressEnter.color.a <= 0.3f)
                Light = true;
            else if (PressEnter.color.a >= 1f)
                Light = false;
            if (Light)
            {
                PressEnter.color = new Color(1, 1, 1, PressEnter.color.a + 0.5f * Time.deltaTime);
            }
            else
            {
                PressEnter.color = new Color(1, 1, 1, PressEnter.color.a - 0.5f * Time.deltaTime);
            }
        }
    }
}
