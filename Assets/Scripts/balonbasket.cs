using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class balonbasket : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody2D rb;
    public Vector2 initialLaunch;
    public float speed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(initialLaunch*speed, ForceMode2D.Impulse);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
