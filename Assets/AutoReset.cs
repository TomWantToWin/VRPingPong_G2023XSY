using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoReset : MonoBehaviour
{
    Rigidbody Rigidbody;
    BallGenerator BallGenerator;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody = GetComponent<Rigidbody>();
        BallGenerator = FindObjectOfType<BallGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Rigidbody.velocity==Vector3.zero)
        {
            BallGenerator.ResetBall();
        }
    }
}
