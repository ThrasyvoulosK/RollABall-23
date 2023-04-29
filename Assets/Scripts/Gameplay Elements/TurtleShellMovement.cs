using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurtleShellMovement : Patrolling
{
    
   

    // Update is called once per frame
    void Update()
    {
        patrolBetweenTwoPoints();
        if (hasReachedFinalPosition)
            transform.LookAt(endingTransform);
        else
            transform.LookAt(startingPosition);
    }

    
}
