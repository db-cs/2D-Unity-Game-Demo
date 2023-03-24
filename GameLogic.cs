using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    public static GameLogic instance { get; private set; }
    public float highScore { get; private set; }
    public float timeElapsed { get; private set; }
    public GameState currentState { get; private set; } = GameState.NOT_STARTED;

    public enum GameState
    {
        NOT_STARTED,
        RUNNING,
        PAUSED,
        OVER
    }

    private void Awake() => instance = this;

    private void Update()
    {
        switch (currentState)
        {
            case GameState.NOT_STARTED:
                StartGame();
                break;
            case GameState.RUNNING:
                RunGame();
                break;
            case GameState.PAUSED:
                PauseGame();
                break;
            case GameState.OVER:
                EndGame();
                break;
            default:
                throw new System.Exception("Game state not valid");
        }
    }

    private void StartGame()
    {
        // Reset time
        timeElapsed = 0;
        Time.timeScale = 1;

        // Reset game objects to original positions
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.transform.position = new Vector3(-7, -3, 0);

        GameObject[] obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach (GameObject obstacle in obstacles)
            obstacle.SetActive(false);
    
        // Start game on jump
        if (Input.GetButtonDown("Jump"))
            currentState = GameState.RUNNING;
    }

    private void RunGame()
    {
        timeElapsed += Time.deltaTime * 10f;
        if (Input.GetKeyDown(KeyCode.P))
            currentState = GameState.PAUSED;
    }

    private void PauseGame()
    {
        // Stop game
        Time.timeScale = 0;

        // Resume game
        if (Input.GetKeyDown(KeyCode.P))
        {
            Time.timeScale = 1;
            currentState = GameState.RUNNING;
        }
    }

    private void EndGame()
    {
        if(timeElapsed > highScore)
            highScore = timeElapsed;
        Time.timeScale = 0;

        if (Input.GetButtonDown("Jump"))
            StartGame();
    }

    public bool isGameRunning()
    {
        return currentState == GameState.RUNNING;
    }

    public void HitObstacle()
    {
        currentState = GameState.OVER;
    }
}