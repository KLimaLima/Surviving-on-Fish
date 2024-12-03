using UnityEngine;

public class cube_move : MonoBehaviour
{
    //public static event Move_event;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if ()
    }

    public void Move(int movement)
    {
        //Move_event
        transform.Translate(0, movement * Time.deltaTime, 0);
    }
}
