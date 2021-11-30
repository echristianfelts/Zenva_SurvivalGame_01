using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;
    public Rigidbody rig;

    private bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // NOTE: This movement controller is set for World Space.
        //  This will have to be changed to Player Space at some point.

        // Vertical and horizontal inputs.
        float x = Input.GetAxis("Horizontal") * moveSpeed;
        float z = Input.GetAxis("Vertical") * moveSpeed;

        // Set velocity based on inputs.
        rig.velocity = new Vector3(x, rig.velocity.y, z);

        // Rotate to match velocity/direction of movement
        // Create copy of velocity variable and set Y axis to be 0
        Vector3 vel = rig.velocity;
        vel.y = 0;

        // if we are moving, rotate to face our moving direction.
        if (vel.x != 0 || vel.z != 0) // Rotate to match velocity but ONLY if the Player is in motion.
        {
            transform.forward = vel;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            isGrounded = false;
            rig.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }

        if(transform.position.y < -10)
        {
            GameOver();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.contacts[0].normal == Vector3.up)
        {
            isGrounded = true;
        }
    }

    //This method restarts the scene...
    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
