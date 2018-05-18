using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Glove : MonoBehaviour {

    private Vector3 positionPrevFrame;

    private void OnTriggerEnter(Collider collider) {
        IPunchable punchableObject = collider.gameObject.GetInterface<IPunchable>();
        if (punchableObject != null) {
            float velocity = CalculateVelocity(transform.position, positionPrevFrame);
            punchableObject.Hit(new PunchInfo(collider, transform.position, velocity));
        }
    }

    private void LateUpdate() {
        positionPrevFrame = transform.position;
    }

    public float CalculateVelocity(Vector3 position, Vector3 positionPrevFrame) {
        return (position - positionPrevFrame).magnitude / Time.deltaTime;
    }
}
