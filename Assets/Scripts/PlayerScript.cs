using System.Threading;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private AudioSource[] audios;
    private AudioSource playerHit;
    private GameObject weapon;

    private SpriteRenderer _weaponRenderer;
    

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
        playerHit = audios[0];
        _initialPosition = transform.position;
        anim = GetComponent<Animator>();
        _playerRenderer = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        weapon = transform.GetChild(0).gameObject;
        _weaponRenderer = weapon.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_rb == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
            _rb = GetComponent<Rigidbody2D>();
        }
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
            _playerRenderer.flipX = false;
            _weaponRenderer.flipX = false;
        }
        if (Input.GetKey ("a")) {
            pos.x -= Speed * Time.deltaTime;
            _playerRenderer.flipX = true;
            _weaponRenderer.flipX = true;
        }

        Transform transform1;
        (transform1 = transform).rotation = Quaternion.Euler(0,0,0);
        transform1.position = pos + transform1.position;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("ground"))
        {
            _touchingGround = true;
        }

        if (other.gameObject.CompareTag("void"))
        {
            playerHit.Play();
            transform.position = _initialPosition;
            GameManager.nbLives = 0;
        }
        if (other.gameObject.CompareTag("bullet"))
        {
            playerHit.Play();
            GameManager.nbLives--;
            Destroy(_rb);
            _rb = null;
        }

        if (other.gameObject.name == "end")
        {
            SceneManager.LoadScene(3);
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
