// FlightController.cs
// CENG 454 – HW1: Sky-High Prototype
// Author: Talha Yiğit | Student ID: 220444031

using UnityEngine;

public class FlightController : MonoBehaviour
{
  [SerializeField] private float pitchSpeed = 45f; // degrees/second
  [SerializeField] private float yawSpeed = 45f;   // degrees/second
  [SerializeField] private float rollSpeed = 45f;  // degrees/second
  [SerializeField] private float thrustSpeed = 5f; // units/second

  // TODO (Task 3-A): Declare a private Rigidbody field named 'rb'
  private Rigidbody rb;

  void Start()
  {
    // TODO (Task 3-B): Cache GetComponent<Rigidbody>() into 'rb'.
    //                  Then set rb.freezeRotation = true.
    //                  Why is freezeRotation needed? Answer in your PDF.
    
    rb = GetComponent<Rigidbody>();
    rb.freezeRotation = true;
  }

  void Update()// or FixedUpdate()
  {
    HandleRotation();
    HandleThrust();
  }

  private void HandleRotation()
  {
    // TODO (Task 3-C):
    // Pitch
    // Roll

    // Pitch
    if (Input.GetKey(KeyCode.UpArrow))
    {
      transform.Rotate(Vector3.right * pitchSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.DownArrow))
    {
      transform.Rotate(Vector3.right * -pitchSpeed * Time.deltaTime);
    }

    // Yaw
    if (Input.GetKey(KeyCode.LeftArrow))
    {
      transform.Rotate(Vector3.up * -yawSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.RightArrow))
    {
      transform.Rotate(Vector3.up * yawSpeed * Time.deltaTime);
    }

    // Roll
    if (Input.GetKey(KeyCode.Q))
    {
      transform.Rotate(Vector3.forward * rollSpeed * Time.deltaTime);
    }

    if (Input.GetKey(KeyCode.E))
    {
      transform.Rotate(Vector3.forward * -rollSpeed * Time.deltaTime);
    }
  }

  private void HandleThrust()
  {
    // TODO (Task 3-D):
    
    if (Input.GetKey(KeyCode.Space))
    {
      rb.useGravity = false;
      transform.Translate(Vector3.forward * thrustSpeed * Time.deltaTime);
    }
    else
    {
      rb.useGravity = true;
    }
  }
}
