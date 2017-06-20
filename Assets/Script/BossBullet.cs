using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour {

    [SerializeField]
    private float MoveForceX;
    [SerializeField]
    private float MoveForceY;
    private GameObject WorldTimeObj;
    private WorldTime worldtime;
    private float AddX= 0.01f;
    private float AddY = 0.01f;
    private float RotationForce =10.0f;
    // Use this for initialization
    void Start () {
        WorldTimeObj = GameObject.Find("Master");
        worldtime = WorldTimeObj.GetComponent<WorldTime>();
    }
	
	// Update is called once per frame
	void Update () {
        float WorldTimeSpeed = worldtime.GetTime();
        transform.Translate(MoveForceX * WorldTimeSpeed, MoveForceY * WorldTimeSpeed,0.0f, Space.World);
        transform.Rotate(0,0,RotationForce * WorldTimeSpeed);
	}   

    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("aaaaaa");
        if(col.gameObject.tag == "WallX")
        {
            MoveForceX = -MoveForceX;
            AddX = -AddX;
            MoveForceX += AddX;
            RotationForce++;
        }

        if (col.gameObject.tag == "WallY")
        {
            MoveForceY = -MoveForceY;
            AddY = -AddY;
            MoveForceY += AddY;
            RotationForce++;
        }
    }
}
