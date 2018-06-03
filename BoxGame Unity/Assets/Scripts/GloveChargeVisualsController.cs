using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GloveChargeVisualsController : MonoBehaviour {

    public FloatVariable charge;

    private Material material;

    private void Start() {
        material = GetComponent<Renderer>().material;
    }

    private void Update() {
        AdjustMaterialTransparency(charge.runTimeValue);
    }

    private void AdjustMaterialTransparency(float transparency) {
        Color color = material.color;
        color.a = (transparency < 1) ?  transparency : 1;
        material.color = color;
    }
}
