using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGrid : MonoBehaviour
{

    public static LevelGrid Instance;

    [SerializeField] private Transform debugObhectTransform;
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
        
    }

    void Start()
    {
       
    }

    


}
