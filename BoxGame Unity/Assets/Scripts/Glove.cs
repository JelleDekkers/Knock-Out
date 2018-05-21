using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Glove : MonoBehaviour {

    public FloatVariable charge;
    public bool isEnabled;
    public float chargeMax = 5;

    private Vector3 positionPrevFrame;

    private void OnTriggerEnter(Collider collider) {
        if (!isEnabled)
            return;

        IPunchable punchableObject = collider.gameObject.GetInterface<IPunchable>();
        if (punchableObject != null)
            PunchableObjectHit(collider, punchableObject);
    }

    private void PunchableObjectHit(Collider collider, IPunchable punchableObject) {
        float velocity = CalculateVelocity(transform.position, positionPrevFrame);
        punchableObject.Hit(new PunchInfo(collider, transform.position, velocity, charge.runTimeValue));
    }

    private void LateUpdate() {
        positionPrevFrame = transform.position;
    }

    public float CalculateVelocity(Vector3 position, Vector3 positionPrevFrame) {
        return (position - positionPrevFrame).magnitude / Time.deltaTime;
    }

    public void AddCharge(float charge) {
        this.charge.runTimeValue += charge;
        if (this.charge.runTimeValue > chargeMax)
            this.charge.runTimeValue = chargeMax;
    }

    public void SetCharge(float charge) {
        this.charge.runTimeValue = charge;
        if (this.charge.runTimeValue > chargeMax)
            this.charge.runTimeValue = chargeMax;
    }

    public void Enable(bool enable) {
        isEnabled = enable;
    }
}
