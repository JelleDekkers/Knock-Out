using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Shield : MonoBehaviour {

    public UnityEvent onGloveBlocked;

    public void OnTriggerEnter(Collider collider) {
        Debug.Log("Blocked " + collider.gameObject.name);
        Glove glove = collider.gameObject.GetComponent<Glove>();
        if (glove != null) {
            glove.Enable(false);
            glove.SetCharge(0);
        }
        onGloveBlocked.Invoke();
    }
}
