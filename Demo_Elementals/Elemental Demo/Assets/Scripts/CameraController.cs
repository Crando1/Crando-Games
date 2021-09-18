using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
  [SerializeField]  private Transform player;
    
   private void Update()

        //For the camera to track the player, we need to refrence the transform coponent on the player 
    {
        //Since the transform is lower case, it refrences the transform of the same compent the object is in, in this case it will just affect the transform of the player
        //Use the vector3 as the camera needs to be at 10 to see in  2d
        //player.position.x will use the position of  X the camera be the x positinon of the player
        //Use transform.position.z as we want to keep the camera z position the same
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
            
    }
}
