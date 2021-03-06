using UnityEngine;

public class EnemyRifleScript : EnemyWeaponScript
{
    [SerializeField] private GameObject bulletPrefab;

    private SpriteRenderer _gunRenderer;

    private int timeBetweenShots = 500;

    private int numberOfBulletsLeft = 5;

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
            bulletBody.velocity = transform.TransformDirection(Vector2.left * 50);

        }
        else
        {
            var initBulletPos = new Vector3(transform.position.x + 1f, transform.position.y, transform.position.z);
            bullet = Instantiate(bulletPrefab, initBulletPos, transform.rotation);
            Rigidbody2D bulletBody = bullet.GetComponent<Rigidbody2D>();
            bulletBody.velocity = transform.TransformDirection(Vector2.right * 50);
        }
        _audioSource.Play();
        Destroy(bullet, 0.50f);
    }
}
