using UnityEngine;

public class FishMove : MonoBehaviour
{
    
    [SerializeField] private Vector2 endPoint;
    public float speed = 1.0f;                                                                                                                                                                      
    private Vector2 target;
    private Vector2 startPoint;
    private bool targetReached =false;
    void Start()
    {
        // Start by moving towards the end point
        target = endPoint;
        startPoint = transform.position;
    }

    void Update()
    {
        // Move towards the target
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);


        
        
        if (Vector3.Distance(transform.position,target) < 0.001f)
        {
            targetReached = true;

            transform.Rotate(0f, 180f, 0f);
            //target *= -1.0f;

            if (targetReached && transform.rotation.y == 180f)
            {
                target = startPoint;
                targetReached = false;
                

            }

            if (targetReached && transform.rotation.y == 0f)
            {
                
                target = endPoint;
                targetReached = false;


            }






        }
    }










}
