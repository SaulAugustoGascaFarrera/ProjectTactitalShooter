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

   

}
