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

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        _renderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Movements();
    }

    void Movements()
    {
        Vector2 pos = transform.position;
        if (Input.GetKey ("w")) {
            pos.y += speed * Time.deltaTime * 2;
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
        transform.position = pos;
    }

}
