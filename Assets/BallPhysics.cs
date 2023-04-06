using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallPhysics : MonoBehaviour
{
    private LayerMask CastMask;

    [SerializeField]
    private Vector3 lastFramePosition;

    [SerializeField]
    private Vector3 currentFramePosition;

    private Rigidbody rb;

    [SerializeField]
    private Vector3 velocity;

    private Transform ballTransform;

    public float minVelocity = 1;

    private Camera MainCamera;

    // Start is called before the first frame update
    void Awake()
    {
        lastFramePosition = transform.position;
        currentFramePosition = transform.position;
        rb = GetComponent<Rigidbody>();
        ballTransform = GetComponent<Transform>();
        MainCamera = FindObjectOfType<Camera>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Racket")
        {
            Vector3 racketImpulse = collision.gameObject.GetComponent<Bat_Force>().getImpulse();
            Vector3 localHitPoint = collision.contacts[0].point - ballTransform.position;
            rb.AddForceAtPosition(racketImpulse,localHitPoint,ForceMode.Impulse);
            Debug.Log("BallPhysicsÖÐµÄracketForce£º" + racketImpulse);
        }
        if (collision.gameObject.tag == "Wall")
        {
            var speed = rb.velocity.magnitude;
            var direction = Vector3.Reflect(velocity.normalized, collision.contacts[0].normal);
            GetComponent<Rigidbody>().velocity = direction * (Mathf.Max(speed, minVelocity));
        }
        if (collision.gameObject.tag == "MagicWall") 
        {
            var speed = rb.velocity.magnitude;
            var direction = (MainCamera.transform.position - collision.contacts[0].point).normalized;
            rb.velocity = direction * (Mathf.Max(speed, minVelocity));
        }
    }
}


