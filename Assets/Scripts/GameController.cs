using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Rigidbody ball;

    private void Start() {

        float randomAngle = Random.value;
        Vector3 randomDirection = new Vector3(
            Mathf.Cos( randomAngle ),
            0,
            Mathf.Sin( randomAngle ) );

        ball.AddForce( randomDirection * 10, ForceMode.Impulse );
    }

}
