using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FloorTrap : MonoBehaviour
{


    TD_CharacterController resetter;
    public Scene sceneCurrent;


    // Start is called before the first frame update
    void Start()
    {
        sceneCurrent = SceneManager.GetActiveScene();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Monster")
        {

            Destroy(other.gameObject, 0.3f);
            Debug.Log("ITS A TRAP!");
          

        }
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneCurrent.buildIndex);
        }
 
    }
}
