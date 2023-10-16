using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMove : MonoBehaviour
{
    public float gS; //general speed

    [SerializeField] private float XDis = 5.0f;
    [SerializeField] private float YDis = 0;
    [SerializeField] private float ZDis = 0;

    private Vector3 _startPosition;

    [SerializeField] private float radialSpeed = 50.0f;

    private void Start()
    {
        _startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * radialSpeed * Time.deltaTime);

        transform.position = _startPosition + new Vector3(Mathf.Sin(Time.time * gS) * XDis, Mathf.Sin(Time.time * gS) * YDis, Mathf.Sin(Time.time * gS) * ZDis);
    }
}
