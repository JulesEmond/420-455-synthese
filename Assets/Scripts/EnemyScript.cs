using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager.Requests;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyScript : MonoBehaviour
{
    public Animator anim;
    private const float Speed = 2.5f;
    private SpriteRenderer _enemyRenderer;
    private Rigidbody2D _rb;
    private Vector3 _initialPosition;
    private bool _walkingRight = true;
    private bool _isStandBy = false;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private Boolean _aggro = false;


    [SerializeField] private EnemyRifleScript _enemyRifleScript;

    private GameObject weapon;

    private SpriteRenderer _weaponRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        anim = GetComponent<Animator>();
        _enemyRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        weapon = transform.GetChild(0).gameObject;
        _weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Animate();
    }

    public void setAggro(Boolean bol)
    {
        _aggro = bol;
    }

    public bool getEnemyDirection()
    {
        return _enemyRenderer.flipX;
    }

    void Movements()
    {
        if (!_isStandBy)
        {
            Vector3 pos = new Vector3();
            if (_walkingRight)
            {
                pos.x += Speed * Time.deltaTime;
                _enemyRenderer.flipX = false;
                _weaponRenderer.flipX = false;
                weapon.transform.position = new Vector3(transform.position.x, transform.position.y + 0.61f, 0);
            }

            if (!_walkingRight)
            {
                pos.x -= Speed * Time.deltaTime;
                _enemyRenderer.flipX = true;
                _weaponRenderer.flipX = true;
                weapon.transform.position = new Vector3(transform.position.x, transform.position.y + 0.61f, 0);
            }

            Transform transform1;
            (transform1 = transform).rotation = Quaternion.Euler(0, 0, 0);
            transform1.position = pos + transform1.position;

            if (transform1.position.x < _initialPosition.x - 3)
            {
                _walkingRight = true;
                _isStandBy = true;
                Invoke("StartWalking", 2);
            }

            if (transform1.position.x > _initialPosition.x + 3)
            {
                _walkingRight = false;
                _isStandBy = true;
                Invoke("StartWalking", 2);
            }
        }

        if (_aggro)
        {
            _isStandBy = true;
            Invoke("StartWalking", 2);
            _enemyRifleScript.setIsShooting(true);
        }

        if (!_aggro)
        {
            _enemyRifleScript.setIsShooting(false);
        }
        
        transform.rotation = Quaternion.Euler(0, 0, 0);
        _rb.velocity = new Vector2(0, 0);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("void"))
        {
            Destroy(gameObject);
        }
    }

    void Animate()
    {
        if (!_isStandBy)
        {
            anim.SetBool(IsWalking, true);
        }
        else
        {
            anim.SetBool(IsWalking, false);
        }
    }

    void StartWalking()
    {
        _isStandBy = false;
    }
}