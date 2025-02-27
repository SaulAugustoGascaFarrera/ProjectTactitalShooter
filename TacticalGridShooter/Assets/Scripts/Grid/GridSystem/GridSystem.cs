using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridSystem : MonoBehaviour
{
    private int width;
    private int height;
    private float cellSize;
    private GridObject[,] gridObjectArray; 

    public GridSystem(int width, int height, float cellSize)
    {
        this.width = width;
        this.height = height;
        this.cellSize = cellSize;

        gridObjectArray = new GridObject[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int z = 0; z < height; z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);
                //Debug.DrawLine(GetWorldPositon(gridPosition), GetWorldPositon(gridPosition) + Vector3.right * 0.4f,Color.blue,9999.0f);
                gridObjectArray[x, z] = new GridObject(this,gridPosition);
            }
        }


    }

    public Vector3 GetWorldPositon(GridPosition gridPosition)
    {
        return new Vector3(gridPosition.x, 0.0f, gridPosition.z) * cellSize;
    }


    public GridPosition GetGridPosition(Vector3 worldPositon)
    {
        return new GridPosition(Mathf.RoundToInt(worldPositon.x / cellSize), Mathf.RoundToInt(worldPositon.z / cellSize));
    }


    public void CreateDebugObject(Transform debugPrefab)
    {
        for(int x=0;x<width;x++)
        {
            for(int z=0;z<height;z++)
            {
                GridPosition gridPosition = new GridPosition(x,z);

                Transform debugTransform = Instantiate(debugPrefab,GetWorldPositon(gridPosition),Quaternion.identity);
                GridDebugObject gridDebugObject = debugTransform.gameObject.GetComponent<GridDebugObject>();
                gridDebugObject.SetGridObject(GetGridObject(gridPosition));

            }
        }
    }


    public GridObject GetGridObject(GridPosition gridPosition)
    {
        return gridObjectArray[gridPosition.x, gridPosition.z];
    }

    public int GetWidth()
    {
        return width; 
    }

    public int GetHeight()
    {
        return height;
    }


    public bool IsValidGridPosition(GridPosition gridPosition)
    {
        return gridPosition.x >= 0 && gridPosition.z >=0 && gridPosition.x < width && gridPosition.z < height;
    }

}
