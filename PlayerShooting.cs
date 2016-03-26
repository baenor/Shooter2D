using UnityEngine;
using System.Collections;



public class PlayerShooting : MonoBehaviour {


    //VARIABILI NECESSARIE AL FUNZIONAMENTO
    public GameObject boccaFuoco; //questa è la sprite della nostra bocca da Fuoco che metteremo nell'editor

    [SerializeField] //Usate SerializeField quando volete che il campo sia accessibile da editor ma non da altri script
    float delayBetweenShots = 0.2f;
    float timePassedSinceLastShot;
    float effectsDuration = 0.1f;

    bool shooted = false;

    AudioSource gunShot;

	// Use this for initialization
	void Start () {
        timePassedSinceLastShot = delayBetweenShots;

        var aSources = GetComponents<AudioSource>();
        gunShot = aSources[1];
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButton(0) && timePassedSinceLastShot >= delayBetweenShots)
        {
            Shooting(); 
        }
        if(timePassedSinceLastShot <= delayBetweenShots) // se non stiamo premendo il tasto oppure non possiamo ancora sparare
        {
            timePassedSinceLastShot += Time.deltaTime; //inseriamo i secondi passati all'interno della variabile timePassed...
            if(timePassedSinceLastShot >= effectsDuration)
            {
                DisableEffects(); // Dopo che il tempo trascorso dall'ultimo sparo ha superato effectsDuration, disabilitiamo gli effetti
            }
        }
	}

    //Funzione Shooting: Viene invocata alla pressione del mouse, attiva gli effetti grafici e
    //Instanzia l'oggetto Bullet che abbiamo precedentemente preparato come prefab.
    void Shooting()
    {
        EnableEffects();

        GameObject bullet = (GameObject)Instantiate(Resources.Load("Bullet"),boccaFuoco.transform.position,transform.rotation);
        //Resettiamo le variabili necessarie ad effettuare lo sparo
        timePassedSinceLastShot = 0f;
    }

    //Funzione EnableEffects: abilita gli effetti grafici e sonori relativa allo sparo
    //é sempre bene suddividere in funzioni Enable/Disable in modo tale che suddividete il carico del codice
    //e siete più ordinati e logici
    void EnableEffects()
    {
        boccaFuoco.SetActive(true);
        gunShot.Play();
    }

    //Funzione DisableEffects: disabilita gli effetti grafici dello sparo
    //Nel nostro caso è esclusivamente l'illuminazione della bocca da fuoco. Tuttavia potete inserire quello che volete
    void DisableEffects()
    {
        boccaFuoco.SetActive(false);
    }

}
