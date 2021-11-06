using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum TerrainType {None, Dirt, Ice};
public class TerrainHandle : MonoBehaviour
{


    [SerializeField] private Tilemap terrian;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

 


    public TerrainType GetTerrainTypeBelow(Vector3 position)
    {
        Vector3Int tileBelow = new Vector3Int(Mathf.FloorToInt(position.x), Mathf.FloorToInt(position.y), 0);

        switch (terrian.GetTile(tileBelow).name)
        {
            case "Dirt":
                return TerrainType.Dirt;
            case "Ice":
                return TerrainType.Ice;
            default:
                break;
        }

        return TerrainType.None;
    }
}
