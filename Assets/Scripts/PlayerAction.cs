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
        //Move Value
        h = gameManager.isAction ? 0 : Input.GetAxisRaw("Horizontal");
        v = gameManager.isAction ? 0 : Input.GetAxisRaw("Vertical");

        //Check Button Down & Up
        hDown = gameManager.isAction ? false : Input.GetButtonDown("Horizontal");
        vDown = gameManager.isAction ? false : Input.GetButtonDown("Vertical");
        hUp = gameManager.isAction ? false : Input.GetButtonUp("Horizontal");
        vUp = gameManager.isAction ? false : Input.GetButtonUp("Vertical");

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

    }
}
