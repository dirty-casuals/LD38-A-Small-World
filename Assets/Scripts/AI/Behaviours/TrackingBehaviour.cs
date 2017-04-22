using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBehaviour : MonoBehaviour {

    protected const float MAX_Z = 7.0f;
    protected const float MIN_Z = -7.0f;

	public virtual float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties){
        return 0.0f;
    }

}
