using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySmgScript : EnemyWeaponScript
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;

    private int timeBetweenShots = 30;

    private int numberOfBulletsLeft = 32;

    private int reloadTime = 0;

    public bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (timeBetweenShots >= 30 && numberOfBulletsLeft > 0 && isShooting)
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

        if (_gunRenderer.flipX)
        {
            var initBulletPos = new Vector3(transform.position.x - 1f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = transform.TransformDirection(Vector2.left * 100);

        }
        else
        {
            var initBulletPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = transform.TransformDirection(Vector2.right * 100);
        }
        Destroy(bullet, 0.1f);
    }
}
