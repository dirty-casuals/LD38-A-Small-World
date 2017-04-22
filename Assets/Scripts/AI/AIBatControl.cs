using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BallProperties {
    public Vector3 position;
}

public struct PaddleProperties {
    public Vector3 position;
}

public struct PlanetProperties {
    public Vector3 position;
}

public class AIBatControl : MonoBehaviour {
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private PaddleController paddleController;
    [SerializeField]
    private TrackingBehaviour trackingBehaviour;

	private void FixedUpdate() {
        PaddleProperties paddleProperties = new PaddleProperties();
        BallProperties ballProperties = new BallProperties();
        PlanetProperties planetProperties = new PlanetProperties();

        paddleProperties.position = paddleController.transform.position;
        ballProperties.position = ball.transform.position;
        planetProperties.position = paddleController.Planet.transform.position;

        float direction = trackingBehaviour.GetNextDirection(
            ballProperties,
            paddleProperties,
            planetProperties
        );
        paddleController.Direction = direction;
	}   
}
