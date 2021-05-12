using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text livesLeft;

    [SerializeField] private GameObject player;
    public static int nbLives;
    
    // Start is called before the first frame update
    void Start()
    {
        nbLives = 3;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (nbLives >= 0)
        {
            livesLeft.text = "Lives : " + nbLives.ToString();
        }
        
        if (nbLives == 0)
        {
            nbLives = -1;
            Destroy(player);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Invoke("LoadGameOver", 2f);
            
            
        }
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(1);
    }
}
