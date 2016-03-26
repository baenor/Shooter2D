using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    [SerializeField]
    int health = 100;
    Text playerHealth;
    AudioSource hit;

    void Start()
    {
        playerHealth = GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>();
        playerHealth.text = health.ToString();
        var aSources = GetComponents<AudioSource>();
        hit = aSources[0];
    }
    public void ZombieHit()
    {
        int damage = Random.Range(15, 26);
        health -= damage;
        if (health <= 0)
        {
            playerHealth.text = 0.ToString();
            GameManager.gameManager.PlayerIsDead();
            SpawnRandomBlood();

            Destroy(gameObject);
        }
        else
        {
            playerHealth.text = health.ToString();
            hit.Play();
        }
    }
    //Classifca funzione di spawn del sangue
    void SpawnRandomBlood()
    {
        int random = Random.Range(1, 4);
        Instantiate(Resources.Load("Blood" + random), transform.position, Quaternion.identity);
    }
   
}
