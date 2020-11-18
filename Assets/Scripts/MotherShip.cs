using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : Mob
{
    public int line = 0;
    public List<GameObject> Ypos;

    void Update()
    {
        if (stat.enemy)
            return;

        MotherShipInput();
    }

    void MotherShipInput()
    {
        if (!stat.enemy)
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

            bool Spawn_One = Input.GetKeyDown(KeyCode.Alpha1);

            if (Spawn_One)
            {
                ObjectPool.InstantiateMob<ChildShip>(this,stat.enemy);
            }
            transform.position = new Vector3(this.transform.position.x, Ypos[line].transform.position.y, 0);
        }
    }
}
