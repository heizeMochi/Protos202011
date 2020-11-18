using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : MonoBehaviour
{
    public int line = 0;
    public List<GameObject> Ypos;
    public bool enemy;

    void Update()
    {
        MotherShipInput();
    }

    void MotherShipInput()
    {
        if (!enemy)
        {
            bool Upkey = Input.GetKeyDown(KeyCode.UpArrow);
            bool Downkey = Input.GetKeyDown(KeyCode.DownArrow);
            if (Upkey && line < 2)
            {
                line++;
            }
            else if (Downkey && line > 0)
            {
                line--;
            }
            transform.position = new Vector3(this.transform.position.x, Ypos[line].transform.position.y, 0);
        }
    }
}
