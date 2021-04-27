using UnityEngine;

public class RayCastScript : MonoBehaviour
{
    private Camera _camera;

    [SerializeField] private EnemyScript _enemyScript;
    
    // Start is called before the first frame update
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.TransformDirection(Vector2.left), 10f);
        //Debug.DrawRay(transform.position, Vector3.left * 10, Color.green);

        if (hit) 
        { 
            if (hit.transform.tag == "Player")
            {
                _enemyScript.setAggro(true);
            }
            else _enemyScript.setAggro(false);
            }
        else _enemyScript.setAggro(false);
    }
}
