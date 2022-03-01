using UnityEngine;
using System.IO.Ports;
public class Base_move : MonoBehaviour

{
    // Adjust the speed for the application.
    public int component;
    public float x, y, z;
    public bool CheckIn = true;
    public Collider cube;
    public Move Move;
    public float size = 1f;
    public float minSize = 0.35f;
    public float maxSize = 1.65f;
    public float movementSpeed = 50f;
    public float maxLifetime = 30f;
    public new Rigidbody rigidbody { get; private set; }


    public void OnTriggerEnter(Collider cube)
    {
        if(Move.sp.ReadByte() == 1 )
        {
            if (cube.gameObject.tag == "Asteroid")
            {
                Destroy(this.gameObject);
                
            }
        }
    }

    void Awake()
    {
        x = -7.9f;
        y = 0.0f;
        z = 0.0f;
        // Position the cube at the origin.
        transform.position = new Vector3(x, y, z);
        rigidbody = GetComponent<Rigidbody>();

    }

    public void SetTrajectory(Vector3 direction)
    {
        // The asteroid only needs a force to be added once since they have no
        // drag to make them stop moving
        rigidbody.AddForce(direction * movementSpeed);
    }

    private void Start()
    {
        // Assign random properties to make each asteroid feel unique
     
        transform.eulerAngles = new Vector3(0f, 0f, Random.value * 360f);

        // Set the scale and mass of the asteroid based on the assigned size so
        // the physics is more realistic
        transform.localScale = Vector3.one * size;
        rigidbody.mass = size;

        // Destroy the asteroid after it reaches its max lifetime
        Destroy(gameObject, maxLifetime);
    }
    
     

    void Update()
    {
        
        component = (int)transform.position.x;
        
        
        if (component == 8)
        {
            CheckIn = false;
        }
        if (component ==  -8)
        {
            CheckIn = true;
        }
        if (CheckIn == true)
        {
            transform.position += Vector3.right * Time.deltaTime;
        }
        else 
        {
            transform.position += Vector3.left * Time.deltaTime;
        }
        
    }
}