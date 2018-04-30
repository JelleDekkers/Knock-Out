using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HittableLimb : MonoBehaviour, IPunchable {
    public void Hit(PunchInfo info) {
        Debug.Log("hit " + name);
        // send information to player in parent transform
        // of met een onHit event
    }
}
