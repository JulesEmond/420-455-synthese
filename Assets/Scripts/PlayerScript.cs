using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.U2D.Animation;
using UnityEditorInternal;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    private float speed = 2.5f;
    private float jumpHeight = 5f;
    private SpriteRenderer _renderer;
    private Rigidbody2D _rb;
    [SerializeField] private Camera cam;
    
    private bool _touchingGround = true;

    // Start is called before the first frame update
    void Start()
    {
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
            _rb.AddForce(Vector2.up * jumpHeight, ForceMode2D.Impulse);
            _touchingGround = false;
        }
        if (Input.GetKey ("d")) {
            pos.x += speed * Time.deltaTime;
            _renderer.flipX = false;
        }
        if (Input.GetKey ("a")) {
            pos.x -= speed * Time.deltaTime;
            _renderer.flipX = true;
        }
        transform.rotation = Quaternion.Euler(0,0,0);
        transform.position = pos + transform.position;
        cam.transform.position = new Vector3(pos.x + cam.transform.position.x, cam.transform.position.y, cam.transform.position.z);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.name != "")
        {
            _touchingGround = true;
        }
    }
    
    void Animate()
    {
        if (Input.GetKey("d") || Input.GetKey("a"))
        {
            anim.SetBool("isWalking", true);
        }
        else
        {
            anim.SetBool("isWalking", false);
        }
    }
}
