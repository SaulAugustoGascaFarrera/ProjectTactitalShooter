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
       
    }

    // Update is called once per frame
    void Update()
    {
        

       
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
