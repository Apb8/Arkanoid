using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //public Animator animator;
    //public float destroyDelay = 0.5f;
    public int resistance = 1;

    private void Start()
    {
        if (gameObject.CompareTag("Resistant"))
        {
            resistance += 1;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pelotilla"))
        {
            resistance--; //mirar si es pot fer millor

            if (resistance <= 0)
            {
                FindObjectOfType<GameManager>().BrickDestroyed();
                FindObjectOfType<GameManager>().CheckLevelCompleted();
                Destroy(gameObject);
                //animator.Play("RedBrick");
                //StartCoroutine(DestroyBrick());
            }
            
        }
    }

    //si no aconsegueixo q funcioni lo de la animacio aixo ho trec
    //private IEnumerator DestroyBrick()
    //{
    //    yield return new WaitForSeconds(destroyDelay);
    //    Destroy(gameObject);
    //}
}
