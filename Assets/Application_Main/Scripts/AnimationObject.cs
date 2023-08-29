using UnityEngine;
using UnityEngine.Events;

public class AnimationObject : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [SerializeField] protected UnityEvent onAnimationStart, onAnimationEnd;

    #endregion

    #endregion

    #region Methods

    #region Public Methods

    public void OnAnimationStart()
    {
        onAnimationStart?.Invoke();
    }
    public void OnAnimationEnd()
    {
        onAnimationEnd?.Invoke();
    }

    #endregion

    #endregion
}
