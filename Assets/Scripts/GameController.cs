using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    [SerializeField]
    private Rigidbody ball;
    [SerializeField]
    private Planet[] worlds;

    private Vector3 ballStartPosition;

    private void Start() {
        foreach (var world in worlds)
        {
            world.AddHitListener(OnWorldHit);
        }
        ballStartPosition = ball.transform.position;

        KickOff();
    }

    private void OnWorldHit() {
        Reset();
    }

    private void KickOff() {
        float randomAngle = Random.value;
        Vector3 randomDirection = new Vector3(
            Mathf.Cos( randomAngle ),
            0,
            Mathf.Sin( randomAngle ) );

        ball.AddForce( randomDirection * 10, ForceMode.Impulse );
    }

    public void Reset() {
        ball.transform.position = ballStartPosition;
        ball.velocity = Vector3.zero;
        KickOff();
    }

}
