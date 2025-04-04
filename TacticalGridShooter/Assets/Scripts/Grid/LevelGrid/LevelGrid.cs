using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance;

    [SerializeField] private Transform debugObjectTransform;
    private GridSystem gridSystem;

    private void Awake()
    {
        if(Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        gridSystem = new GridSystem(10, 10, 2.0f);

        gridSystem.CreateDebugObject(debugObjectTransform);
        
    }


    public Vector3 GetWorldPosition(GridPosition gridPosition) => gridSystem.GetWorldPosition(gridPosition);

    public int GetWidth() => gridSystem.GetWidth();

    public int Getheight() => gridSystem.GetHeight();

    public GridObject GetGridObject(GridPosition gridPosition) => gridSystem.GetGridObject(gridPosition);   

    public GridPosition GetGridPosition(Vector3 worldPosition) => gridSystem.GetGridPosition(worldPosition);



    public void SetUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        gridObject.AddUnit(unit);
    }

    public List<Unit> GetUnitAtGridPosition(GridPosition gridPosition)
    {
        GridObject gridObject = GetGridObject(gridPosition);

        return gridObject.GetUnitList();
    }

    public void ClearUnitAtGridPosition(GridPosition gridPosition,Unit unit)
    {
        GridObject gridObject = GetGridObject(gridPosition);
        gridObject.RemoveUnit(unit);
    }

    public void UnitMovedGridPosition(Unit unit,GridPosition fromGridPosition,GridPosition toGridPosition)
    {
        ClearUnitAtGridPosition(fromGridPosition,unit);

        SetUnitAtGridPosition(toGridPosition,unit);
    }

}
