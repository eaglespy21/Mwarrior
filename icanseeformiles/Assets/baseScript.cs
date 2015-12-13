using UnityEngine;
using System.Collections;

public class baseScript : MonoBehaviour {
    public Rigidbody rb;
    static public bool hitGround = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void Update () {
        rb.constraints = RigidbodyConstraints.FreezePositionX;
	
	}
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.name == "Plane")
        {
            hitGround = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if(col.gameObject.name == "Plane")
        {
            hitGround = false;
        }
    }
}
