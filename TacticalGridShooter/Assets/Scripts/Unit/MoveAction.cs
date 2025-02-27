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
    }

    public void Move(GridPosition gridPosition)
    {
        this.targetPosition = LevelGrid.Instance.GetWorldPosition(gridPosition);
    }


    public bool IsValidActionGridPosition(GridPosition gridPosition)
    {
        List<GridPosition> validGridPositionList = GetValidActionGridPositionList();

        return validGridPositionList.Contains(gridPosition);
    }

    public List<GridPosition> GetValidActionGridPositionList()
    {
        List<GridPosition> validGridPositionList = new List<GridPosition>();

        GridPosition unitGridPosoition = unit.GetGridPosition();

        for (int x=-maxMoveDistance;x<=maxMoveDistance;x++)
        {
            for(int z=-maxMoveDistance;z<=maxMoveDistance;z++)
            {
                GridPosition offsetGridPosition = new GridPosition(x,z);

                GridPosition testGridPosition = unitGridPosoition + offsetGridPosition;


                if(!LevelGrid.Instance.IsValidGridPosition(testGridPosition))
                {
                    continue;
                }

                if (unitGridPosoition == testGridPosition)
                {
                    //same gridposition where the unit is already at
                    continue;
                }

                if (LevelGrid.Instance.HasAnyUnitAtGridPosition(testGridPosition))
                {
                    //grid position is already occupied by another unit
                    continue;
                }

                validGridPositionList.Add(testGridPosition);

                //Debug.Log(testGridPosition);
            }
        }
        
        return validGridPositionList;
    }
}
