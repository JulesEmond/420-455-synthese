using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.UI;
using Random = System.Random;

public class PlayerWeaponScript : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    public SpriteRenderer _gunRenderer;

    public int timeBetweenShots = 30;
    
    public int waitingTimeForNextBullet= 30;

    public int numberOfBulletsLeft = 6;

    public int totalBullets = 6;

    public int reloading = 0;
    
    public int reloadTime = 100;
    
    public float offSetX =  0.87f;
    
    public float offSetBullet = 0.25f;
    
    public float bulletDestroyTime = 0.20f;
    
    public float offSetHipFire = 0f;
    
    [SerializeField] private Text bulletLefts;

    [SerializeField] private GameObject player;
    
    private AudioSource[] audios;
    private AudioSource gunShotClip;
    private AudioSource reloadClip;
    private AudioSource cockBullet;
    
    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = GetComponent<SpriteRenderer>();
        audios = GetComponents<AudioSource>();
        gunShotClip = audios[0];
        reloadClip = audios[1];
        cockBullet = audios[2];
    }

    // Update is called once per frames
    private void FixedUpdate()
    {
        bulletLefts.text = numberOfBulletsLeft + "/" + totalBullets ;
        if(Input.GetKey("space") && waitingTimeForNextBullet >= timeBetweenShots && numberOfBulletsLeft > 0)
        {
            waitingTimeForNextBullet = 0;
            numberOfBulletsLeft--;
            Shoot();
        }
        
        if (reloading == reloadTime && numberOfBulletsLeft == 0)
        {
            reloadClip.Play();
            numberOfBulletsLeft = totalBullets;
            reloading = 0;
        }
        else if (numberOfBulletsLeft == 0)
        {
            reloading++;
        }
        waitingTimeForNextBullet++;
    }
    private void Shoot()
    {
        Random random = new Random();
        var hipfireValue = (float)random.NextDouble() * (offSetHipFire - (-offSetHipFire)) + (-offSetHipFire);
        
        GameObject bullet;

        if (_gunRenderer.flipX)
        {
            var initBulletPos = new Vector3(transform.position.x - offSetBullet, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.Rotate(0, 0, hipfireValue);
            Vector2 force = new Vector2(-100, hipfireValue) * 20;
            bulletBody.AddForce(force);
        }
        else
        {
            var initBulletPos = new Vector3(transform.position.x + offSetBullet, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.Rotate(0, 0, hipfireValue);
            Vector2 force = new Vector2(100, hipfireValue) * 20;
            bulletBody.AddForce(force);
        }
        gunShotClip.Play();
        cockBullet.Play();
        Destroy(bullet, bulletDestroyTime);
    }

    private void Update()
    {
        if (_gunRenderer.flipX)
        {
            transform.position = new Vector3(player.transform.position.x - offSetX, player.transform.position.y + 0.61f, 0);
        }
        else 
            transform.position = new Vector3(player.transform.position.x + offSetX, player.transform.position.y + 0.61f, 0);
            
    }
}
