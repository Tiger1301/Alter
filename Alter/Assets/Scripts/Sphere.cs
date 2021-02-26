using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sphere : MonoBehaviour
{
    public GameObject Cube;
    public GameObject CubeCamera;
    public GameObject MyCamera;
    public float Speed = 10;
    public float MaxSpeed = 20;
    public float SpeedInc = 0.2f;
    public float SizeDec = 0.1f;
    public float MinSize = 0.2f;
    public float JumpForce = 5;
    public float MaxJump = 10;
    public float JumpInc = 0.4f;
    float IncreasedJump;
    float DecreasedSize;
    float IncreasedSpeed;
    Vector3 Scale;
    Rigidbody RB;
    // Start is called before the first frame update
    void Start()
    {
        RB = GetComponent<Rigidbody>();
        Scale = transform.localScale;

    }

    // Update is called once per frame
    void Update()
    {
        Controls();
    }

    public void Controls()
    {
        if (Input.GetKey(KeyCode.S))
        {
            RB.AddForce(Vector3.back * Speed * Time.deltaTime, ForceMode.Impulse);
            //RB.velocity = new Vector3(0, 0, -2 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.W))
        {
            RB.AddForce(Vector3.forward * Speed * Time.deltaTime, ForceMode.Impulse);
            //RB.velocity = new Vector3(0, 0, 2 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            RB.AddForce(Vector3.right * Speed * Time.deltaTime, ForceMode.Impulse);
            //RB.velocity = new Vector3(1, 0, 0 * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            RB.AddForce(Vector3.left * Speed * Time.deltaTime, ForceMode.Impulse);
            //RB.velocity = new Vector3(-1, 0, 0 * Speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Scale.x += DecreasedSize;
            Scale.y += DecreasedSize;
            Scale.z += DecreasedSize;
            DecreasedSize = 0;
            RB.transform.localScale = Scale;

            Speed -= IncreasedSpeed;
            IncreasedSpeed = 0;

            JumpForce -= IncreasedJump;
            IncreasedJump = 0;

            Cube.SetActive(true);
            CubeCamera.SetActive(true);
            Cube.transform.position = transform.position;
            MyCamera.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                RB.AddForce(Vector3.up * JumpForce,ForceMode.Impulse);
                if(Scale.x > MinSize && Scale.y > MinSize && Scale.z > MinSize)
                {
                    Scale.x -= SizeDec;
                    Scale.y -= SizeDec;
                    Scale.z -= SizeDec;
                    RB.transform.localScale = Scale;
                    DecreasedSize += SizeDec;
                }
                if(Speed<MaxSpeed)
                {
                    Speed += SpeedInc;
                    IncreasedSpeed += SpeedInc;
                }
                if(JumpForce<MaxJump)
                {
                    JumpForce += JumpInc;
                    IncreasedJump += JumpInc;
                }
            }
        }
    }
}
