using UnityEngine;

namespace DefaultNamespace
{
    public class BulletScript : MonoBehaviour
    {
        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.name != "")
            {
                Destroy(gameObject);
            }
        }
    }
}