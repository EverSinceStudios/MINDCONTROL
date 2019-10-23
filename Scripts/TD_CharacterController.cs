using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TD_CharacterController : MonoBehaviour
{
    public static bool GameIsPaused = false;

    //Player keeps track of current level
    //Call Death() to reload level
    public Scene sceneCurrent;

    public GameObject pauseMenuUI;

    [SerializeField]
    float moveSpeed = 4f;

    public Light light;
    Rigidbody rb;

    Vector3 forward, right;

    private void Start()
    {
        forward = Camera.main.transform.forward;
        //to ensure our y value is always set to zero
        forward.y = 0;
        forward = Vector3.Normalize(forward);
        //to get a vector in the persepective angle
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;

        light = GetComponentInChildren<Light>();

        rb = GetComponent<Rigidbody>();
        sceneCurrent = SceneManager.GetActiveScene();

    }

    private void Update()
    {
        if (Input.anyKey)
        {
            Move();
        }

        LightUp();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }


    void Move()
    {
        Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
        Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
        Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");

        Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        transform.forward = heading;
        transform.position += rightMovement;
        transform.position += upMovement;
    }

    void LightUp()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            light.enabled = !light.enabled;

        }
    }


    //Reloads the current level
    public void Death()
    {
        SceneManager.LoadScene(sceneCurrent.buildIndex);
    }

}
