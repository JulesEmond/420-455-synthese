using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class RevolverScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if(Input.GetKey("space"))
        {
            GameObject bullet;
            bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            
            if (_gunRenderer.flipX)
            {
                bulletBody.velocity = transform.TransformDirection(Vector2.left * 100);
            }
            else
            {
                bulletBody.velocity = transform.TransformDirection(Vector2.right * 100);
            }
            Destroy(bullet, 2f);
        }
    }
}
