using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject particle;
    [SerializeField] private float speed;
    bool started;
    bool gameOver;
    Rigidbody rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        started = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!started)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rb.velocity = new Vector3(speed, 0, 0);
                started = true;
            }
        }
        Debug.DrawRay(transform.position, Vector3.down, Color.green);

        if (!Physics.Raycast(transform.position,Vector3.down, 1f))
        {
            gameOver = true;
            rb.velocity = new Vector3(0, -10f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;


            if (rb.transform.position.y < -22f)
            {
                Destroy(this.gameObject);
            }
            
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if (rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }
        else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Flower")
        {
            GameObject tempPart = Instantiate(particle, other.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(other.gameObject);
            Destroy(tempPart, 1f);

        }
    }
}
