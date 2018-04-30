using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Glove : MonoBehaviour {

    private Vector3 positionPrevFrame;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("hit: " + other.gameObject.name + " force: " + Helper.GetVelocity(transform.position, positionPrevFrame));
    }

    private void LateUpdate() {
        positionPrevFrame = transform.position;
    }
}
