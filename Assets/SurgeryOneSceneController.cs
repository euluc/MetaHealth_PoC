using System.Collections;
using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurgeryOneSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [Header("MixedRealityToolkit Settings")]
    [SerializeField] protected MixedRealityToolkit mixedRealityToolkit;
    
    [Header("Fade Settings")]
    [SerializeField] protected CanvasGroup fadeCanvasGroup;
    
    [Header("Animation Settings")] 
    [SerializeField] protected Animator animator;
    [SerializeField] protected string animationName;
    [SerializeField] protected GameObject startButtonGO;
    [SerializeField] protected GameObject backButtonGO;
    [SerializeField] protected GameObject playButtonGO;
    [SerializeField] protected GameObject pauseButtonGO;
    [SerializeField] protected GameObject stopButtonGO;
    
    protected bool isFading;
    protected const int frameRate = 15;
    
    #endregion

    #region Public Variables

    public static int startFrame, endFrame;

    #endregion

    #endregion

    #region Methods

    #region Protected Methods

    protected void Start()
    {
        Setup();
        
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 0, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            mixedRealityToolkit.enabled = true;
        });
    }
    protected void Setup()
    {
        SetupMixedRealityToolkit();
        SetupFade();
        SetupAnimation();
        SetupButtons();
    }
    
    protected void SetupMixedRealityToolkit()
    {
        mixedRealityToolkit.enabled = false;
        CoreServices.DiagnosticsSystem.ShowProfiler = false;
    }
    protected void SetupFade()
    {
        fadeCanvasGroup.gameObject.SetActive(true);
        fadeCanvasGroup.alpha = 1;
    }
    protected void SetupAnimation()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, startFrame / (animator.GetCurrentAnimatorStateInfo(0).length * frameRate));
        animator.speed = 0;
    }
    protected void SetupButtons()
    {
        startButtonGO.SetActive(true);
        backButtonGO.SetActive(true);
        playButtonGO.SetActive(false);
        pauseButtonGO.SetActive(false);
        stopButtonGO.SetActive(false);
    }

    protected IEnumerator CheckForAnimationEnd()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
        } while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < endFrame / (animator.GetCurrentAnimatorStateInfo(0).length * frameRate));
        OnStopButtonPressed();
    }

    #endregion

    #region Public Methods

    public void OnStartButtonPressed()
    {
        animator.speed = 1;
        startButtonGO.SetActive(false);
        backButtonGO.SetActive(false);
        playButtonGO.SetActive(false);
        pauseButtonGO.SetActive(true);
        stopButtonGO.SetActive(true);

        StartCoroutine(CheckForAnimationEnd());
    }
    public void OnBackButtonPressed()
    {
        // Todo: fade to previous selection scene
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.MenuScene, LoadSceneMode.Single);
        });
    }
    public void OnPlayButtonPressed()
    {
        animator.speed = 1;
        pauseButtonGO.SetActive(true);
        playButtonGO.SetActive(false);
    }
    public void OnPauseButtonPressed()
    {
        animator.speed = 0;
        playButtonGO.SetActive(true);
        pauseButtonGO.SetActive(false);
    }
    public void OnStopButtonPressed()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, startFrame / (animator.GetCurrentAnimatorStateInfo(0).length * 15));
        animator.speed = 0;
        
        startButtonGO.SetActive(true);
        backButtonGO.SetActive(true);
        playButtonGO.SetActive(false);
        pauseButtonGO.SetActive(false);
        stopButtonGO.SetActive(false);
    }

    #endregion

    #endregion
}