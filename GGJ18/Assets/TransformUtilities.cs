using UnityEngine;
using System.Collections;

public static class TransformUtilities{

    public static void RotateTowards(GameObject objectToRotate, Vector3 target, float rotationSpeed) {
        Vector3 direction = (target - objectToRotate.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        objectToRotate.transform.rotation = Quaternion.Slerp(objectToRotate.transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
    }
}
