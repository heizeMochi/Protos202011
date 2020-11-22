using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherShip : Mob
{
    public int line = 0;
    public List<GameObject> Ypos;

    void Update()
    {
        if (!isAlive || !GameManager.Instance.playing)
            return;
        if (DieCheck())
        {
            if (gameObject.CompareTag("RedTeam"))
            {
                GameManager.Defeat();
            }else if (gameObject.CompareTag("BlueTeam"))
            {
                GameManager.Victory();
            }
            Mob[] mob = GameObject.FindObjectsOfType<Mob>(true);
            for (int i = 0; i < mob.Length; i++)
            {
                mob[i].isAlive = false;
            }
        }
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
                ObjectPool.InstantiateMob<Unit>(this,stat.enemy, Define.MobType.One);
            }

            bool Spawn_Two = Input.GetKeyDown(KeyCode.Alpha2);

            if (Spawn_Two)
            {
                ObjectPool.InstantiateMob<Unit>(this, stat.enemy, Define.MobType.Two);
            }

            bool SpawnThree = Input.GetKeyDown(KeyCode.Alpha3);

            if (SpawnThree)
            {
                ObjectPool.InstantiateMob<Unit>(this, stat.enemy, Define.MobType.Three);
            }
            bool SpawnFour = Input.GetKeyDown(KeyCode.Alpha4);

            if (SpawnFour)
            {
                ObjectPool.InstantiateMob<Unit>(this, stat.enemy, Define.MobType.Four);
            }
            bool SpawnFive = Input.GetKeyDown(KeyCode.Alpha5);

            if (SpawnFive)
            {
                ObjectPool.InstantiateMob<Unit>(this, stat.enemy, Define.MobType.Five);
            }

        }
        transform.position = new Vector3(this.transform.position.x, Ypos[line].transform.position.y, 0);
    }
}
