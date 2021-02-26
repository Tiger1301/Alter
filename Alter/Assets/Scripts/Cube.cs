using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject Sphere;
    public GameObject SphereCamera;
    public GameObject MyCamera;
    public float Speed;
    public float SizeInc = 0.2f;
    public float MaxSize = 3;
    float IncreasedSize;
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
        if(Input.GetKey(KeyCode.S))
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
            RB.AddForce(Vector3.left  * Speed * Time.deltaTime, ForceMode.Impulse);
            //RB.velocity = new Vector3(-1, 0, 0 * Speed * Time.deltaTime);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            Scale.x -= IncreasedSize;
            Scale.y -= IncreasedSize;
            Scale.z -= IncreasedSize;
            IncreasedSize = 0;
            RB.transform.localScale = Scale;

            Sphere.SetActive(true);
            SphereCamera.SetActive(true);
            Sphere.transform.position = transform.position;
            MyCamera.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(Scale.x < MaxSize && Scale.y < MaxSize && Scale.z < MaxSize)
            {
                Scale.x += SizeInc;
                Scale.y += SizeInc;
                Scale.z += SizeInc;
                RB.transform.localScale = Scale;
                IncreasedSize += SizeInc;
                Debug.Log("Size inc");
            }
        }
    }
}
