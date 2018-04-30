using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Transform rightGlove, leftGlove;
    public GameObject shieldObject;
    public BoolVariable conditionsMet;
    public float maxDistanceBetweenGloves;
    public float maxYRotation, maxZRotation, maxXRotation;

    public void Update() {
        conditionsMet.runTimeValue = RequirementsAreMet();
        shieldObject.SetActive(conditionsMet.runTimeValue);
        if (conditionsMet.runTimeValue == false)
            return;

        shieldObject.transform.position = (rightGlove.position + leftGlove.position) / 2;
        Quaternion rot = Quaternion.Slerp(rightGlove.rotation, leftGlove.rotation, 0.5f);
        shieldObject.transform.rotation = rot;
    }

    public bool RequirementsAreMet() {
        return (Vector3.Distance(rightGlove.position, leftGlove.position) < maxDistanceBetweenGloves) &&
               (Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x) < maxXRotation) &&
               (Mathf.Abs(leftGlove.transform.rotation.y - rightGlove.transform.rotation.y) < maxYRotation) &&
               (Mathf.Abs(leftGlove.transform.rotation.z - rightGlove.transform.rotation.z) < maxZRotation);
    }

    //private void OnGUI() {
    //    GUILayout.BeginVertical();
    //    GUILayout.Label("CONDITIONS MET: " + conditionsMet.runTimeValue);
    //    GUILayout.Label("Distance " + Vector3.Distance(rightGlove.position, leftGlove.position));
    //    GUILayout.Label("angle dif X " + Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x));
    //    GUILayout.EndVertical();
    //}
}
