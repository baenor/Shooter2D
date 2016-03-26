using UnityEngine;
using System.Collections;

public class BloodBehaviour : MonoBehaviour {

    //Variabile utilizzata per stabilire quanto tempo manca prima di far sparire
    // il sangue
    float timeSpan;
    
	// Use this for initialization
	void Start () {
        timeSpan = Random.Range(2, 7); //Ogni chiazza avrà una durata randomica
	}
	
	// Ad ogni ciclo diminuiremo il counter e appena sarà 0 distruggeremo l'oggetto
	void Update () {
	    if(timeSpan > 0f)
        {
            timeSpan -= Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
	}
}
