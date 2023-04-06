using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallGenerator : MonoBehaviour
{
    public GameObject BallPrefab,CurrentBall;
    public Transform InitialReference;
    // Start is called before the first frame update
    void Start()
    {
        if(CurrentBall==null)
        {
            CurrentBall = Instantiate(BallPrefab);
            CurrentBall.transform.position = InitialReference.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ResetBall()
    {
        //ʵ��ʹ��
        Destroy(CurrentBall);
        CurrentBall = Instantiate(BallPrefab);
        CurrentBall.transform.position = InitialReference.position;
        //����ʹ��
        //Rigidbody rb = CurrentBall.GetComponent<Rigidbody>();
        //rb.velocity = Vector3.zero;
        //rb.angularVelocity = Vector3.zero;
        //CurrentBall.transform.position = InitialPosition;
    }
}
