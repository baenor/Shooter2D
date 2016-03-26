using UnityEngine;
using System.Collections;

public class CameraBehaviour : MonoBehaviour {

    //VARIABILI NECESSARIE
    GameObject player;
    Vector3 targetPosition;
    
    //VARIABILI PUBBLICHE
    public float offset = -13f;
    public float smooth = 5f;


    // Funzione Start: qui di solito vengono inizializzate le variabili, 
    // tramite le funzioni GetComponent. In questo caso, conserviamo dentro
    // la variabile player il nostro giocatore, cercandolo tramite TAG!(utilizzeremo un sacco i TAG!)
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
      
	}
	
	// Qui non faremo altro che verificare la posizione del nostro giocatore, inserendola su targetPosition nella quale 
    // sommiamo l'altezza dove vogliamo che la camera si trovi (ecco giustificato il +offset che potrete variare tramite variabile pubblica)
    // e infine usiamo la funzione Vector3.Lerp per spostare secondo "smooth" la camera sulla posizione del giocatore
	void Update () {
        if (player != null)
        {
            targetPosition = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z + offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime + smooth); 
        }
    }
}
