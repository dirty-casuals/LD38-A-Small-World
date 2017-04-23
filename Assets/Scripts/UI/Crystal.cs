using System;
using UnityEngine;
using UnityEngine.UI;

public class Crystal : MonoBehaviour {

    private Image image;

    [SerializeField]
    private Sprite _crystalOnImage;

    [SerializeField]
    private Sprite _crystalOffImage;

    private void Start() {
        image = GetComponent<Image>();
        image.sprite = _crystalOnImage;
    }

    public void SetLit( bool isLit ) {
        image.sprite = isLit ? _crystalOnImage : _crystalOffImage;
    }
}
