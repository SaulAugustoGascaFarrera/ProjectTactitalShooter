using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridObject 
{
    private GridSystem gridSystem;
    private GridPosition gridPosition;

    private List<Unit> unitList;

    public GridObject(GridSystem gridSystem,GridPosition gridPosition)
    {
        this.gridSystem = gridSystem;
        this.gridPosition = gridPosition;
        unitList = new List<Unit>();
    }


    public void AddUnit(Unit unit)
    {
        unitList.Add(unit);
    }

    public void RemoveUnit(Unit unit)
    {
        unitList.Remove(unit);
    }


    public List<Unit> GetUnitList()
    {
        return unitList;
    }

    public bool HasAnyUnit()
    {
        return unitList.Count > 0;
    }


    public override string ToString()
    {

        string playerString = "";

        if(HasAnyUnit())
        {
            foreach(Unit unit in unitList)
            {
                playerString += unit + "\n";
            }

            return gridPosition.ToString() + "\n" + playerString;
        }

        return gridPosition.ToString(); 
    }


}
