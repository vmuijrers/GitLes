using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour {

    public Camera cam;
    public float moveSpeed = 5f;
    public float lookSensX = 15f;
    public float lookSensY = 15f;
    public float maxAngle = 85f;

    private Rigidbody rigidBody;
    private float angleX = 0;
    private float angleY = 0;
    private Transform body;
    private Vector3 position;

    // Use this for initialization
    void Start () {
        body = transform;
        rigidBody = GetComponent<Rigidbody>();
    }
	
	// Update is called once per frame
	void Update () {

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        float hor = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");

        position = body.transform.position + (vert * body.transform.forward + hor * body.transform.right).normalized * moveSpeed * Time.deltaTime;
        angleX += mouseX * lookSensX;
        angleY += mouseY * lookSensY;
        angleY = Mathf.Clamp(angleY, -maxAngle, maxAngle);

        body.transform.rotation = Quaternion.Euler(0, angleX, 0);
        cam.transform.localRotation = Quaternion.Euler(-angleY, 0, 0);
    }

    void FixedUpdate() {
        rigidBody.MovePosition(position);
    }
}
