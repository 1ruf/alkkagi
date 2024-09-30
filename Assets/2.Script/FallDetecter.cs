using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallDetecter : MonoBehaviour
{
    private Rigidbody2D ballRB;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            collision.transform.DOScale(0, 1).OnComplete(()=>Destroy(collision));
            ballRB = collision.GetComponent<Rigidbody2D>();
            ballRB.velocity = Vector2.zero;
        }
    }
}
