using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    //Variabile che definisce la velocità del proiettile
    [SerializeField]
    float bulletSpeed = 50f;
    //Variabile che definisce la "vita" del proiettile
    [SerializeField]
    float bulletLifeTime = 2f;
    //Contatore dei secondi passati da quando è "nato" il proiettile
    float timePassedSinceBorn = 0f;

	void Update () {
        //Vogliamo che il proiettile venga distrutto se passano 3 secondi
        KillAfterTime();
        //Vogliamo che si muova secondo una precisa direzione
        BulletMovement();
    }
    //Stabilisce quando il proiettile deve essere distrutto
    void KillAfterTime()
    {
        timePassedSinceBorn += Time.deltaTime; //Ad ogni ciclo contiamo quanto tempo è passato
        if(timePassedSinceBorn >= bulletLifeTime) //Verifichiamo se il tempo passato è superiore al lifeTime stabilito
        {
            Destroy(gameObject);
        }
    }

    //Stabilisce il movimento del proiettile. Non si fa altro che sommare al vettore posizione dell'oggetto
    // il Vettore transform.up che nei giochi Top-Down sarebbe la direzione in cui sono rivolti gli oggetti,
    // Time.deltaTime per spostare l'oggetto in maniera graduale e bulletSpeed che è la nostra velocità impostata 
    // del proiettile. 
    void BulletMovement()
    {
        transform.position += transform.up * Time.deltaTime * bulletSpeed; 
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        Destroy(gameObject);
    }




}
