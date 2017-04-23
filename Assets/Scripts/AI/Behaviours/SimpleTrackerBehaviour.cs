using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackerBehaviour : TrackingBehaviour {

    [SerializeField]
    private float margin = 5.0f;

    private float speed;

    public override float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties,
                                           PlanetProperties planetProperties) {
        float direction = 0.0f;

        float angleBallToPlanet = GetAngleBetweenBodies(planetProperties.position,
                                                        ballProperties.position);

        float angleBatToPlanet = GetAngleBetweenBodies(planetProperties.position,
                                                    paddleProperties.position);

        float degDiff = GetDiffInDegrees(angleBallToPlanet, angleBatToPlanet);
        float positionDifference = Vector3.Distance(paddleProperties.position,
                                                    ballProperties.position);

        if( degDiff > margin ) {
            direction = 1.0f * (1 - ( 1 / positionDifference));
        } else if ( degDiff < -margin ) {
            direction = -1.0f * (1 - ( 1 / positionDifference));
        }

        return direction;
    }

    private float ToDegrees( float rads ) {
        return (180.0f / Mathf.PI) * rads;
    }

    private float GetAngleBetweenBodies( Vector3 body1, Vector3 body2 ) {
        float zDiff =  body1.z - body2.z;
        float xDiff = body1.x - body2.x;
        float angle= Mathf.Atan2(zDiff, xDiff);

        return angle;
    }

    private float GetDiffInDegrees( float rad1, float rad2 ) {
        float deg1 = ToDegrees(rad1);
        float deg2  = ToDegrees(rad2);
        float degDiff = deg1 - deg2;
        float normaliseDegDiff = 180.0f - Mathf.Abs(degDiff - 180.0f);

        return normaliseDegDiff;
    }

}
