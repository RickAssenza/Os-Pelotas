using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espinhodomal : MonoBehaviour
{
    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.gravityScale = 2f;
            Destroy(this.gameObject, 1f);
        }
    }
}
