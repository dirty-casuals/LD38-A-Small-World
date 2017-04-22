using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTrackerBehaviour : TrackingBehaviour {

    [SerializeField]
    private float margin = 1.0f;

    private float speed;

    public override float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties,
                                           PlanetProperties planetProperties) {
        float direction = 0.0f;

        float zDiff = planetProperties.position.z - ballProperties.position.z;
        float xDiff = planetProperties.position.x - ballProperties.position.x;
        float angleBallToPlanet = Mathf.Atan2(zDiff,
                                              xDiff);

        float zDiffBat = planetProperties.position.z - paddleProperties.position.z;
        float xDiffBat = planetProperties.position.x - paddleProperties.position.x;
        float angleBatToPlanet = Mathf.Atan2(zDiffBat,
                                              xDiffBat);

        float degBallToPlanet = (180 / Mathf.PI) * angleBallToPlanet;
        float degBatToPlanet = (180 / Mathf.PI) * angleBatToPlanet;
        float degDiff = degBallToPlanet - degBatToPlanet;

        if( degDiff > margin ) {
            direction = 1.0f;
        } else if (degDiff < -margin ) {
            direction = -1.0f;
        }

        return direction;
    }

}
