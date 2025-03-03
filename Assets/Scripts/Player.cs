using System;
using UnityEngine;
using Unity.Cinemachine;

public class Player : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private float speed;
    [SerializeField] private float jumpHeight;
    [SerializeField] private CinemachineCamera thirdPersonCam;
    float camRotationSpeed = 10f;
    private Rigidbody rb;

    void Start()
    {
        inputManager.OnMove.AddListener(MovePlayer); //Adding MovePlayer listener to the OnMove event.
        inputManager.OnJump.AddListener(PlayerJump);
        rb = GetComponent<Rigidbody>();


    }

    private void MovePlayer(Vector3 direction)
    {
        Vector3 camForward = thirdPersonCam.transform.forward;
        camForward.y = 0f;
        camForward.Normalize();

        Vector3 camRight = thirdPersonCam.transform.right;
        camRight.y = 0f;
        camRight.Normalize();

        Vector3 moveDirection = (camForward * direction.z + camRight * direction.x);

        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * camRotationSpeed);

        rb.linearVelocity = new Vector3(moveDirection.x * speed, rb.linearVelocity.y, moveDirection.z * speed);
    }
    private void PlayerJump(Vector3 direction)
    {
        if (Physics.Raycast(transform.position, -Vector3.up, 1.1f))
        {
            Vector3 jumpDirection = direction;
            rb.AddForce(jumpHeight * jumpDirection);
        }
    }
}
