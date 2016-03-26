using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    /// VARIABILI PUBBLICHE
    public float speed = 5f;

    /// VARIABILI NECESSARIE AL FUNZIONAMENTO
    Rigidbody2D body;
    LayerMask terrainMask;

	// Funzione Start: qui di solito vengono inizializzate le variabili, tramite le funzioni
    // GetComponent. 
	void Start () {
        body = GetComponent<Rigidbody2D>();
        terrainMask = LayerMask.GetMask("Terrain");
	}
	
	// Funzione Update: viene richiamata ad ogni frame grafico del gioco. Consideratela come un ciclo, quindi inserite qui
    // tutte le operazioni o controlli che volete che vengano eseguiti. 
	void Update () {
        Movement();
        Aiming();
    }
    // Funzione Movement: gestisce il movimento del personaggio tramite le funzioni GetAxisRaw. 
    // La funzione GetAxisRaw fa parte della classe Input di Unity. Andando a specificare come
    // parametro l'asse che ci interessa, possiamo ottenere informazioni sulla pressione dei tasti
    // relativi agli assi indicati. In questo caso Horizontal e Vertical corrispondono alle freccette
    // orizzontali e verticali o ai corrispondenti assi in caso di utilizzo di un joystick. 
    void Movement()
    {
        float h = Input.GetAxisRaw("Horizontal");  
        float v = Input.GetAxisRaw("Vertical");

        Vector2 movement = new Vector2(h, v);  //Conserviamo i valori ottenuti all'interno di un Vector2    
        //Applichiamo il movimento tramite la funzione MovePosition, andando a moltiplicare il valore
        //per Time.DeltaTime e la velocità che abbiamo impostato (speed). Time.deltaTime permette di
        // far variare il valore in maniera graduale. Provate pure con e senza Time.DeltaTime per vedere gli effetti
        body.MovePosition(body.position + movement.normalized * Time.deltaTime * speed);
    }    
    //Funzione Aiming: permette di ruotare il personaggio verso la posizione del mouse
    // var non è nient'altro che un modo per definire un Vector3 in maniera più rapida;
    // Si invoca la funzione WorldToScreenPoint per trasformare la posizione del personaggio da coordinate world a screen
    // Si fa la differenza tra il vettore posizione Mouse e vettore posizione personaggio per ottenere il vettore DIREZIONE
    // si applica la rotazione tramite Quaternion.Euler
    void Aiming()
    {
        var objectPos = Camera.main.WorldToScreenPoint(transform.position);
        var dir = Input.mousePosition - objectPos;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(-dir.x, dir.y) * Mathf.Rad2Deg));
    }
}
