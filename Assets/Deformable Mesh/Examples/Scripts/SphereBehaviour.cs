using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereBehaviour : MonoBehaviour
{
    Rigidbody rb;
    float mass;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {      
    }

    public void OnCollisionStay (Collision collision) {
        if (collision.transform.gameObject.tag == "DeformableMesh") {
            MeshDeformer meshDeformer = collision.transform.GetComponent<MeshDeformer> ();
            ContactPoint[] contactPoints = new ContactPoint[collision.contactCount];
            collision.GetContacts (contactPoints);
            foreach (ContactPoint contactPoint in contactPoints) {
                meshDeformer.Deform (contactPoint.point, 0.1f * mass, 0.05f, -0.5f, -0.05f, Vector3.up);
            }
        }
    }
}
