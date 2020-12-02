using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int attackDamage;
    public float speed;
    public Animator anim;
    public GameObject attackTarget { get; set; }
    

    private void OnEnable()
    {
        Destroy(gameObject, 1f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == attackTarget)
        {
            Mob mob = attackTarget.GetComponent<Mob>();
            mob.anim.SetTrigger("Hit");
            mob.HP -= attackDamage;
            anim.SetTrigger("Explosion");
        }
    }

    private void Update()
    {
        transform.position = Vector3.Lerp(this.transform.position, attackTarget.transform.position, 1f * speed * Time.deltaTime);
    }
}
