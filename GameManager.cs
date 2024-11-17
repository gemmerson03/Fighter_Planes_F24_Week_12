using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemyOne;
    public GameObject enemyTwo;
    public GameObject cloud;
    public GameObject powerup;
    public GameObject coin;

    public AudioClip powerUp;
    public AudioClip powerDown;

    public int cloudSpeed;

    private bool isPlayerAlive;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameOverText;
    public TextMeshProUGUI restartText;
    public TextMeshProUGUI powerupText;
    public TextMeshProUGUI livesText; // Reference for lives text

    private int score;

    // Start is called before the first frame update
    void Start()
    {
         // Check if a player already exists in the scene
         // Only instantiate the player if there isn't one already in the scene
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            Instantiate(player, transform.position, Quaternion.identity);
        }
        InvokeRepeating("CreateEnemyOne", 1f, 3f);
        InvokeRepeating("CreateEnemyTwo", 2f, 4f);
        InvokeRepeating("CreateCoin", 2f, 6f);
        StartCoroutine(CreatePowerup());
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        isPlayerAlive = true;
        cloudSpeed = 1;
        UpdateLives(3); // Initialize lives
    }

    // Update is called once per frame
    void Update()
    {
        Restart();   
    }

    void CreateEnemyOne()
    {
        Instantiate(enemyOne, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
    }

     void CreateEnemyTwo()
 {
     Instantiate(enemyTwo, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.Euler(0, 0, 180));
 }

 void CreateCoin()
 {
     Instantiate(coin, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
 }

    IEnumerator CreatePowerup()
    {
        Instantiate(powerup, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
        yield return new WaitForSeconds(Random.Range(3f, 6f));
        StartCoroutine(CreatePowerup());
    }

    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int newScore)
    {
        score = score + newScore;
        scoreText.text = "Score: " + score;
    }

    public void GameOver()
    {
        isPlayerAlive = false;
        CancelInvoke();
        gameOverText.gameObject.SetActive(true);
        restartText.gameObject.SetActive(true);
        cloudSpeed = 0;
    }

    void Restart()
    {
        if(Input.GetKeyDown(KeyCode.R) && isPlayerAlive == false)
        {
            SceneManager.LoadScene("Game");
        }
    }

    public void UpdatePowerupText(string whichPowerup)
    {
        powerupText.text = "Powerup: " + whichPowerup;
    }

    public void PlayPowerUp()
    {
        AudioSource.PlayClipAtPoint(powerUp, Camera.main.transform.position);
    }

    public void PlayPowerDown()
    {
        AudioSource.PlayClipAtPoint(powerDown, Camera.main.transform.position);
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }
}
