using System;
using UnityEngine;

public class HittableLimb : MonoBehaviour, IPunchable {

    public FloatVariable damageMultiplier;
    public Action<PunchInfo, float> onHit;
    public FloatVariable damageMax;
    public FloatVariable damagePerVelocity;

    private Player player;

    private void Start() {
        player = GetComponentInParent<Player>();
    }

    public void Hit(PunchInfo info) {
        if (onHit != null)
            onHit.Invoke(info, CalculateDamage(info.velocity, damageMultiplier.runTimeValue));
    }

    private float CalculateDamage(float velocity, float multiplier) {
        Debug.Log(velocity);
        float damage = velocity * damagePerVelocity.runTimeValue / 100 * multiplier;
        return (damage > damageMax.runTimeValue) ? damageMax.runTimeValue : damage;
    }
}
