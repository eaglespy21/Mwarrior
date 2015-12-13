using UnityEngine;
using System.Collections;

public class bodyScript : MonoBehaviour {
	public Rigidbody rb;
	public HingeJoint lhg;
	public HingeJoint rhg;
	//public Vector3 val_ang_v;
	public static Vector3 ang_v;
	public static Vector3 ang_a;
	public static Vector3 V_v;
	public float curr_angle;
	public float ang_d;
	public float k;
	public float fk;
	public float d;
	public float fd;
	public float ad;
	public float fad;
	public float torque;
	public float force;	
	public float y_d;
	public float current_y;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		lhg = GetComponent<HingeJoint>();
		rhg = GetComponent<HingeJoint>();
		y_d = 20;
	}
	
	// Update is called once per frame
	void Update () {
		rb.constraints = RigidbodyConstraints.FreezePositionX;

		current_y = rb.position.y;

		ang_v = rb.angularVelocity;
		//ang_d = 30;
		if (Input.GetButtonDown ("l")) {
			ang_d+=1;
		}
		if (Input.GetButtonDown ("o")) {
			ang_d-=1;
		}
		curr_angle = lhg.angle; 
		//torque = k * (curr_angle - ang_d) - d * (ang_v.x);
		
		torque = k * (curr_angle - ang_d) - d * (ang_v.x) - ad * torque;
		//torque = k * (curr_angle - ang_d) - d* (curr_angle - ang_d)/(state2-state1) * (curr_angle - ang_d)/(state2-state1);
		rb.AddTorque(torque, 0, 0);

		force = fk * (current_y - y_d) + fd*(rb.velocity.y) - fad * force;

		rb.AddForce (0, -force, 0);



	}
}
