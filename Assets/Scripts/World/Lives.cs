using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Lives : MonoBehaviour {
    [SerializeField]
    private int numberStartLives = 5;

    private int numberLivesRemaining;
    private UnityEvent onLivesEmptyEvent = new UnityEvent();

    private void Awake() {
        numberLivesRemaining = numberStartLives;
    }

    private void RemoveLife() {
        numberLivesRemaining = numberLivesRemaining - 1;
    }

    private bool OutOfLives() {
        return numberLivesRemaining >= 0;
    }

    private void OnTriggerEnter(Collider other) {
        RemoveLife();

        if (OutOfLives()) {
            onLivesEmptyEvent.Invoke();
        }
    }

    public void AddListener(UnityAction listener) {
        onLivesEmptyEvent.AddListener(listener);
    }
}
