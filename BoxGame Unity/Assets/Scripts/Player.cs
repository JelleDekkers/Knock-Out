using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float startingHealth = 100;
    // syncVar?
    public float healthPoints;
    public FloatVariable damageMax;
    public FloatVariable damagePerVelocity;

    private void Start() {
        healthPoints = startingHealth;

        foreach(HittableLimb limb in GetComponentsInChildren<HittableLimb>()) 
            limb.onHit += ProcessHit;
    }

    public void ProcessHit(PunchInfo info, float damageMultiplier) {
        float damage = CalculateDamage(info.velocity, damageMultiplier);
        healthPoints -= damage;
        Debug.Log("damage: " + damage);
        if (healthPoints <= 0)
            KnockOut();
    }

    private float CalculateDamage(float velocity, float multiplier) {
        float damage = velocity * damagePerVelocity.runTimeValue * multiplier;
        if (damage > damageMax.runTimeValue)
            damage = damageMax.runTimeValue;
        return damage;
    }

    private void KnockOut() {
        Debug.Log("KNOCK-OUT");
    }
}
