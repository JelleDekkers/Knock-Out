using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Glove : MonoBehaviour {

    private Vector3 positionPrevFrame;

    private void OnTriggerEnter(Collider collider) {
        IPunchable punchableObject = collider.gameObject.GetInterface<IPunchable>();
        if (punchableObject != null)
            punchableObject.Hit(new PunchInfo(collider, transform.position, Helper.GetVelocity(transform.position, positionPrevFrame)));
    }

    private void LateUpdate() {
        positionPrevFrame = transform.position;
    }
}
