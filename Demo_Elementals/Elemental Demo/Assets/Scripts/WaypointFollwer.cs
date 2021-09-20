using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollwer : MonoBehaviour
{
    //We create an array so we can put more than one waypoint in //game object is generic empty game object (which is what the waypoints are currently)
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;



    // Update is called once per frame
    private void Update()
    { // this way you can check the distance between the platfrom and the active waypoint, first vector active waypoint, second vector position of platform 
        //If the 1st way point and the current platfom have a value that is very small (.1f, basically 0, then we know that we are touching and switch to next waypoint 
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;
            if(currentWaypointIndex >= waypoints.Length)//This is set to  set up to know that you are at the last way point
            {
                currentWaypointIndex = 0; //then you reset the index to zero 
            }
        }

        //This will make the platform move toward the next waypoiint.
        //Transforposition of platform, use helper method .movetwoards, (current position of platform, posotion you want to move towards, (next variable defines how much you want to move in a frame 
        //Use delta time * speed. Speed defines how many game unit you want to mmove (which is one peice in the tile map), want to move 2 game unites per second.
        //As the framerate can very, we don't want this movement to be tied to the framerate. Delta time is a fraction of the value that basically normalizes
        //We use this to make something be framerate independent 
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }


}
