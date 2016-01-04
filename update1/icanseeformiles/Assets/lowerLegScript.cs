using UnityEngine;
using System.Collections;

public class lowerLegScript : MonoBehaviour
{
    public Rigidbody rb;
    public HingeJoint hg;
    //public Vector3 val_ang_v;
    public static Vector3 ang_v;
    public float state1;
    public float state2;
    public float ang_d;
    public float curr_angle;
    public float k;
    public float d;
    public float ad;
    public float torque;
    public bool walk;
    public float Hvalue;
    public float Vvalue;
    public bool key1;
    public float Jvalue;
    public int count = 0;
    public bool controller = true;
    public int oldFrameCount;
    public int dcount;
    public bool toggleFlag;


    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        hg = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        
        //freeze the movement in x Axis
        rb.constraints = RigidbodyConstraints.FreezePositionX;

    }
}
