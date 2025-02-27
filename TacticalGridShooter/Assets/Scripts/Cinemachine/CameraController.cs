using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 100.0f;

    // Update is called once per frame
    void Update()
    {
        Vector3 inputMoveDirection = new Vector3(0.0f, 0.0f, 0.0f);

        Vector3 rotationDirection = new Vector3(0.0f, 0.0f, 0.0f);

        if(Input.GetKey(KeyCode.W))
        {
            inputMoveDirection.z = +1.0f;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputMoveDirection.z = -1.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputMoveDirection.x = -1.0f;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputMoveDirection.x = +1.0f;
        }

        inputMoveDirection = inputMoveDirection.normalized;

        Vector3 moveDirection = transform.forward * inputMoveDirection.z + transform.right * inputMoveDirection.x; 

        transform.position += moveDirection * moveSpeed * Time.deltaTime;

        if(Input.GetKey(KeyCode.R))
        {
            rotationDirection.y = -1.0f;
        }

        if (Input.GetKey(KeyCode.E))
        {
            rotationDirection.y = +1.0f;
        }

        transform.eulerAngles += rotationDirection * rotationSpeed * Time.deltaTime; 
    }
}
