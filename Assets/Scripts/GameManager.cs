using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int nbLives = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        nbLives = 1;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nbLives == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            nbLives = -1;
        }
    }
}
