using System;
using UnityEngine;

    public class BulletScript : MonoBehaviour
    {
        private Rigidbody2D _rb;

        private void Start()
        {
            
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.tag == "bullet")
            {
                Destroy(gameObject);
                Destroy(other.gameObject);
            }

            if (other.gameObject.name != "")
            {
                print("Hit!");
                Destroy(gameObject);
            }
        }
    }