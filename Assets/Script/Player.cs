using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float MoveForce;
    private int MoveKey;
    private Vector3 MovePos;
    [SerializeField]
    private GameObject Bullet;
    [SerializeField]
    private float BulletInterbal;
    private float CopyBulletInterbal;
    private GameObject Master;
    [SerializeField]
    private float WorldTime;
    private bool IsWorldTime = true;
    public GameObject MainCamera;
    private float momentmove = 0;
    // Use this for initialization
    void Start()
    {
        Master = GameObject.Find("Master");
        CopyBulletInterbal = BulletInterbal;
    }

    // Update is called once per frame
    void Update()
    {
        MoveResult();
    }
    void MoveResult()
    {
        MoveKeyState();
        SkillKey();
        Move();
    }
    void MoveKeyState()
    {
        if (Input.GetKey(KeyCode.W) && MoveKey != 2)
        {
            MoveKey = 1;
            MovePos.y += MoveForce;
        }
        if (Input.GetKey(KeyCode.A) && MoveKey != 2)
        {
            MoveKey = 1;
            MovePos.x += -MoveForce;

        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveKey = 1;
            MovePos.y += -MoveForce;
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveKey = 1;
            MovePos.x += MoveForce;
        }



        if (Input.GetKey(KeyCode.Space) && BulletInterbal <= 0)
        {
            Instantiate(Bullet, transform.position, Quaternion.identity);
            BulletInterbal = CopyBulletInterbal;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow) && GetComponent<SpriteRenderer>().enabled == true)//下に瞬間移動
        {
            GetComponent<SpriteRenderer>().enabled = false;
            MovePos = transform.position;
            MovePos.y -= 3;
            MoveKey = 2;
            transform.position = MovePos;
            MovePos = Vector3.zero;
            Move();
        }
    }
    void SkillKey()
    {
        if (Input.GetKey(KeyCode.Q))//時を止めるスキル
        {
            MoveKey = 1;
            Master.GetComponent<WorldTime>().SetTime(0.1f);
            MainCamera.GetComponent<Posteffect>().Setenabled(true);
            IsWorldTime = false;
        }
    }
    void Move()
    {
        MovePos.z = 0.0f;
        switch (MoveKey)
        {
            case 1:
                transform.Translate(MovePos);
                MoveKey = 0;
                MovePos = Vector3.zero;
                break;
            case 2:
                momentmove += Time.deltaTime;
                if (momentmove > 0.1f)
                {
                    momentmove = 0;
                    GetComponent<SpriteRenderer>().enabled = true;
                    MoveKey = 0;
                }
                break;
        }
        BulletInterbal -= Time.deltaTime;
        TimeSkill();
    }
    void TimeSkill()
    {
        if (!IsWorldTime)
        {
            WorldTime -= Time.deltaTime;
        }
        if (WorldTime <= 0)
        {
            Master.GetComponent<WorldTime>().SetTime(1);
            MainCamera.GetComponent<Posteffect>().Setenabled(false);
        }
    }
}
