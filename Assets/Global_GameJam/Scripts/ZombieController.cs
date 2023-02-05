using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    readonly Vector2 MoveDirection = Vector2.left;
    public ZombieProperty ZombieProperty;
    public ZombieType ZombieType;
    public Rigidbody2D Rigidbody2D;
    public Animator Animator;
    public Collider2D col;

    bool isDead = false;
    float defaultSpeed = 0;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        col = GetComponent<Collider2D>();
        defaultSpeed = ZombieProperty.speed;
    }

    
    void Update()
    {
        if (isDead) return;

        if (Vector2.Distance(RootController.Instance.transform.position, transform.position) < 3)
        {
            Vector2 dir = (RootController.Instance.transform.position - transform.position).normalized;
            Rigidbody2D.MovePosition((Vector2)Rigidbody2D.position + dir * Time.deltaTime * ZombieProperty.speed);
            Animator.SetTrigger("Attack");
        }
        else
        {
            Rigidbody2D.MovePosition((Vector2)Rigidbody2D.position + MoveDirection * Time.deltaTime * ZombieProperty.speed);
            
        }
        Animator.SetBool("Walk", true);
    }

    public void Freeze()
    {
        ZombieProperty.speed = 0;
        Animator.enabled = false;
        StartCoroutine("ResetSpeed");
    }

    IEnumerator ResetSpeed()
    {
        yield return new WaitForSeconds(3);
        ZombieProperty.speed = defaultSpeed;
        Animator.enabled = true;
    }

    public void Stun()
    {
        ZombieProperty.speed = .5f;
        StartCoroutine("ResetSpeed");
    }

    public void Dead()
    {
        GameObject blood = PoolingManager.Instance.GetObject(NamePrefabPool.Blood, transform.position);
        isDead = true;
        col.enabled = false;
        Animator.SetTrigger("Dead");
        StartCoroutine(WaitDie(blood));
    }

    IEnumerator WaitDie(GameObject blood)
    {
        yield return new WaitForSeconds(1);
        blood.SetActive(false);
        Destroy(this.gameObject);
    }
}
