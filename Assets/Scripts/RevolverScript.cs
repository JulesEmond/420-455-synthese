using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class RevolverScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;

    private int timeBetweenShots = 30;

    private int numberOfBulletsLeft = 6;
    
    private int reloadTime = 0;
    
    [SerializeField] private Text bulletLefts;

    [SerializeField] private GameObject player;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        bulletLefts.text = numberOfBulletsLeft + "/6" ;
        if(Input.GetKey("space") && timeBetweenShots >= 30 && numberOfBulletsLeft > 0)
        {
            timeBetweenShots = 0;
            numberOfBulletsLeft--;
            Shoot();
        }
        if (reloadTime == 100 && numberOfBulletsLeft == 0)
        {
            numberOfBulletsLeft = 6;
            reloadTime = 0;
        }
        else if (numberOfBulletsLeft == 0)
        {
            reloadTime++;
        }
        timeBetweenShots++;
    }
    private void Shoot()
    {
        GameObject bullet;

        if (_gunRenderer.flipX)
        {
            var initBulletPos = new Vector3(transform.position.x - 0.25f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = transform.TransformDirection(Vector2.left * 50);
        }
        else
        {
            var initBulletPos = new Vector3(transform.position.x + 0.25f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = transform.TransformDirection(Vector2.right * 50);
        }
        Destroy(bullet, 0.20f);
    }

    private void Update()
    {
        if (_gunRenderer.flipX)
        {
            transform.position = new Vector3(player.transform.position.x - 0.87f, player.transform.position.y + 0.61f, 0);
        }
        else 
            transform.position = new Vector3(player.transform.position.x + 0.87f, player.transform.position.y + 0.61f, 0);
            
    }
}
