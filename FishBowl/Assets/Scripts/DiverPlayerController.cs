using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiverPlayerController : MonoBehaviour
{
    private Animator animDiver;

    [SerializeField] private float speed;
    [SerializeField] private float boostSpeed = 5f;
    [SerializeField] private float boostDuration = 1.5f; // Duration of the boost
    [SerializeField] private float boostCooldown = 5f; // Cooldown between boosts

    Vector2 lastClickedPosition;

    bool isMoving;
    float step;
    bool facingRight = true;


    // Start is called before the first frame update
    void Start()
    {
        animDiver = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        clickMove();

    }

    
    private void clickMove()
    {
        if (Input.GetMouseButtonDown(0)) //Left click
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //TargetPosition
            isMoving = true;
            animDiver.SetBool("isMoving", true);


            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (facingRight && mousePos.x < transform.position.x)
            {
                Flip();


            }
            else if (!facingRight && mousePos.x > transform.position.x)
            {
                Flip();
            }
        }

        if (isMoving && (Vector2)transform.position != lastClickedPosition)
        {

            step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPosition, step);

        }
        else
        {
            isMoving = false;
            animDiver.SetBool("isMoving", false);
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

    
}
