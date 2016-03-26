using UnityEngine;
using System.Collections;
using UnityEngine.UI;

/*
Tendo sempre a creare uno script globale e ad assegnarlo ad un oggetto vuoto. Questo è utile
nel caso in cui bisogna tener conto di punteggi, timer o altro. Create sempre uno script
come questo e rendetelo statico, in modo che potete accedere facilmente da qualsiasi
altro script. 

In questo caso, lo useremo per aggiornare i punteggi e far partire la schermata di fine gioco. 

*/
public class GameManager : MonoBehaviour {

    public static GameManager gameManager;

    int points;
    Text zombiePoints;

    float timePassed;

    //Variabili UI
    public GameObject overPanel;
    public GameObject gamePanel;
    public Text endText;

    bool gameEnded = false;

    void Awake()
    {
        gameManager = this;

    }

    // Use this for initialization
    void Start () {
        points = 0;
        timePassed = 0f;
        zombiePoints = GameObject.FindGameObjectWithTag("ZombiePoints").GetComponent<Text>();
        zombiePoints.text = points.ToString();
    }

    void Update()
    {
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

    //Funzione richiamata ogni qual volta muore uno zombie
    public void IncreasePoints()
    {
        points++;
        zombiePoints.text = points.ToString();
    }
    //Funzione richiamata dagli spawnar per sapere quanto tempo è passato
    public float getTimePassed()
    {
        return timePassed;
    }
    //Richiamato dal Player quando muore per settare che il gioco è finito
    public void PlayerIsDead()
    {
        gameEnded = true;
        gamePanel.SetActive(false);
        overPanel.SetActive(true);
        endText.text = "You have killed " + points + " zombies";
    }
    //Utilizzato dagli spawner per capire se devono ancora spawnare zombie
    public bool GameEnded()
    {
        return gameEnded;
    }
}
