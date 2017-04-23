using UnityEngine;
using System.Collections.Generic;
using UnityEngine.Events;

[System.Serializable]
public class EndOfGameEvent : UnityEvent<bool> {

}

public class GameController : MonoBehaviour {

    public static float MAX_Z = 7.0f;
    public static float MIN_Z = -7.0f;

    [SerializeField]
    private Rigidbody ball;
    [SerializeField]
    private World[] worlds;
    private List<World> worldsAlive = new List<World>();

    private Vector3 ballStartPosition;
    [SerializeField]
    private EndOfGameEvent endOfGameEvent = new EndOfGameEvent();

    private void Start() {
        foreach( var world in worlds ) {
            world.AddHitListener( OnWorldHit );
            world.AddOutOfLivesListener( OnOutOfLives );
            worldsAlive.Add( world );
        }
        ballStartPosition = ball.transform.position;

        KickOff();
    }

    private void OnOutOfLives( int playerId, World world ) {
        if( playerId == 0 ) {
            endOfGameEvent.Invoke(true);
        } else {
            worldsAlive.Remove( world );
            Destroy( world.gameObject );

            if( worldsAlive.Count == 1 ) {
                endOfGameEvent.Invoke(false);
            }
        }
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
