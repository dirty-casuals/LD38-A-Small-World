using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LivesEvent : UnityEvent<int> {

}

public class Lives : MonoBehaviour {

    [SerializeField]
    private int numberStartLives = 5;
    [SerializeField]
    private int playerId = 0;

    public int numberLivesRemaining;

    [SerializeField]
    private LivesEvent onLivesChanged;
    [SerializeField]
    private LivesEvent onLivesEmptyEvent;



    private void Awake() {
        numberLivesRemaining = numberStartLives;
    }

    private void RemoveLife() {
        numberLivesRemaining = numberLivesRemaining - 1;
    }

    private bool OutOfLives() {
        return numberLivesRemaining <= 0;
    }

    private void OnCollisionEnter( Collision other ) {
        var ball = other.transform.GetComponent<Ball>();
        if( !ball ) {
            return;
        }

        RemoveLife();

        if( OutOfLives() ) {
            onLivesEmptyEvent.Invoke( playerId );
        }
    }

    public void AddOutOfLivesListener( UnityAction<int> listener ) {
        onLivesEmptyEvent.AddListener( listener );
    }

    public void AddLivesChangedListener( UnityAction<int> listener ) {
        onLivesChanged.AddListener( listener );
    }
}
