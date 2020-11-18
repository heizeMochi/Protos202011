using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Borderline : MonoBehaviour
{
    public MotherShip mother;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag(gameObject.tag)){
            Mob mob = collision.GetComponent<Mob>();
            mother.HP -= mob.Damage;
            ObjectPool.DestroyMob(collision.gameObject);
        }
    }
}
