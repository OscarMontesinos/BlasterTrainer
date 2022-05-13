using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody _rigidbody;
    public Camera cam;
    Vector3 movement;
    float horizontalInput = 0;
    float verticalInput = 0;
    public float speed;
    public float jumpSpeed;
    public float hookTractionSpeed;
    public float shootRecoil;
    public float shootTime;
    float shootTimer;
    public float maxSpeed;
    public float gravityMultiplier;

    public bool jumpable = true;

    public GameObject bullet;
    public GameObject gancho;
    public GameObject checkpoint;
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalInput, 0, verticalInput);
        if (Input.GetKey(KeyCode.Space) && jumpable)
        {
            jumpable = false;
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
        }
        if (Input.GetMouseButton(0) && shootTimer <=0)
        {
            _rigidbody.AddForce(transform.forward * -shootRecoil, ForceMode.Impulse);
            shootTimer = shootTime;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        var wantedPos = new Vector3(0, 0, 0);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            wantedPos = raycastHit.point;
        }

        transform.LookAt(wantedPos, Vector3.down);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);

        _rigidbody.AddForce(movement.normalized * Time.deltaTime * speed, ForceMode.Force);
        _rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxSpeed);

        
    }

    public void Die()
    {
        _rigidbody.velocity = new Vector3(0, 0, 0);
        transform.position = checkpoint.transform.position;
        checkpoint.GetComponent<CheckPoint>().StartCoroutine(checkpoint.GetComponent<CheckPoint>().Respawn());
        gameObject.SetActive(false);
    }

}
