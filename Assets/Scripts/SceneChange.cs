using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour
{
    public GameObject go;
    public GameObject how;

    public Transform select;

    public GameObject[] selectmenu;

    [SerializeField]
    Transform[] Pos;

    int row = 0;

    public bool ui = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow) && row != 2 && !ui)
        {
            row += 1;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow) && row != 0 && !ui)
        {
            row -= 1;
        }

        select.position = Pos[row].position;

        if (Input.GetKeyDown(KeyCode.Return) && !ui)
        {
            if (row == 0)
            {
                foreach (var item in selectmenu)
                {
                    item.SetActive(false);
                }
                go.SetActive(true);
                ui = true;
            }else if(row == 1)
            {
                foreach (var item in selectmenu)
                {
                    item.SetActive(false);
                }
                how.SetActive(true);
                ui = true;
            }else if(row == 2)
            {
                Application.Quit();
            }
        }

    }
}
