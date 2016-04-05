using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    public GameObject endPanel;
    public GameObject gamePanel;
    public Text endText;

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
        else
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                Application.LoadLevel("menu");
            }
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
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
        endText.text = "You have killed " + points + " zombies";
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
