using UnityEngine;

public class cube_move : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] public float m_Speed = 3f;
    private Vector3 moveTowards;

    // Add variables for upper and lower limits
    [SerializeField] public float upperLimit = 1.5f; // Set your upper limit here
    [SerializeField] public float lowerLimit = -5f; // Set your lower limit here

    void Start()
    {
        // Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        moveTowards = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        // Calculate the new position
        Vector3 newPosition = transform.position + moveTowards * Time.fixedDeltaTime * m_Speed;

        // Check if the new position exceeds the upper or lower limit
        if (newPosition.y > upperLimit)
        {
            newPosition.y = upperLimit; // Clamp to upper limit
            moveTowards = Vector3.zero; // Stop movement
        }
        else if (newPosition.y < lowerLimit)
        {
            newPosition.y = lowerLimit; // Clamp to lower limit
            moveTowards = Vector3.zero; // Stop movement
        }

        // Apply the movement vector to the current position
        m_Rigidbody.MovePosition(newPosition);
    }

    public void Move(int y_position)
    {
        // Check if the cube is already at the upper or lower limit
        if ((y_position > 0 && transform.position.y >= upperLimit) ||
            (y_position < 0 && transform.position.y <= lowerLimit))
        {
            moveTowards = Vector3.zero; // Stop movement if at a limit
        }
        else
        {
            // Move_event
            moveTowards = new Vector3(0, y_position, 0);
        }
    }
}