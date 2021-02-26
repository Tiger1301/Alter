using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform Target;
    Vector3 CameraOffset;
    [Range(0, 1)]
    public float SmoothFactor;

    public float Distance = 10;
    public float Height = 4;
    public float followSpeed = 2;

    public bool LookAtPlayer = false;
    public bool RotateAroundPlayer = true;
    public float RotationSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        CameraOffset = transform.position + Target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(RotateAroundPlayer)
        {
            Quaternion camTurnAngle = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * RotationSpeed, Vector3.up);
            CameraOffset = camTurnAngle * CameraOffset;
        }


        Vector3 newPosition = Target.position + CameraOffset;
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        if(LookAtPlayer||RotateAroundPlayer)
        {
            transform.LookAt(Target);
        }

        //Vector3 direction = (newPosition - transform.position);
        //
        //if (direction.magnitude > 0.1f)
        //    return;

        //if (direction.x > 0)
        //{
        //    transform.position += Vector3.right * followSpeed * Time.deltaTime;
        //}
        //else if (direction.x < 0)
        //{
        //    transform.position -= Vector3.right * followSpeed * Time.deltaTime;
        //}
        //
        //if (direction.y > 0)
        //{
        //    transform.position += Vector3.up * followSpeed * Time.deltaTime;
        //}
        //else if (direction.y < 0)
        //{
        //    transform.position -= Vector3.up * followSpeed * Time.deltaTime;
        //}

        //transform.position = Target.transform.position + newPosition;
    }
}
