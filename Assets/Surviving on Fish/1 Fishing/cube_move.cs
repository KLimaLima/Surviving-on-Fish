using UnityEngine;

public class cube_move : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    [SerializeField] public float m_Speed = 5f;
    private Vector3 moveTowards;

    void Start()
    {
        //Fetch the Rigidbody from the GameObject with this script attached
        m_Rigidbody = GetComponent<Rigidbody>();
        moveTowards = new Vector3(0, 0, 0);
    }

    void FixedUpdate()
    {
        //Store user input as a movement vector
        //Vector3 m_Input = target;

        //Apply the movement vector to the current position, which is
        //multiplied by deltaTime and speed for a smooth MovePosition
        m_Rigidbody.MovePosition(transform.position + moveTowards * Time.fixedDeltaTime * m_Speed);
    }    
    public void Move(int y_position)
    {
        //Move_event
        moveTowards = new Vector3(0, y_position, 0);

    }
}