using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static float speed = 10f;
    public static float TimeToSpawn = 3f;
    public static float score = 0f;
    public static string playerName = "Runner";
    public static bool gameOver = false;


    void Start()
    {
        StartGame();
    }

    private void StartGame()
    {
        //GameController.LoadData();
        GameController.speed = 10f;
        GameController.TimeToSpawn = 3f;
        GameController.score = 0f;
        GameController.gameOver = false;
        InvokeRepeating("ChangeDificult", 1f, 5f);
    }

    private void ChangeDificult()
    {
        if (!GameController.gameOver)
        {
            GameController.speed += 1;
            GameController.TimeToSpawn = Mathf.Clamp(GameController.TimeToSpawn - 0.5f, 1.5f, 5f);
            GameController.score += 5;
        }
    }
}