using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class LivesEvent : UnityEvent<bool> {

}

public class Lives : MonoBehaviour {
    [SerializeField]
    private int numberStartLives = 5;
    [SerializeField]
    private bool isPlayer = false;

    public int numberLivesRemaining;
    private LivesEvent onLivesEmptyEvent = new LivesEvent();

    private void Awake() {
        numberLivesRemaining = numberStartLives;
    }

    private void RemoveLife() {
        numberLivesRemaining = numberLivesRemaining - 1;
    }

    private bool OutOfLives() {
        return numberLivesRemaining <= 0;
    }

    private void OnCollisionEnter(Collision other) {
        RemoveLife();

        if (OutOfLives()) {
            onLivesEmptyEvent.Invoke(isPlayer);
        }
    }

    public void AddListener(UnityAction<bool> listener) {
        onLivesEmptyEvent.AddListener(listener);
    }
}
