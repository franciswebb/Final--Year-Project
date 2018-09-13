using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Animator anim;


    public float moveSpeed;

    public bool moveDown;
    public bool moveUp;
    public bool moveRight;
    public bool moveLeft;
    public bool paused = false;

    public Rigidbody2D rgbdy;
    public Canvas pauseMenu;

    // Use this for initialization
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        rgbdy = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (paused != true)
        {
            movementController();
        }
        moveSpeed = playerManager.moveSpeed;
        animationStateInitialise();

        if (Input.GetKeyDown(KeyCode.Escape)) // pauses game, sets timescale to 0 or 1
        {
            Pause();
        }

    }

    #region Movement
    void movementController() // movement of player dependent on the players input, sets animation bools
    {


        if (Input.GetAxisRaw("Horizontal") > 0.5)
        {
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
            moveRight = true;
        }
        if (Input.GetAxisRaw("Horizontal") < -0.5)
        {
            transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
            moveLeft = true;
        }

        if (Input.GetAxisRaw("Vertical") > 0.5)
        {
            transform.Translate(Vector2.up * moveSpeed * Time.deltaTime);
            moveUp = true;
        }

        if (Input.GetAxisRaw("Vertical") < -0.5f)
        {
            transform.Translate(Vector2.down * moveSpeed * Time.deltaTime);
            moveDown = true;
        }

        if (Input.GetAxisRaw("Vertical") == 0)
        {
            moveDown = false;
            moveUp = false;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {
            moveRight = false;
            moveLeft = false;
        }

    }
    #endregion

    public void Pause()
    {
        if (paused == false)
        {
            Time.timeScale = 0f;
            paused = true;
            pauseMenu.enabled = true;
           
        }
        else
        {
            Time.timeScale = 1f;
            paused = false;
            pauseMenu.enabled = false;
            
        }

    }


    void animationStateInitialise() // animation setter
    {

        anim.SetBool("moveDown", moveDown);
        anim.SetBool("moveRight", moveRight);
        anim.SetBool("moveLeft", moveLeft);
        anim.SetBool("moveUp", moveUp);


    }// END ANIMATION STATE

}
