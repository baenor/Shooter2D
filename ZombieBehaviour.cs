using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ZombieBehaviour : MonoBehaviour {

    //Ci serve accedere all'Animator per invocare le animazioni
    Animator anim;
    //Target sarà il gameObject Player che chiameremo nella funzione Start()
    Transform target;
   GameManager gameManager;
   [SerializeField]
    float zombieSpeed = 3f;
    [SerializeField]
    float zombieHealth = 100f;
    // Use this for initialization
    void Start() {
        anim = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").transform;

       gameManager = GameManager.gameManager;
    }

    void Update() {
        if (target != null)
        {
            Following();
        }
    }
    //Questa funzione si occupa di seguire il giocare (se lo trova)
    //Ed attivare danno ed animazioni. 
    void Following()
    {
        var dir = target.position - transform.position; // calcoliamo il vettore direzione verso il target
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;  //troviamo l'angolo relativo 
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward); //spostiamo la nostra sprite lungo quest'angolo

        transform.position = Vector2.MoveTowards(transform.position, target.position, zombieSpeed * Time.deltaTime); 
        //Funzione che effettivamente fa muovere lo zombie        
        //Facciamo il controllo sulla distanza tra il giocatore e lo zombie:
        // Se questa distanza è minore di soglia(3f) allora lo zombie dovrà attivare l'animazione
        // Altrimenti attiverà l'animazione movimento
        if (Vector3.Distance(transform.position, target.position) < 2f)
        {
            anim.SetBool("isMoving", false); //Disattiva l'animazione movimento
            anim.SetTrigger("Attack"); //Attiva il trigger "Attack"
        }
        else
        {
            anim.SetBool("isMoving", true); //Attiva l'animazione movimento

        }
    }
    //Funzione OnCollisionEnter2D di Unity. 
    //Qui inserite tutti i controlli che volete fare in termini di collisioni
    //Per aggiungere i comportarmenti 
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.collider.tag == "Bullet")
        {
            TakeDamage();
        }

    }
    //Questa funzione verrà automaticamente invocata ogni qual volta vi sarà una collisione
    //Con un Oggetto di tipo "Bullet". Verrà quindi ridotta la vita dello zombie di una quantità
    //variabile (20 nel nostro caso) e inoltre verrà fatto il controllo sulla vita, per capire
    // se lo zombie è morto o no. In caso è morto, verrà fatto spawnare uno dei 3 blood sprite 
    // e distrutto lo zombie. 
    void TakeDamage()
    {
        zombieHealth -= 20;
        if(zombieHealth < 0)
        {
            SpawnRandomBlood();

            gameManager.IncreasePoints();

            Destroy(gameObject);
        }
    }

    void AttackPlayer()
    {
        if(target != null)
            target.GetComponent<PlayerDamage>().ZombieHit();
    }

    void SpawnRandomBlood()
    {
        int random = Random.Range(1, 4);
        Instantiate(Resources.Load("Blood" + random), transform.position, Quaternion.identity);
    }
}
