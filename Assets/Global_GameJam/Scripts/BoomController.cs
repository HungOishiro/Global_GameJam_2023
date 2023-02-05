using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomController : MonoBehaviour
{
    [SerializeField] int id;
    float timeDisableCol = .1f;
    [SerializeField] Collider2D col;

    private void OnEnable()
    {
        col.enabled = true;
        StartCoroutine("WaitDisableCol");
    }

    IEnumerator WaitDisableCol()
    {
        yield return new WaitForSeconds(timeDisableCol);
        col.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            switch(id)
            {
                case 0:
                case 1:
                    collision.GetComponent<ZombieController>().Dead();
                    break;
                case 2:
                    collision.GetComponent<ZombieController>().Freeze();
                    break;
                case 3:
                    collision.GetComponent<ZombieController>().Stun();
                    break;
            }
            
        }
    }
}
