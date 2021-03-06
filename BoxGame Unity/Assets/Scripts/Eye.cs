﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eye : MonoBehaviour {

    public Transform target;

    public FloatMinMax xClamp, yClamp, zClamp;

    private Vector3 originalRot;

    private void Start() {
        originalRot = transform.eulerAngles;
    }

    public void LateUpdate() {
        if (target != null) {

            transform.LookAt(target);
            Vector3 rot = transform.eulerAngles;
            rot.x = Helper.ClampAngle(rot.x, xClamp.min, xClamp.max) ;
            rot.y = Helper.ClampAngle(rot.y, yClamp.min, yClamp.max) ;
            rot.z = Helper.ClampAngle(rot.z, zClamp.min, zClamp.max) ;
            transform.eulerAngles = rot;

        } else {
            transform.eulerAngles = originalRot;
        }
    }

}
