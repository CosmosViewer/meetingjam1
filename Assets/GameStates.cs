using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStates : MonoBehaviour
{
    public static GameStates instance;
    bool gameOver;
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null) {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver() {
        gameOver = true;
        SceneManager.LoadScene(2);
    }
    public void GameWin() {
        gameOver = true;
        SceneManager.LoadScene(3);
    }
}
