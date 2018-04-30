using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helper {

	public static float GetVelocity(Vector3 position, Vector3 positionPrevFrame) {
        return (position - positionPrevFrame).magnitude / Time.deltaTime;
    }
}
