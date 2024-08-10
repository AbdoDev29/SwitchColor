using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapeMove : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float speed = 5;
    [SerializeField] float distance;
   // [SerializeField] Transform endPosition;
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       
        rb.velocity = Vector2.right * speed;
        distance = Vector2.Distance(Camera.main.transform.position, transform.position);
        if (distance >= 100)
            Destroy(this.gameObject);
    }

  
}

        
