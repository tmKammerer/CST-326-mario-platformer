using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControoler : MonoBehaviour
{
    public float run = 50f;
    public float maxSpeed = 6f;
    public float jump = 20f;
    public float otherJump = 7.5f;
    public float proximityThreshold = 10f;

    public bool feetOnGround;
    private Rigidbody body;

    private Collider collider;

    private Animator animComp;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody>();
        animComp = GetComponent<Animator>();
        collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        
        float castDist = collider.bounds.extents.y+0.1f;
        feetOnGround= Physics.Raycast(transform.position, Vector3.down, castDist);

        float axis = Input.GetAxis("Horizontal");
        body.AddForce(Vector3.right*run*axis, ForceMode.Force);

        if (feetOnGround&& Input.GetKeyDown(KeyCode.Space))
        {
            body.AddForce(Vector3.up * jump, ForceMode.Impulse);
            animComp.SetBool("InAir", true);

        }
        else if (body.velocity.y>0f&&Input.GetKey(KeyCode.Space))
        {
            body.AddForce(Vector3.up * otherJump, ForceMode.Force);
            animComp.SetBool("InAir", true);
        }
        else
        {
            animComp.SetBool("InAir", false);
        }
        if(Mathf.Abs(body.velocity.x) > maxSpeed)
        {
            float newX = maxSpeed * Mathf.Sign(body.velocity.x);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
            animComp.SetFloat("Speed", body.velocity.magnitude);
        }

        if (Mathf.Abs(axis) < 0.1f)
        {
            float newX = body.velocity.x*(1f-Time.deltaTime*3f);
            body.velocity = new Vector3(newX, body.velocity.y, body.velocity.z);
            animComp.SetFloat("Speed", body.velocity.magnitude);
        }

        
    }
}
