using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public GameObject player;
    public GameObject enemy;
    public GameObject coin;
    public GameObject cloud;
    private int score;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText; // Reference for lives text

    // Start is called before the first frame update
    void Start()
    {
        Instantiate(player, transform.position, Quaternion.identity);
        InvokeRepeating("CreateEnemy", 1f, 3f);
        InvokeRepeating("CreateCoin", 2f, 6f);
        CreateSky();
        score = 0;
        scoreText.text = "Score: " + score;
        UpdateLives(3); // Initialize lives
    }

    
    void Update()
    {
        
    }

    void CreateEnemy()
    {
        Instantiate(enemy, new Vector3(Random.Range(-9f, 9f), 7.5f, 0), Quaternion.identity);
    }
    
 void CreateCoin()
 {
     Instantiate(coin,new Vector3(Random.Range(-9f, 9f), 7.5f, 0),Quaternion.identity);
 }
 
    void CreateSky()
    {
        for (int i = 0; i < 30; i++)
        {
            Instantiate(cloud, transform.position, Quaternion.identity);
        }
    }

    public void EarnScore(int howMuch) 
    {  
        score = score + howMuch;
        scoreText.text = "Score: " + score;
    }

    public void UpdateLives(int lives)
    {
        livesText.text = "Lives: " + lives;
    }    

}
