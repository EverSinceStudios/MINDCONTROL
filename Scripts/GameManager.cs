using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //fields
    Scene currScene;
    string endText = "placeholder";
    Color endTextColor = Color.magenta;
    public Scene sceneCurrent;
    TD_CharacterController player;


    //properties
    public bool Lost { get; set; }
    public bool IsPlaying { get; set; }
    public static GameManager Instance { get; private set; }


    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(this);
            return;
        }
        sceneCurrent = SceneManager.GetActiveScene();
    }


    // Update is called once per frame
    void Update()
    {

    }


    //SCENE MANAGEMENT
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }
    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currScene = scene;
        IsPlaying = false;
        Lost = false;


    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        player.Invoke("Death", 1);

    }


    public void LoadScene(string scene)
    {
        SceneManager.LoadScene(scene);
        Time.timeScale = 1f;
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(currScene.buildIndex + 1);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void Resume()
    {
        Time.timeScale = 1f;

    }






    // APP MANAGEMENT
    private void OnApplicationQuit()
    {
        Lost = true;
    }
}
