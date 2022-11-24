using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rb;
    //[SerializeField] Joystick joystick;
    [SerializeField] JoystickV2 joystick;
    Vector3 direction;
    [SerializeField]float rotationSpeed = 5f,speed=5f;
    float horizontal, vertical;
    //[SerializeField] GameObject partical;
    //Animator anim;
    // Start is called before the first frame update
    private void Awake()
    {
        //anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if(PlayerPrefs.HasKey("x"))
        {
            float x = PlayerPrefs.GetFloat("x");
            float y = PlayerPrefs.GetFloat("y");
            float z = PlayerPrefs.GetFloat("z");
            transform.position = new Vector3(x, y, z);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //GetEnum();
        ToInputAxis();
        //SavePositions();
    }
    private void FixedUpdate()
    {
        ToMove();
    }
    void ToInputAxis()
    {
         horizontal = joystick.result.x;
         vertical = joystick.result.y;
        direction = new Vector3(horizontal, 0, vertical).normalized;
    }
    void SavePositions()
    {
        PlayerPrefs.SetFloat("x", transform.position.x);
        PlayerPrefs.SetFloat("y", transform.position.y);
        PlayerPrefs.SetFloat("z", transform.position.z);
    }
    void ToMove()
    {
        if (vertical!=0)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            rb.velocity = new Vector3(horizontal * speed, 0f, vertical * speed);
            //anim.SetBool("isRun",true);
            //partical.SetActive(true);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0f, targetAngle, 0f), rotationSpeed * Time.deltaTime);

        }
        else
        {
            //anim.SetBool("isRun", false);
            //partical.SetActive(false);
            rb.velocity = Vector3.zero;
        }
    }
}
