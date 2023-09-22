using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    [SerializeField] private float XBoxSpeed = 5.0f;
    [SerializeField] private float YBoxSpeed = 0;
    [SerializeField] private float ZBoxSpeed = 0;

    private Vector3 _startPosition;

    private void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time) * XBoxSpeed, Mathf.Sin(Time.time) * YBoxSpeed, Mathf.Sin(Time.time) * ZBoxSpeed);
    }
}
