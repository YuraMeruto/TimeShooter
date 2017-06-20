using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int Hp;
    [SerializeField]
    private float InstanceHormingTime;
    [SerializeField]
    private GameObject HormingObj;
    private float CopyTime;
    private GameObject WorldTimeObj;
    private WorldTime worldtime;
    // Use this for initialization
    void Start () {
        WorldTimeObj = GameObject.Find("Master");
        worldtime = WorldTimeObj.GetComponent<WorldTime>();
        CopyTime = InstanceHormingTime;
	}
	
	// Update is called once per frame
	void Update () {
        float WorldTimeSpeed = worldtime.GetTime();
        InstanceHormingTime -= Time.deltaTime * WorldTimeSpeed;
        if(InstanceHormingTime<=0)
        {
            InstanceHormingTime = CopyTime;
            Instantiate(HormingObj,transform.position,HormingObj.transform.rotation);
        }
	}
    void OnTriggerEnter2D(Collider2D col)
    {
      //  Debug.Log("hogehoge");
        if (col.gameObject.tag == "Weapon")
        {
            Hp--;
        }
        if(Hp<=0)
        {
            Destroy(gameObject);
        }
    }
}
