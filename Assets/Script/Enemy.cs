using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField]
    private int Hp;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
        Debug.Log("hogehoge");
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
