using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackerBehaviour : TrackingBehaviour {

    private float speed;

    public override float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties) {
        float direction = 0.0f;
        float ballZ = ballProperties.position.z;
        float paddleZ = paddleProperties.position.z;
        float positionDifference = Mathf.Clamp(ballZ - paddleZ, MIN_Z, MAX_Z);
        if( positionDifference > 0 ) {
            direction = -1.0f * (1 - ( 1 / positionDifference));
        } else if( positionDifference < 0 ) {
            direction = 1.0f * (1 - ( 1 / positionDifference));
        }

        return direction;
    }

}
