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
    public static AreaScriptableObject Instance;
    public List<Area> areasList = new List<Area>();

    private void OnEnable()
    {
        if(Instance == null)
        {
            Instance = this; 
        }
    }
}