using UnityEngine;

public class RayCastScript : MonoBehaviour
{

    [SerializeField] private LayerMask ignoreRayCast;
    [SerializeField] private EnemyScript _enemyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit;
        if (_enemyScript.getEnemyDirection())
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left, 10f, ~ignoreRayCast);
            Debug.DrawRay(transform.position, Vector2.left * 10, Color.green);
        }
        else
        {
            hit = Physics2D.Raycast(transform.position, Vector2.right, 10f, ~ignoreRayCast);
            Debug.DrawRay(transform.position, Vector2.right * 10, Color.green);
        }

        if (hit) 
        { 
            if (hit.transform.tag == "Player")
            {
                print("Spotted");
                _enemyScript.setAggro(true);
            }
            else _enemyScript.setAggro(false);
        }
        else _enemyScript.setAggro(false);
    }
}
