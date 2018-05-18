using System;
using UnityEngine;

public class HittableLimb : MonoBehaviour, IPunchable {

    public FloatVariable damagePercentage;
    public Action<PunchInfo, float> onHit;

    private Player player;

    private void Start() {
        player = GetComponentInParent<Player>();
    }

    public void Hit(PunchInfo info) {
        float multiplier = info.velocity / 100 * damagePercentage.runTimeValue;
        if (onHit != null)
            onHit.Invoke(info, multiplier);
    }
}
