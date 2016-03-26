using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    float timePassed;

    bool gameEnded = false;


    public Text zombiePoints;
    int points;
    
    void Awake()
    {
        gameManager = this;
    }

	// Use this for initialization
	void Start () {
        timePassed = 0f;
        points = 0;
        zombiePoints.text = points.ToString();
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameEnded)
        {
            timePassed += Time.deltaTime;
        }
	}
    
    public void IncreasePoints()
    {
        points++;
        zombiePoints.text = points.ToString();
    }

    public void PlayerIsDead()
    {
        gameEnded = true;
    }

    public bool GameEnded()
    {
        return gameEnded;
    }

    public float GetTimePassed()
    {
        return timePassed;
    }
}
