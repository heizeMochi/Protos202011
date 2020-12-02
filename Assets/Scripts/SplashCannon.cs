using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashCannon : MonoBehaviour
{
    Animator anim;
    public int attackDamage;
    CircleCollider2D Col;
    public GameObject attackTarget;
    public float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == attackTarget)
        {
            anim = GetComponent<Animator>();
            Col = GetComponent<CircleCollider2D>();
            Collider2D[] col = Physics2D.OverlapCircleAll(transform.position, 0.5f);
            List<GameObject> target = new List<GameObject>();

            for (int i = 0; i < col.Length; i++)
            {
                if(col[i].gameObject.tag == attackTarget.tag)
                {
                    if (col[i].gameObject.layer == 8)
                        continue;
                    target.Add(col[i].gameObject);
                }
            }

            for (int i = 0; i < target.Count; i++)
            {
                Mob mob = target[i].GetComponent<Mob>();
                mob.anim.SetTrigger("Hit");
                mob.HP -= attackDamage;
                anim.SetTrigger("Explosion");
            }
        }
    }

    private void Start()
    {
        Destroy(gameObject, 1f);
    }

    private void Update()
    {
        if (attackTarget != null)
        {
            transform.position = Vector3.Lerp(transform.position, attackTarget.transform.position, 1f * speed * Time.deltaTime);
        }
    }
}