using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct BallProperties {
    public Vector3 position;
}

public struct PaddleProperties {
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

        paddleProperties.position = paddleController.transform.position;
        ballProperties.position = ball.transform.position;

        float direction = trackingBehaviour.GetNextDirection(
            ballProperties,
            paddleProperties
        );

        
        paddleController.Direction = direction;
	}
}
