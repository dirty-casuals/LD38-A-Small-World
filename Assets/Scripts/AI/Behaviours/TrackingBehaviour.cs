using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingBehaviour : MonoBehaviour {

	public virtual float GetNextDirection(BallProperties ballProperties,
                                           PaddleProperties paddleProperties){
        return 0.0f;
    }

}
