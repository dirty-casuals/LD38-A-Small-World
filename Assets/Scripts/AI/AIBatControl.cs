using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIBatControl : MonoBehaviour {
    [SerializeField]
    private Ball ball;
    [SerializeField]
    private PaddleController paddleController;

	private void FixedUpdate() {
        Vector3 paddlePosition = paddleController.transform.position;
        Vector3 ballPosition = ball.transform.position;

        float direction = 0.0f;
        float ballZ = ballPosition.z;
        float paddleZ = paddlePosition.z;
        float positionDifference = ballZ - paddleZ;
        Debug.Log(positionDifference);
        if( positionDifference > 0 ) {
            direction = -1.0f;
        } else if( positionDifference < 0 ) {
            direction = 1.0f;
        }
        paddleController.Direction = direction;
	}
}
