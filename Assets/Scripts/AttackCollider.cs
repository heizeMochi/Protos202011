using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackCollider : MonoBehaviour
{
    public Mob root;
    bool enemy;

    private void Start()
    {
        enemy = root.stat.enemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Mob>() != null)
        {
            if (collision.gameObject.layer == 8)
                return;
            if (collision.GetComponent<Mob>().stat.enemy != enemy)
            {
                root.AttackTarget = collision.GetComponent<Mob>();
                root.state = Define.State.ATTACK;
            }
        }
    }
}
