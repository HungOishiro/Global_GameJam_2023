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

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    
    void Update()
    {
        if (Vector2.Distance(RootController.Instance.transform.position, transform.position) < 3)
        {
            
        }
        else
        {
            Rigidbody2D.MovePosition((Vector2)Rigidbody2D.position + MoveDirection * Time.deltaTime * ZombieProperty.speed);
            Animator.SetBool("Walk" , true);
        }
    }

    void Dead()
    {
        
    }
}
