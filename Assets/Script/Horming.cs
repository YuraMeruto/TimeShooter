using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horming : MonoBehaviour {

    [SerializeField]
    private GameObject TargetObj;
    [SerializeField]
    private float MoveSpeed;
    Vector3 vec;
    [SerializeField]
    private float MaxHormingTime;
    private float HormingTime = 0.0f;
    private GameObject WorldTimeObj;
    private WorldTime worldtime;

    void Start () {
        TargetObj = GameObject.Find("Player");
        WorldTimeObj = GameObject.Find("Master");
        worldtime = WorldTimeObj.GetComponent<WorldTime>();
        vec = (TargetObj.transform.position - transform.position).normalized;
        Destroy(gameObject,10);
    }

    // Update is called once per frame
    void Update () {
        float WorldTimeSpeed = worldtime.GetTime();
        if (HormingTime <= MaxHormingTime)
        {
            vec = (TargetObj.transform.position - transform.position).normalized;
            HormingTime += Time.deltaTime;
        }
        transform.rotation = Quaternion.FromToRotation(Vector3.right,vec);
        transform.position += vec * MoveSpeed * WorldTimeSpeed;
	}

    public void TargetSetObj(GameObject setobj)
    {
        TargetObj = setobj;
    }
}
