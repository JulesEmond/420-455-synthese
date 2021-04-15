using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] private PlayerScript playerScript;
    [SerializeField] private GameObject player;
    [SerializeField] private Vector2 posOffset;
    [SerializeField] private float timeOffset;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //float diffX = playerScript.GetDiffX();
        //transform.position = new Vector3( diffX + transform.position.x, transform.position.y, transform.position.z);
        FollowPlayer();
    }

    void FollowPlayer()
    {
        Vector3 initPos = transform.position;
        Vector3 finalPos = player.transform.position;

        finalPos.x += posOffset.x;
        finalPos.y = initPos.y;
        finalPos.z = -10;

        transform.position = Vector3.Lerp(initPos, finalPos,timeOffset * Time.deltaTime);
    }
}
