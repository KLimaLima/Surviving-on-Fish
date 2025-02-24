using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    private Vector3 previousPosition;
    private float speed;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        speed = (transform.position - previousPosition).magnitude / Time.deltaTime;


        animator.SetFloat("Speed", speed);

        previousPosition = transform.position;
    }
}
