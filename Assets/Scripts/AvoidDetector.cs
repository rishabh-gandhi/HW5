﻿using UnityEngine;

public class AvoidDetector : MonoBehaviour {

    public float avoidPath = 0.0f;
    public float avoidTime = 0.0f;
    public float wanderDistance = 4.0f;
    public float avoidLength = 1.0f;

    private void OnCollisionExit(Collision collision) {

        if (collision.gameObject.tag != "car") return;
        avoidTime = 0.0f;
    }

    private void OnCollisionStay(Collision collision) {

        if (collision.gameObject.tag != "car") return;

        Rigidbody otherCar = collision.rigidbody;
        avoidTime = Time.time + avoidLength;

        Vector3 otherCarLocalTarget = transform.InverseTransformPoint(otherCar.gameObject.transform.position);
        float otherCarAngle = Mathf.Atan2(otherCarLocalTarget.x, otherCarLocalTarget.z);
        avoidPath = wanderDistance * -Mathf.Sign(otherCarAngle);
    }
}
