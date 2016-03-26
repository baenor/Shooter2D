using UnityEngine;
using System.Collections;

public class PlayerShooting : MonoBehaviour {

    public GameObject boccaFuoco;

    [SerializeField]
    float delayBetweenShots = 0.2f;
    float timePassedSinceLast = 0f;
    [SerializeField]
    float effectsDuration = 0.1f;

	// Use this for initialization
	void Start () {
        timePassedSinceLast = delayBetweenShots;
	}
	
	// Update is called once per frame
	void Update () {
	    if(Input.GetMouseButton(0) && timePassedSinceLast >= delayBetweenShots)
        {
            Shooting();
        }
        if(timePassedSinceLast <= delayBetweenShots)
        {
            timePassedSinceLast += Time.deltaTime;

            if(timePassedSinceLast >= effectsDuration)
            {
                DisableEffects();
            }
        }


	}

    void Shooting()
    {
        EnableEffects();
        GameObject bullet = (GameObject)Instantiate(Resources.Load("proiettile"), boccaFuoco.transform.position, transform.rotation);
        timePassedSinceLast = 0f;
    }


    void EnableEffects()
    {
        boccaFuoco.SetActive(true);
    }

    void DisableEffects()
    {
        boccaFuoco.SetActive(false);
    }
}
