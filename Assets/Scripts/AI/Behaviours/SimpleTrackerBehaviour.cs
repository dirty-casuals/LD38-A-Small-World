using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackerBehaviour : TrackingBehaviour {

    public override float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties) {
        float direction = 0.0f;
        float ballZ = ballProperties.position.z;
        float paddleZ = paddleProperties.position.z;
        float positionDifference = ballZ - paddleZ;
        if( positionDifference > 0 ) {
            direction = -1.0f;
        } else if( positionDifference < 0 ) {
            direction = 1.0f;
        }

        return direction;
    }

}
