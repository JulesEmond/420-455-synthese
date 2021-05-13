using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = System.Random;

public class EnemySmgScript : EnemyWeaponScript
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;

    private int timeBetweenShots = 20;

    private int numberOfBulletsLeft = 32;

    private int reloadTime = 0;

    public bool isShooting = false;
    
    private AudioSource _audioSource;


    // Start is called before the first frame update
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        _gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeBetweenShots >= 20 && numberOfBulletsLeft > 0 && isShooting)
        {
            timeBetweenShots = 0;
            numberOfBulletsLeft--;
            Shoot();
        }

        if (reloadTime >= 1000 && numberOfBulletsLeft == 0)
        {
            numberOfBulletsLeft = 32;
            reloadTime = 0;
        }
        else if (numberOfBulletsLeft == 0)
        {
            reloadTime++;
        }

        timeBetweenShots++;
    }
    
    public override void setIsShooting(bool isShooting)
    {
        this.isShooting = isShooting;
    }

    private void Shoot()
    {
        GameObject bullet;
        Random random = new Random();
        var hipfireValue = (float)random.NextDouble() * (15 - (-15)) + (-15);

        if (_gunRenderer.flipX)
        {
            var initBulletPos = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.Rotate(0, 0, hipfireValue);
            Vector2 force = new Vector2(-100, hipfireValue) * 20;
            bulletBody.AddForce(force);
            

        }
        else
        {
            var initBulletPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bullet.transform.Rotate(0, 0, hipfireValue);
            Vector2 force = new Vector2(100, hipfireValue) * 20;
            bulletBody.AddForce(force);

        }
        _audioSource.Play();
        Destroy(bullet, 0.15f);
    }
}
