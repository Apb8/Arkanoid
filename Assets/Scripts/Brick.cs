using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    //public Animator animator;
    //public float destroyDelay = 0.5f;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Pelotilla"))
        {
            //animator.Play("RedBrick");
            //StartCoroutine(DestroyBrick());
            FindObjectOfType<GameManager>().CheckLevelCompleted();
            Destroy(gameObject);
        }
    }

    //si no aconsegueixo q funcioni lo de la animacio aixo ho trec
    //private IEnumerator DestroyBrick()
    //{
    //    yield return new WaitForSeconds(destroyDelay);
    //    Destroy(gameObject);
    //}
}
