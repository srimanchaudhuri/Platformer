using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform groundCheckTransform = null;
    [SerializeField] private LayerMask playerMask;

    private bool jumpKeyPressed;
    private float horizontalInput;
    private new Rigidbody rigidbody;
    private int superJumpsRemaining;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) == true)
        {
            jumpKeyPressed = true;
        }


        horizontalInput = Input.GetAxis("Horizontal");

        if (Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    //Fixed Update is called once every physics update
    private void FixedUpdate()
    {
        if(rigidbody.position.y < -8.5) FindAnyObjectByType<GameManager>().EndGame();

        if (Physics.OverlapSphere(groundCheckTransform.position, 0.1f, playerMask).Length == 0)
        {
            return;
        }

        if(jumpKeyPressed == true) {
            float jumpPower = 5;
            if(superJumpsRemaining > 0)
            {
                jumpPower *= 1.3f;
                superJumpsRemaining--;
            }
            rigidbody.AddForce(Vector3.up * jumpPower, ForceMode.VelocityChange);
            jumpKeyPressed = false;
        }

        rigidbody.velocity = new Vector3(horizontalInput*3, rigidbody.velocity.y, rigidbody.velocity.z);

 


    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 6)
        {
            other.gameObject.SetActive(false);
            //other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            superJumpsRemaining++;
        }
    }
}
