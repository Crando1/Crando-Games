using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField]  private Transform player;
    [SerializeField] private Vector3 target;
    private float cameraSize = Camera.main.orthographicSize;
    public float smoothSpeed = .125f;
    public float playerSmoothSpeed = .95f;
    public float areaSmoothSpeed = .125f;
    public Vector3 offset;
     [SerializeField] private Area currentArea = new Area();

    /*  
     private void Update()

          //For the camera to track the player, we need to refrence the transform coponent on the player 
      {
          //Since the transform is lower case, it refrences the transform of the same compent the object is in, in this case it will just affect the transform of the player
          //Use the vector3 as the camera needs to be at 10 to see in  2d
          //player.position.x will use the position of  X the camera be the x positinon of the player
          //Use transform.position.z as we want to keep the camera z position the same
          transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);


     }
    */
    private void Start()
    {
        if(currentArea.name == "")
        {
            currentArea = AreaScriptableObject.Instance.GetPlayerArea(player.position);
        }
    }
    private void FixedUpdate()
    {
        CheckPlayerPosition();
        Vector3 desiredPosition = target + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothPosition;

        float smoothSize = Mathf.Lerp(Camera.main.orthographicSize, cameraSize, smoothSpeed);
        Camera.main.orthographicSize = smoothSize;
        
    }

     private void CheckPlayerPosition()
     {
        if (!currentArea.bounds.Contains(Vector3Int.FloorToInt(player.position)))
        {
            currentArea = AreaScriptableObject.Instance.GetPlayerArea(player.position);
        }
        if (currentArea.name == "")
        {
            target = new Vector3(player.position.x, transform.position.y, player.position.z) ;
            smoothSpeed = playerSmoothSpeed;
            cameraSize = 5.625f;
        }
        else
        {
            if (!currentArea.lockX)
            {
                target = new Vector3(player.position.x, currentArea.bounds.center.y, currentArea.bounds.center.z);
            }
            else 
            {
                target = currentArea.bounds.center;
            }
            
            smoothSpeed = areaSmoothSpeed;
            cameraSize = currentArea.bounds.size.y / 2f;
        }
        

     }
    void OnDrawGizmos()
    {
        foreach (Area area in AreaScriptableObject.Instance.areasList)
        {
            if(!area.lockX)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(area.bounds.center, area.bounds.size);
                Gizmos.DrawSphere(new Vector3(area.bounds.xMin, area.bounds.center.y, area.bounds.center.z), 1f);
                Gizmos.DrawSphere(new Vector3(area.bounds.xMax, area.bounds.center.y, area.bounds.center.z), 1f);
                Gizmos.DrawLine(new Vector3(area.bounds.xMin, area.bounds.center.y, area.bounds.center.z), new Vector3(area.bounds.xMax, area.bounds.center.y, area.bounds.center.z));
            }
            else
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireCube(area.bounds.center, area.bounds.size);
                Gizmos.DrawSphere(area.bounds.center, 1f);
              
            }
        
            
        }
    }
}
