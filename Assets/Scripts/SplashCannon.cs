using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashCannon : MonoBehaviour
{
    public int attackDamage;
    CircleCollider2D Col;
    public GameObject attackTarget;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == attackTarget)
        {
            Debug.Log("SPLASH");
            Col = GetComponent<CircleCollider2D>();
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            List<GameObject> target = new List<GameObject>();

            for (int i = 0; i < col.Length; i++)
            {
                if(col[i].gameObject.tag == attackTarget.tag)
                {
                    target.Add(col[i].gameObject);
                }
            }

            for (int i = 0; i < target.Count; i++)
            {
                Mob mob = target[i].GetComponent<Mob>();
                mob.anim.SetTrigger("Hit");
                mob.HP -= attackDamage;
            }
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(transform.position, attackTarget.transform.position, speed);
    }
}