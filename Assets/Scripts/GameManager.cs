using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Text livesLeft;

    [SerializeField] private GameObject player;
    public static int nbLives;

    private AudioSource[] audios;
    private AudioSource backgroundMusic;
    private AudioSource enemyDeath;
    private AudioSource gameDone;

    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponents<AudioSource>();
        backgroundMusic = audios[0];
        gameDone = audios[1];
        enemyDeath = audios[2];
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
            backgroundMusic.Stop();
            nbLives = -1;
            enemyDeath.Play();
            gameDone.Play();
            Destroy(player);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Invoke("LoadGameOver", 4f);
        }
    }

    void LoadGameOver()
    {
        SceneManager.LoadScene(2);
    }
    
}
