using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAction : MonoBehaviour
{
    public float Speed;
    float h;
    float v;
    bool hDown;
    bool vDown;
    bool hUp;
    bool vUp;
    bool isHorizonMove;
    public GameManager gameManager;
    Vector2 dirVec;

    Rigidbody2D rigid;
    Animator anime;
    GameObject scanObject;

    //Screen Button Control
    int up_Value;
    int down_Value;
    int left_Value;
    int right_Value;

    bool up_Down;
    bool down_Down;
    bool left_Down;
    bool right_Down;
    bool up_Up;
    bool down_Up;
    bool left_Up;
    bool right_Up;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        anime = GetComponent<Animator>();
        scanObject = GetComponent<GameObject>();
    }

    private void FixedUpdate()
    {
        //Move
        Vector2 moveVec = isHorizonMove ? new Vector2(h, 0) : new Vector2(0, v);
        rigid.velocity = moveVec * Speed;

        //Ray
        Debug.DrawRay(rigid.position, dirVec * 0.7f, new Color(0, 1, 0));
        RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, dirVec, 0.7f, LayerMask.GetMask("Object"));

        if (rayHit.collider != null)
            scanObject = rayHit.collider.gameObject;
        else
            scanObject = null;

    }

    // Update is called once per frame
    void Update()
    {
        //Move Value PC & Mobile
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal") + right_Value + left_Value;
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical") + up_Value + down_Value;

        //Check Button Down & Up
        //PC
        hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

        //Check Button Down & Up
        //PC & Mobile
        hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal") || left_Down || right_Down;
        vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical") || up_Down || down_Down;
        hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal") || left_Up || right_Up;
        vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical") || up_Up || down_Up;


        //Check Horizontal Move
        if (hDown)
            isHorizonMove = true;
        else if (vDown)
            isHorizonMove = false;
        else if (hUp || vUp)
            isHorizonMove = h != 0;

        //Direction
        if (vDown && v == 1)
            dirVec = Vector2.up;
        else if (vDown && v == -1)
            dirVec = Vector2.down;
        else if (hDown && h == 1)
            dirVec = Vector2.right;
        else if (hDown && h == -1)
            dirVec = Vector2.left;

        //Animation
        if (anime.GetInteger("hAxisRaw") != h)
        {
            anime.SetBool("IsChange", true);
            anime.SetInteger("hAxisRaw", (int)h);
        }

        else if (anime.GetInteger("vAxisRaw") != v)
        {
            anime.SetBool("IsChange", true);
            anime.SetInteger("vAxisRaw", (int)v);
        }
        else
            anime.SetBool("IsChange", false);

        //Scan Object
        if (Input.GetButtonDown("Jump") && scanObject != null)
            gameManager.Action(scanObject);

        //Mobile Variable Init
        up_Down = false;
        down_Down = false;
        left_Down = false;
        right_Down = false;
        up_Up = false;
        down_Up = false;
        left_Up = false;
        right_Up = false;
    }

    public void ButtonDown(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 1;
                up_Down = true;
                break;
            case "D":
                down_Value = -1;
                down_Down = true;
                break;
            case "L":
                left_Value = -1;
                left_Down = true;
                break;
            case "R":
                right_Value = 1;
                right_Down = true;
                break;
             case "A":
                if (scanObject != null)
                    gameManager.Action(scanObject);
                break;
            case "C":
                gameManager.SubMenuActive();
                break;
        }
    }

    public void ButtonUp(string type)
    {
        switch (type)
        {
            case "U":
                up_Value = 0;
                up_Up = true;
                break;
            case "D":
                down_Value = 0;
                down_Up = true;
                break;
            case "L":
                left_Value = 0;
                left_Up = true;
                break;
            case "R":
                right_Value = 0;
                right_Up = true;
                break;
        }
    }
}
