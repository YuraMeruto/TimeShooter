using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundMove : MonoBehaviour {

    [SerializeField]
    private float MaxMoveDistance;
    [SerializeField]
    private float MoveForce;
    private float MoveTime;
    private Vector3 DefaltPos;
    private WorldTime worldtime;
    private GameObject WorldTimeObj;
	// Use this for initialization
	void Start () {
        WorldTimeObj = GameObject.Find("Master");
        worldtime = WorldTimeObj.GetComponent<WorldTime>();
        DefaltPos = transform.position;
        DefaltPos.x = -MaxMoveDistance;
	}
	
	// Update is called once per frame
	void Update () {
        float Speed = worldtime.GetTime();
        transform.Translate(MoveForce * Speed,0,0);
        if(transform.position.x>=MaxMoveDistance)
        {
      
            transform.position = DefaltPos;
        }
	}
}
