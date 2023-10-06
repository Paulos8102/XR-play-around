using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UILookAt : MonoBehaviour
{
    public Transform target;

    private void LateUpdate()
    {
        transform.LookAt(target, Vector3.up);
    }
}
