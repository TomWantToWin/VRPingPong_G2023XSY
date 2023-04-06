using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem.XR.Haptics;

public class Bat_Force : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private Vector3 lastPosition;

    [SerializeField]
    private Vector3 currentPosition;

    [SerializeField]
    private Vector3 lastVelocity;

    [SerializeField]
    private Vector3 currentVelocity;

    [SerializeField]
    private Vector3 impulse;

    public float limiter;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        lastVelocity = new Vector3(0f, 0f, 0f);
        currentVelocity = new Vector3(0f, 0f, 0f);
        impulse = Vector3.zero;
        lastPosition = transform.position;
        currentPosition = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        lastPosition = currentPosition;
        currentPosition = transform.position;
        lastVelocity = currentVelocity;
        currentVelocity = (currentPosition - lastPosition) / Time.fixedDeltaTime;
        impulse = currentVelocity * rb.mass;
    }

    public Vector3 getImpulse()
    {
        return impulse / (limiter*limiter);
    }

}
