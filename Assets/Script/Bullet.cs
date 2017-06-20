using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    private float MoveForce;
    private GameObject WorldTimeObj;
    private WorldTime worldtime;
    [SerializeField]
    private float DestroyTime;
	// Use this for initialization
	void Start () {
        Destroy(gameObject,DestroyTime);
        WorldTimeObj = GameObject.Find("Master");
        worldtime = WorldTimeObj.GetComponent<WorldTime>();
	}
	
	// Update is called once per frame
	void Update () {
        
        float WorldTime = worldtime.GetTime();
        transform.Translate(MoveForce* WorldTime,0,0);
	}
}
