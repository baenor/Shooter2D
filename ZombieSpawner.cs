using UnityEngine;
using System.Collections;

public class ZombieSpawner : MonoBehaviour {

    GameManager gameManager;

    float spawnDelay = 6f;
    float timeSinceLast = 0f;
    float soglia = 10f;

	// Use this for initialization
	void Start () {
        Instantiate(Resources.Load("Zombie"), transform.position, Quaternion.identity);
        gameManager = GameManager.gameManager;
	}
	
	void Update () {

        /*
         1° IF:Voglio spawnare solo ed esclusivamente quando il gioco non è terminato(player morto)
         2° IF: voglio diminuire la velocità di spawn a multipli di 10 
         3° IF: se il tempo passato dall'ultimo spawn è maggiore del mio delay spawno lo zombie
       */
        if (!gameManager.GameEnded())
        {
            if (gameManager.getTimePassed() > soglia && spawnDelay > 2)
            {
                spawnDelay--;
                soglia += soglia;
            }
            timeSinceLast += Time.deltaTime;
            if (timeSinceLast >= spawnDelay)
            {
                Instantiate(Resources.Load("Zombie"), transform.position, Quaternion.identity);
                timeSinceLast = 0f;
            }
        }
    }
}
