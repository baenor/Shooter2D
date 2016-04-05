using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerDamage : MonoBehaviour {

    [SerializeField]
    int health = 100;

    public Text playerHealth;

    AudioSource[] aSources;


    // Use this for initialization
    void Start () {
        //GameObject.FindGameObjectWithTag("PlayerHealth").GetComponent<Text>();
        playerHealth.text = health.ToString();
        aSources = GetComponents<AudioSource>();
	}
	
    public void ZombieHit()
    {
        int random = Random.Range(1, 3);
        aSources[random].Play();

        int damage = Random.Range(15, 26);
        health -= damage;
        
        if(health <= 0)
        {
            playerHealth.text = 0.ToString();
            SpawnRandomBlood();
            GameManager.gameManager.PlayerIsDead();
            Destroy(gameObject);
        }
        else
        {
            playerHealth.text = health.ToString();
        }
    }


    void SpawnRandomBlood()
    {
        int random = Random.Range(1, 5);
        Instantiate(Resources.Load("Blood" + random), transform.position, Quaternion.identity);
    }
}
