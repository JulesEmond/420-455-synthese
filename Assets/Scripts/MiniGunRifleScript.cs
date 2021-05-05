using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGunRifleScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;

    private int timeBetweenShots = 500;

    private int numberOfBulletsLeft = 5;

    private int reloadTime = 0;

    private bool isShooting = false;

    // Start is called before the first frame update
    void Start()
    {
        _gunRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (timeBetweenShots >= 500 && numberOfBulletsLeft > 0 && isShooting)
        {
            timeBetweenShots = 0;
            numberOfBulletsLeft--;
            Shoot();
        }

        if (reloadTime >= 2000 && numberOfBulletsLeft == 0)
        {
            numberOfBulletsLeft = 5;
            reloadTime = 0;
        }
        else if (numberOfBulletsLeft == 0)
        {
            reloadTime++;
        }

        timeBetweenShots++;
    }

    public void setIsShooting(bool isShooting)
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
        Destroy(bullet, 2f);
    }
}
