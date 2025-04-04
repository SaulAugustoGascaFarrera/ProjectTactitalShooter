using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAction : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 5.0f;
    [SerializeField] private float rotationSpeed = 7.0f;
   
    private Animator unitAnimator;
    private string Animation_IsWalking = "IsWalking";
    private Vector3 targetPosition;
    private Unit unit; 

    [SerializeField] private int maxMoveDistance = 1;

    private void Awake()
    {
        unit = GetComponent<Unit>();
        unitAnimator = GetComponentInChildren<Animator>();
        targetPosition = transform.position;
    }


   
    // Update is called once per frame
    void Update()
    {
        float stoppingDistance = 0.1f;

        if (Vector3.Distance(transform.position, targetPosition) > stoppingDistance)
        {
            Vector3 moveDirection = (targetPosition - transform.position).normalized;

            transform.position += moveDirection * Time.deltaTime * movementSpeed;

            transform.forward = Vector3.Slerp(transform.forward, moveDirection, rotationSpeed * Time.deltaTime);

            unitAnimator.SetBool(Animation_IsWalking, true);
        }
        else
        {
            unitAnimator.SetBool(Animation_IsWalking, false);
        }

        GridPosition mouseGridPosition = LevelGrid.Instance.GetGridPosition(MouseWorld.Instance.GetMousePosition());

        if(Input.GetMouseButtonDown(0))
        {
            Move(mouseGridPosition);
        }

    }

    public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


   

    
}
