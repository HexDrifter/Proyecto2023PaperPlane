using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] public Vector2 bulletDirection;
    public float bulletSpeed;
    public float bulletDamage;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5 );
    }

    public BulletController(Vector2 Direction)
    {
        bulletDirection = Direction;
    }

    // Update is called once per frame
    public void Update()
    {
        rb.velocity = transform.right * bulletDirection * 100;
    }
}
