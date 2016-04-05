using UnityEngine;
using System.Collections;

public class BloodBehaviour : MonoBehaviour {

    float timePassed = 0f;

    float aliveTime; 

	// Use this for initialization
	void Start () {
        aliveTime = Random.Range(1, 3);
	}
	
	// Update is called once per frame
	void Update () {
        timePassed += Time.deltaTime;
        if(timePassed >= aliveTime)
        {
            Destroy(gameObject);
        }
	}
}
