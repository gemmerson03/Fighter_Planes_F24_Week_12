using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public GameObject explosion;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Any enemy movement or logic
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object collided with is the player
        if (other.tag("Player"))
        {
            other.GetComponent<Player>().LoseALife();
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        } 
        // Check if the object collided with is a bullet (tagged as "Weapon")
        else if (whatDidIHit.tag("Weapon"))
        {
            // Assuming you have a GameManager to handle score
            GameObject.Find("GameManager").GetComponent<GameManager>().EarnScore(5);
            Destroy(whatDidIHit.gameObject); // Destroy the bullet 
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(this.gameObject); // Destroy the enemy
        }
    }
}
