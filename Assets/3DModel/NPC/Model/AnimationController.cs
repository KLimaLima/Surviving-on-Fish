using UnityEngine;
using UniVRM10;
using UnityEngine.InputSystem;

public class AnimationController : MonoBehaviour
{
    public Animator animator;

    private Vector3 previousPosition;
    private float speed;
    public Vrm10Instance vrmInstance;

    public enum ExpressionType
    {
        None,
        Happy,
        Sad,
        Angry
    }

    [SerializeField] private ExpressionType currentExpression = ExpressionType.None;
    private ExpressionType previousExpression = ExpressionType.None; 

    void Start()
    {
        previousPosition = transform.position;
        vrmInstance = GetComponent<Vrm10Instance>();
    }

    void Update()
    {
        speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        animator.SetFloat("Speed", speed);
        previousPosition = transform.position;

        if (currentExpression != previousExpression)
        {
            SetExpression(currentExpression);
            previousExpression = currentExpression;
        }
    }

    public void SetExpression(ExpressionType expression)
    {
        ResetAllExpressions();

        if (vrmInstance != null)
        {
            switch (expression)
            {
                case ExpressionType.Happy:
                    vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.happy), 1.0f);
                    break;
                case ExpressionType.Sad:
                    vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.sad), 1.0f);
                    break;
                case ExpressionType.Angry:
                    vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.angry), 1.0f);
                    break;
            }
        }
    }

    private void ResetAllExpressions()
    {
        if (vrmInstance != null)
        {
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.happy), 0.0f);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.sad), 0.0f);
            vrmInstance.Runtime.Expression.SetWeight(ExpressionKey.CreateFromPreset(ExpressionPreset.angry), 0.0f);
        }
    }

    public void ChangeExpression(ExpressionType newExpression)
    {
        currentExpression = newExpression;
    }
}
