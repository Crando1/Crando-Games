using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Area
{
    public string name;
    public BoundsInt bounds;
    public bool lockX;

    public Area()
    {
        this.name = "";
        this.bounds = new BoundsInt();
        this.lockX = true;
    }
}

[CreateAssetMenu(fileName = "AreaScriptableObject", menuName = "ScriptableObjects/Data/Areas")]
public class AreaScriptableObject : ScriptableObject
{
    public static AreaScriptableObject Instance;
    public List<Area> areasList = new List<Area>();

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this; 
        }

    }

    public Area GetPlayerArea(Vector3 playerPosition)
    {
        Debug.Log(playerPosition);
        for (int i = 0; i < areasList.Count; i++)
        {
            if (areasList[i].bounds.Contains(Vector3Int.FloorToInt(playerPosition)))
            {
                return areasList[i];
            }
        }

        return new Area();
    }
}