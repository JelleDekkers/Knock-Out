using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchInfo  {

    public Collider collider;
    public Vector3 position;
    public float velocity;

    public PunchInfo(Collider collider, Vector3 position, float velocity) {
        this.collider = collider;
        this.position = position;
        this.velocity = velocity;
    }
}
