using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float speed = 12f;

    [SerializeField]
    private Rigidbody2D rb;

    private void OnEnable()
    {
        speed = Random.Range(2f, 20f);
        
    }

    private void FixedUpdate()
    {
        rb.velocity = Vector2.down * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Obstacle") && !collision.gameObject.CompareTag("PowerUp"))
        {
            gameObject.SetActive(false);
        }
    }
}
