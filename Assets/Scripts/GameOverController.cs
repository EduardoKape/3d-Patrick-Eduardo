using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public Text score;
    // Start is called before the first frame update
    void Start()
    {
        score.text = GameController.playerName + " meteu " + GameController.score.ToString() + " pontos";

        Invoke("GoMenu", 10f);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void GoMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}