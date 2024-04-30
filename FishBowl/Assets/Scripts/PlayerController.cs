using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    
    [SerializeField]
    private float speed;

    private float scoreCount = 0;
    Rigidbody2D playerRb;
    public GameObject dropFeed;

    Vector2 lastClickedPosition;
    
    float step;
    bool isMoving;
    bool facingRight = true;
    float growthRate = 1f;
    public Text scorePoints;

    
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
      
        
    }

    // Update is called once per frame
    void Update()
    {
        clickMove();
        
   

        if (Input.GetKeyDown(KeyCode.F))
        {
            dropFeed.SetActive(true);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            dropFeed.SetActive(false);
        }
    }
        private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Feed"))
        {
            collision.gameObject.SetActive(false);
            scoreCount++;
            scorePoints.text = scoreCount.ToString();
            growthRate += 0.1f;
            Grow(growthRate);
           
        }
    }
    private void Grow(float growth)
    {
       
       transform.localScale = new Vector3(growth, growth, 0);
        
    }

    private void clickMove()
    {
        if (Input.GetMouseButtonDown(0)) //Left click
        {
            lastClickedPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition); //TargetPosition
            isMoving = true;


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
        }
    }

    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }

   
    

}
