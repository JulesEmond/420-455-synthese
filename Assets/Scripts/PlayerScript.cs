using System.Threading;
using TMPro;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    private const float Speed = 2.5f;
    private const float JumpHeight = 5f;
    private SpriteRenderer _playerRenderer;
    private Rigidbody2D _rb;
    private Vector3 _initialPosition;
    private bool _touchingGround = true;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    private Vector2 _previousVelocity;

    private GameObject weapon;

    private SpriteRenderer _weaponRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        anim = GetComponent<Animator>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        weapon = transform.GetChild(0).gameObject;
        _weaponRenderer = weapon.GetComponent<SpriteRenderer>();
        _previousVelocity = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Animate();
        _previousVelocity = _rb.velocity;
    }

    void Movements()
    {
        Vector3 pos = new Vector3();
        if (Input.GetKey ("w") && _touchingGround) {
            _rb.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
            _touchingGround = false;
        }
        if (Input.GetKey ("d")) {
            pos.x += Speed * Time.deltaTime;
            _playerRenderer.flipX = false;
            _weaponRenderer.flipX = false;
            weapon.transform.position = new Vector3(transform.position.x + 0.87f, transform.position.y + 0.61f, 0);
        }
        if (Input.GetKey ("a")) {
            pos.x -= Speed * Time.deltaTime;
            _playerRenderer.flipX = true;
            _weaponRenderer.flipX = true;
            weapon.transform.position = new Vector3(transform.position.x - 0.87f, transform.position.y + 0.61f, 0);
        }

        Transform transform1;
        (transform1 = transform).rotation = Quaternion.Euler(0,0,0);
        transform1.position = pos + transform1.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "")
        {
            _touchingGround = true;
        }

        if (other.gameObject.CompareTag("void"))
        {
            transform.position = _initialPosition;
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            _rb.velocity = _previousVelocity;
        }
    }
    
    void Animate()
    {
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            anim.SetBool(IsWalking, true);
        }
        else
        {
            anim.SetBool(IsWalking, false);
        }
    }
}
