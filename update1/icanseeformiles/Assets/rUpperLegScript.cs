using UnityEngine;
using System.Collections;

public class rUpperLegScript : MonoBehaviour
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
        //Application.CaptureScreenshot("screenCapture/test" + count.ToString() + ".png");
        Hvalue = Input.GetAxis("Horizontal");
        Vvalue = Input.GetAxis("Vertical");

        //For controller 2 
        //  dcount = Mathf.Clamp(dcount - (int)Vvalue, 10, 100);
        dcount = (int)(10 + (100 - 10) * (Vvalue + 1) / 2);

        if (Input.GetButtonDown("walk"))
        {
            walk = !walk;
        }
        if (Input.GetButtonDown("switch"))
        {
            controller = !controller;
        }
        if (walk)
        {
            if (controller)
            { //Controller 1
                if (Vvalue > 0)
                {
                    ang_d = state2 + (state1 - state2) * (Vvalue);
                }
                else if (baseScript.hitGround)
                {
                    ang_d = state2;
                }
            }
            else
            { //Controller 2 
                if (Time.frameCount - oldFrameCount >= dcount)
                {
                    toggleFlag = !toggleFlag;
                    oldFrameCount = Time.frameCount;
                }
                if (toggleFlag)
                {
                    ang_d = state1;
                }
                else
                {
                    ang_d = state2;
                }
            }
        }
        else
        {
            ang_d = state2;
        }
        //freeze the movement in x Axis
        rb.constraints = RigidbodyConstraints.FreezePositionX;

        ang_v = rb.angularVelocity;

        curr_angle = hg.angle;

        //torque = k * (curr_angle - ang_d) - d * (ang_v.x) - ad* torque;
        torque = k * (curr_angle - ang_d) - d * (ang_v.x) - ad * torque;

        //torque = k * (curr_angle - ang_d) - d* (curr_angle - ang_d)/(state2-state1) * (curr_angle - ang_d)/(state2-state1);
        rb.AddTorque(torque, 0, 0);
        count++;
    }
}
