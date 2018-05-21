using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockManager : MonoBehaviour {

    public Transform rightGlove, leftGlove;
    public GameObject shieldObject;
    public float maxDistanceBetweenGloves;
    public float maxYRotation, maxZRotation, maxXRotation;
    public BoolVariable isBlocking;
    public float maxBlockTime, minChargeNecessaryForBlock;
    public float chargeAddedOnBlock = 1;
    public FloatVariable blockCharge;
    
    private void Update() {
        //if (IsBlocking())
        //    ShieldUpTimer();
        //else
        //    ResetTimer();

        isBlocking.runTimeValue = IsBlocking();
        shieldObject.SetActive(isBlocking.runTimeValue);
        if (isBlocking.runTimeValue)
            Block();
    }

    private void Block() {
        shieldObject.transform.position = (rightGlove.position + leftGlove.position) / 2;
        Quaternion rot = Quaternion.Slerp(rightGlove.rotation, leftGlove.rotation, 0.5f);
        shieldObject.transform.rotation = rot;
    }

    private void ShieldUpTimer() {
        if (blockCharge.runTimeValue > 0)
            blockCharge.runTimeValue -= Time.deltaTime;
    }

    private void ResetTimer() {
        if (blockCharge.runTimeValue < maxBlockTime)
            blockCharge.runTimeValue += Time.deltaTime;
    }

    private bool IsBlocking() {
        return GloveRequirementsAreMet() && blockCharge.runTimeValue > 0; 
    }

    private bool GloveRequirementsAreMet() {
        return Vector3.Distance(rightGlove.position, leftGlove.position) < maxDistanceBetweenGloves &&
               Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x) < maxXRotation &&
               Mathf.Abs(leftGlove.transform.rotation.y - rightGlove.transform.rotation.y) < maxYRotation &&
               Mathf.Abs(leftGlove.transform.rotation.z - rightGlove.transform.rotation.z) < maxZRotation;
    }

    public void ResetCharge() {
        blockCharge.runTimeValue = maxBlockTime;
    }

    private void OnGUI() {
        GUILayout.BeginVertical();
        GUILayout.Label("isblocking: " + IsBlocking());
        GUILayout.Label("charge: " + blockCharge.runTimeValue);
        //    GUILayout.Label("CONDITIONS MET: " + conditionsMet.runTimeValue);
        //    GUILayout.Label("Distance " + Vector3.Distance(rightGlove.position, leftGlove.position));
        //    GUILayout.Label("angle dif X " + Mathf.Abs(leftGlove.transform.rotation.x - rightGlove.transform.rotation.x));
        GUILayout.EndVertical();
    }
}
