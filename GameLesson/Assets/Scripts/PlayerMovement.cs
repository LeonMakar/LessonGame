using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Rigidbody PashaRigidBody;
    public float Speed;



    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            Vector3 movementVector = transform.TransformDirection(Vector3.forward) * Speed * Time.deltaTime;
            PashaRigidBody.velocity = new Vector3(movementVector.x, PashaRigidBody.velocity.y, movementVector.z);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -100 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            PashaRigidBody.AddForce(Vector3.up * 1000);
        }
    }
}
