using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    private GameManager gameManager;

    private float yRot;
    private float yRotBounds = 70.0f;
    [SerializeField] float aimSpeed;
    [SerializeField] float launchSpeed;
    [SerializeField] float spinSpeed;

    private Vector3 murderLightOffset = new Vector3(0, 8, 0);

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            // Aim and launch player knife
            if (gameManager.isAiming)
            {
                // Rotate knife
                yRot += Input.GetAxis("Horizontal") * Time.deltaTime * aimSpeed;
                yRot = Mathf.Clamp(yRot, -yRotBounds, yRotBounds);
                transform.rotation = Quaternion.Euler(transform.rotation.x, yRot, transform.rotation.z);

                // Launch knife
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    gameManager.isAiming = false;
                    playerRb.AddForce(transform.forward * launchSpeed, ForceMode.Impulse);

                    // Change spin direction based on angle of launch
                    if (yRot >= 0)
                    {
                        playerRb.AddTorque(Vector3.up * spinSpeed);
                    }
                    else if (yRot < 0)
                    {
                        playerRb.AddTorque(Vector3.up * -spinSpeed);
                    }
                }
            }
        }
    }

    private void LateUpdate()
    {
        // Have spotlight follow the knife after viewing time is up
        if (!gameManager.isViewing)
        {
            gameManager.murderLight.transform.position = transform.position + murderLightOffset;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // If knife hits target
        if (other.gameObject.CompareTag("Target"))
        {
            Destroy(other.gameObject);
        }
        // If knife goes out of bounds, reset
        else if (other.gameObject.CompareTag("ResetKnife"))
        {
            gameManager.attemptNum++;
            gameManager.uiManager.UpdateAttemptsText(gameManager.attemptNum);
            gameManager.isAiming = true;
            ResetKnife();
        }
    }

    // Reset the position of the knife for relaunch
    public void ResetKnife()
    {
        transform.position = new Vector3(0, 0.5f, -5);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        playerRb.velocity = Vector3.zero;
        playerRb.angularVelocity = Vector3.zero;
    }
}
