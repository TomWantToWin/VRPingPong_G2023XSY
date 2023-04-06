using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    private Transform Transform;
    private Vector3 InitialPosition;
    private Rigidbody Rigidbody;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        Transform = GetComponent<Transform>();
        InitialPosition = Transform.position;
        Rigidbody = GetComponent<Rigidbody>();
        Rigidbody.isKinematic = Rigidbody.isKinematic ? Rigidbody.isKinematic : true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if(Transform.position.y<1.0f)
        {
            Transform.position += new Vector3(0, speed * Time.fixedDeltaTime, 0);
        }
        else
        {
            Transform.position = InitialPosition;
        }
    }
}
