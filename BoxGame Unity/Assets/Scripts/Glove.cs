using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Glove : MonoBehaviour {

    private Vector3 positionPrevFrame;

    private void OnTriggerEnter(Collider collider) {
        IPunchable punchableObject = collider.gameObject.GetInterface<IPunchable>();
        if (punchableObject != null) {
            float velocity = Helper.GetVelocity(transform.position, positionPrevFrame);
            punchableObject.Hit(new PunchInfo(collider, transform.position, velocity));
        }
    }

    private void LateUpdate() {
        positionPrevFrame = transform.position;
    }
}
