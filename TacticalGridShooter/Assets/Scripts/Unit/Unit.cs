using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private GridPosition gridPosition;
    private MoveAction moveAction;

    private void Awake()
    {
        moveAction = GetComponent<MoveAction>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        gridPosition = LevelGrid.Instance.GetGridPosition(transform.position);
        LevelGrid.Instance.SetUnitAtGridPosition(gridPosition, this);
    }

    // Update is called once per frame
    void Update()
    {


        GridPosition newGridPosition = LevelGrid.Instance.GetGridPosition(transform.position);

        if(newGridPosition != gridPosition)
        {
            //Unit has chabnge grid position
            LevelGrid.Instance.UnitMovedGridPosition(this, gridPosition, newGridPosition);

            gridPosition = newGridPosition;
        }

    }


    public MoveAction GetMoveAction()
    {

        return moveAction; 
    
    }

    public GridPosition GetGridPosition()
    { 
        return gridPosition;    
    }

   
}
