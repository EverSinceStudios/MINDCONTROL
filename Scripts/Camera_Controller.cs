using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour
{

    [SerializeField]
    private Transform target;
    [SerializeField]
    private Vector3 targetoffset;
    [SerializeField]
    private float movementspeed;

    void Start()
    {
        
    }


    void Update()
    {
        moveCamera();
    }

    void moveCamera()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetoffset, movementspeed * Time.deltaTime);
    }
}
