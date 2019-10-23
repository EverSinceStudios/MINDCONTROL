using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class PlayerFollower : MonoBehaviour

{
    /*public Transform Player;
    public int MoveSpeed = 4;
    public int MaxDist = 10;
    public int MinDist = 5;
    */
    public Light light;

    AudioSource monsterRoar;

    public GameObject player;
    private NavMeshAgent navmesh;

    public Scene sceneCurrent;

    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        sceneCurrent = SceneManager.GetActiveScene();
    }

    void Update()
    {
        /*transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {
            if (light.isActiveAndEnabled == true)
            {

                transform.position += transform.forward * MoveSpeed * Time.deltaTime;

                if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
                {
                    monsterRoar.Play();
                }
            }
            
        }*/
        if (light.isActiveAndEnabled)
        {
            navmesh.destination = player.transform.position;
        }

        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneCurrent.buildIndex);
        }
    }
}
