using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    private const float Speed = 2.5f;
    private const float JumpHeight = 5f;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb;
    private Vector3 _initialPosition;
    private bool _touchingGround = true;
    private static readonly int IsWalking = Animator.StringToHash("isWalking");

    // Start is called before the first frame update
    void Start()
    {
        _initialPosition = transform.position;
        anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
        Animate();
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
            _renderer.flipX = false;
        }
        if (Input.GetKey ("a")) {
            pos.x -= Speed * Time.deltaTime;
            _renderer.flipX = true;
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
