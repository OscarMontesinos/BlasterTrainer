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
     float speedB;
    public float speedTurn;
    public float speedTurnMultiplier;
    public float speedTurnMax;
    public float jumpSpeed;
    public float hookTractionSpeed;
    public float shootRecoil;
    public float shootTime;
    float shootTimer;
    public float maxSpeed;
    public float gravityMultiplier;
    public LayerMask maskProjectile;
    public bool jumpable = true;
    float mass;
    public bool shootingAble = true;
    bool paused;
    public GameObject menu;

    public GameObject explosionAudio;

    public Transform canon1;
    public Transform canon2;
    int shoots;

    public GameObject bullet;
    public GameObject gancho;
    public GameObject checkpoint;
    public GameObject explosion;
    public GameObject camGo;

    public LayerMask apuntable;

    public Animator animatorR;
    public Animator animatorL;
    public Animator animatorWheel;
    void Start()
    {
        animatorWheel = GetComponent<Animator>();
        mass = _rigidbody.mass;
        Cursor.lockState = CursorLockMode.Locked;
        speedB = speedTurn;
        _rigidbody = GetComponent<Rigidbody>();
        speed *= mass;
        jumpSpeed *= mass;
        hookTractionSpeed *= mass;
        shootRecoil *= mass;
        speedTurn *= mass;
        speedTurnMultiplier *= mass;
        speedTurnMax *= mass;
}
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Die();
        }
        if (jumpable)
        {
            transform.rotation = camGo.transform.rotation;
            transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        }
        if (shootTimer > 0)
        {
            shootTimer -= Time.deltaTime;
        }
        /*horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
        movement = new Vector3(horizontalInput, 0, verticalInput);*/
        if (Input.GetKey(KeyCode.Space) && jumpable)
        {
            jumpable = false;
            animatorWheel.SetTrigger("Salto");
            _rigidbody.AddForce(Vector3.up * jumpSpeed, ForceMode.Impulse);
            GetComponent<AudioSource>().Play();
        }
        if (Input.GetMouseButton(0) && shootTimer <= 0 && !gancho.GetComponent<Gancho>().enganchado)
        {
            Shoot();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!paused)
            {
                Cursor.lockState = CursorLockMode.None;
                Time.timeScale = 0;
                menu.SetActive(true);
                paused = !paused;
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Time.timeScale = 1;
                menu.SetActive(false);
                paused = !paused;
            }
        }
        if (Input.GetKey(KeyCode.W) && !FindObjectOfType<Gancho>().enganchado)
        {
            animatorWheel.SetBool("Running", true);
            if (jumpable)
            {
                _rigidbody.AddForce(transform.forward * speed, ForceMode.Force);
            }
            else
            {
                _rigidbody.AddForce(transform.forward * speed / 3, ForceMode.Force);
            }
        }
        if (Input.GetKeyUp(KeyCode.W))
        {

            animatorWheel.SetBool("Running", false);
        }
        if (Input.GetKey(KeyCode.S) && !FindObjectOfType<Gancho>().enganchado)
        {
            animatorWheel.SetBool("Gninnur", true);
            if (jumpable)
            {
                _rigidbody.AddForce(transform.forward * -speed / 2, ForceMode.Force);
            }
            else
            {
                _rigidbody.AddForce(transform.forward * -speed / 5, ForceMode.Force);
            }
        }
        if (Input.GetKeyUp(KeyCode.S))
        {

            animatorWheel.SetBool("Gninnur", false);
        }



        if (Input.GetKeyDown(KeyCode.K))
        {
            Die();
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        
        /*var wantedPos = new Vector3(0, 0, 0);
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            wantedPos = raycastHit.point;
        }

        transform.LookAt(wantedPos, Vector3.down);

        _rigidbody.AddForce(movement.normalized * Time.deltaTime * speed, ForceMode.Force);*/
        //_rigidbody.velocity = Vector3.ClampMagnitude(_rigidbody.velocity, maxSpeed);
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);


    }

    public void Die()
    {
        Instantiate(explosionAudio, transform.position, transform.rotation);
        transform.parent = null;
        FindObjectOfType<Timer>().seconds += 10;
        Instantiate(explosion, transform.position, transform.rotation);
        _rigidbody.velocity = new Vector3(0, 0, 0);
       
        checkpoint.GetComponent<CheckPoint>().StartCoroutine(checkpoint.GetComponent<CheckPoint>().Respawn());
        gameObject.SetActive(false);
        var trackers = FindObjectsOfType<Tracker>();
        foreach(Tracker tracker in trackers)
        {
            tracker.GetComponent<LineRenderer>().enabled = false;
        }
    }
    void Shoot()
    {
        if (shootingAble)
        {

            _rigidbody.AddForce(cam.transform.forward * -shootRecoil, ForceMode.Impulse);
            shootTimer = shootTime;
            Vector3 rayOrigin = new Vector3(0.5f, 0.5f, 0f);
            Ray ray = Camera.main.ViewportPointToRay(rayOrigin);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 1000, apuntable))
            {
                shoots++;
                if (shoots % 2 != 0)
                {
                    GameObject bala = (GameObject)Instantiate(bullet, canon1.position, transform.rotation);
                    bala.transform.LookAt(hit.point);
                    animatorL.SetTrigger("Disparar");
                }
                else
                {
                    GameObject bala = (GameObject)Instantiate(bullet, canon2.position, transform.rotation);
                    bala.transform.LookAt(hit.point);

                    animatorR.SetTrigger("Disparar");
                }
            }
        }
    }
    public void GanchoSalto()
    {
        transform.rotation = camGo.transform.rotation;
        transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        _rigidbody.AddForce(transform.forward * jumpSpeed, ForceMode.Impulse);
        _rigidbody.AddForce(transform.up * jumpSpeed, ForceMode.Impulse);
    }

    public void timescale()
    {
        Time.timeScale = 1;
    }
}
