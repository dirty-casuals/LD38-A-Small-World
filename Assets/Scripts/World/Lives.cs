﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class OutOfLivesEvent : UnityEvent<int, World> {
}

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
    private OutOfLivesEvent onLivesEmptyEvent = new OutOfLivesEvent();

    [SerializeField]
    private AudioClip hurtSFX;

    [SerializeField]
    private AudioClip explosionSFX;

    private static Dictionary<int, Lives> livesByPlayerId;

    public int PlayerId {
        get { return playerId; }
        set { playerId = value; }
    }

    public int NumberStartLives {
        get { return numberStartLives; }
        set { numberStartLives = value; }
    }

    private void Awake() {
        numberLivesRemaining = NumberStartLives;
    }

    private void RemoveLife() {
        numberLivesRemaining = numberLivesRemaining - 1;
        onLivesChanged.Invoke( playerId );
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
            onLivesEmptyEvent.Invoke( PlayerId, GetComponent<World>() );
            AudioManager.PlayEffect( explosionSFX );
        } else {
            AudioManager.PlayEffect( hurtSFX );
        }
    }

    public void AddOutOfLivesListener( UnityAction<int, World> listener ) {
        onLivesEmptyEvent.AddListener( listener );
    }

    public void AddLivesChangedListener( UnityAction<int> listener ) {
        onLivesChanged.AddListener( listener );
    }

    public static Lives GetLivesForPlayer( int playerId ) {
        if( livesByPlayerId == null ) {
            livesByPlayerId = new Dictionary<int, Lives>();
        }

        Lives lives = null;
        livesByPlayerId.TryGetValue( playerId, out lives );
        if( !lives ) {
            Lives[] allLives = FindObjectsOfType<Lives>();
            foreach( Lives currentLives in allLives ) {
                livesByPlayerId[currentLives.playerId] = currentLives;
                if( currentLives.playerId == playerId ) {
                    lives = currentLives;
                }
            }
        }

        return lives;
    }

}
