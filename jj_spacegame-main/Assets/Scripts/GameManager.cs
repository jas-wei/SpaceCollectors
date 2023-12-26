using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.Rendering.VirtualTexturing.Debugging;


public class GameManager : MonoBehaviour
{

    //public int level = 1;
    public int score = 0;


    private void Awake()
    {
        //dont destroy this when loading a new scene
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnLevelLoaded;
    }

    private void NewGame()
    {
        this.score = 0;

        LoadLevel();
    }

    private void Start()
    {
        NewGame();
    }

    private void LoadLevel()
    {
        //this.level = level;

        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 0;
    }

    private void OnLevelLoaded(Scene scene, LoadSceneMode mode)
    {
        //fill with references to other objects
    }

    private void Update()
    {

    }

    public void BeginGame()
    {
        Time.timeScale = 1;
    }


}
