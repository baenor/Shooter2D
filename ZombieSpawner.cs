using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

    GameManager gameManager;

    float spawnDelay = 6f; //valore di partenza 
    float timeSinceLast = 0f;
    float soglia = 10f;

	// Use this for initialization
	void Start () {
        gameManager = GameManager.gameManager;
        Instantiate(Resources.Load("Zombie"), transform.position, Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameManager.GameEnded())
        {
            if(gameManager.GetTimePassed() > soglia && spawnDelay > 2)
            {
                spawnDelay--;
                soglia += soglia;
            }
            timeSinceLast += Time.deltaTime;
            if(timeSinceLast >= spawnDelay)
            {
                Instantiate(Resources.Load("Zombie"), transform.position, Quaternion.identity);
                timeSinceLast = 0f;
            }
        }
	}
}
