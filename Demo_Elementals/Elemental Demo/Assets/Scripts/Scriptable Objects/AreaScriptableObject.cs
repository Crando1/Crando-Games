using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[System.Serializable]
public class Area
{
    public string name;
    public BoundsInt bounds;

    Area()
    {
        this.name = "";
        this.bounds = new BoundsInt();
    }
}

[CreateAssetMenu(fileName = "AreaScriptableObject", menuName = "ScriptableObjects/Data/Areas")]
public class AreaScriptableObject : ScriptableObject
{
    public List<Area> areasList = new List<Area>();

    void OnDrawGizmos()
    {
        foreach(Area area in areasList)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(area.bounds.center, area.bounds.size);
        } 
    }
}