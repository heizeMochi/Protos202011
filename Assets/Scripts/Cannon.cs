using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    public int attackDamage;
    public GameObject attackTarget { get; set; }
    
    [SerializeField]
    float speed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject == attackTarget)
        {
            Debug.Log("CANNON");
            Mob mob = attackTarget.GetComponent<Mob>();
            mob.anim.SetTrigger("Hit");
            mob.HP -= attackDamage;
            AudioManager.instance.SoundPlay("explodemini");
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.position = Vector3.Slerp(this.transform.position, attackTarget.transform.position, speed);
    }
}
