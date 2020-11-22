using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject go;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            go.SetActive(true);
        }
    }
}
