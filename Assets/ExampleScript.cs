using UnityEngine;

public class ExampleScript : MonoBehaviour
{
    void OnCollisionStay(Collision collision)
    {
        foreach (ContactPoint contact in collision.contacts)
        {
            print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
            // Visualize the contact point
            Debug.Log("contact.point:" + contact.point);
            Debug.Log("contact.normal:" + contact.normal);
            Debug.DrawRay(contact.point, contact.normal, Color.red,10f);
        }
    }
}