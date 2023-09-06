using UnityEngine;

public class BaseSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [Header("Animation Settings")] 
    [SerializeField] protected Animator animator;

    #endregion

    #endregion

    #region Methods

    #region Protected Methods

    protected void Start()
    {
        Setup();
    }
    protected void Setup()
    {
        SetupAnimation();
    }
    
    protected void SetupAnimation()
    {
        animator.Play("Idle-Non-Talking");
    }

    #endregion

    #endregion
}