using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{ //This script is to make sure that thplayer moves with the platform, will be very similar to camera script that follows player 
  //Parrent player on to moving object 
  // Start is called before the first frame update
  //Want to be notified when we are on the platform

    
    
    //We do ontrigger 2d as this way we can distenguish between the two types of collistion boxes  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //This will be executed if the stickyplatfom collides with onther object, and if the other object has the name player
        if (collision.gameObject.name == "Player")
        {
            //This code will set the player as a child of the stickyplatfom, (when we refer to transform, it is the transform of the object, in this case the moving platform 
            collision.gameObject.transform.SetParent(transform);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //This script is to exact the parenting 
        if (collision.gameObject.name == "Player")
        {
            //This code will set the player as a child of the stickyplatfom, (when we refer to transform, it is the transform of the object, in this case the moving platform 
            collision.gameObject.transform.SetParent(null);

        }

    }

}