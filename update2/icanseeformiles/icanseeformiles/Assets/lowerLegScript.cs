using UnityEngine;
using System.Collections;

public class lowerLegScript : MonoBehaviour {
    public Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

    }
	
	// Update is called once per frame
	void Update () {
        rb.constraints = RigidbodyConstraints.FreezePositionX;
	
	}
}
