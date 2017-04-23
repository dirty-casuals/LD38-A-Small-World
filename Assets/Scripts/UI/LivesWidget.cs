using System;
using UnityEngine;

public class LivesWidget : MonoBehaviour {

    [SerializeField]
    private Crystal _crystalPrefab;

    [SerializeField]
    private int _playerId;

    private Crystal[] crystals;
    private Lives lives;

    // Use this for initialization
    void Start() {
        lives = Lives.GetLivesForPlayer( _playerId );
        lives.AddLivesChangedListener( UpdateLives );
        int numLives = lives.NumberStartLives;
        crystals = new Crystal[numLives];

        for( int i = 0; i < numLives; i++ ) {
            Crystal crystal = Instantiate( _crystalPrefab );
            crystal.transform.SetParent( transform, false );
            crystal.transform.localRotation = Quaternion.Euler( 0, 0, 360.0f * i / ( numLives ) );
            crystals[i] = crystal;
        }
    }

    private void UpdateLives( int playerId ) {
        for( int i = 0; i < lives.NumberStartLives; i++ ) {
            crystals[i].SetLit( i < lives.numberLivesRemaining );
        }
    }

    // Update is called once per frame
    void Update() {

    }
}
