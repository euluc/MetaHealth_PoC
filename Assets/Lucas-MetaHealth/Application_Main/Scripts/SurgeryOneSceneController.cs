using System.Collections;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SurgeryOneSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [Header("MixedRealityToolkit Settings")]
    [SerializeField] protected MixedRealityToolkit mixedRealityToolkit;
    [SerializeField] protected RadialView radialView;
    
    [Header("Fade Settings")]
    [SerializeField] protected CanvasGroup fadeCanvasGroup;
    
    [Header("Animation Settings")] 
    [SerializeField] protected Animator animator;
    [SerializeField] protected AudioSource animationAudio;
    [SerializeField] protected GameObject startButtonGO;
    [SerializeField] protected GameObject backButtonGO;
    [SerializeField] protected GameObject playButtonGO;
    [SerializeField] protected GameObject unpauseButtonGO;
    [SerializeField] protected GameObject pauseButtonGO;
    [SerializeField] protected GameObject stopButtonGO;
    
    protected bool isFading;
    protected float frameRate = 60;

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
    }
    protected void SetupFade()
    {
        fadeCanvasGroup.gameObject.SetActive(true);
        fadeCanvasGroup.alpha = 1;
    }
    protected void SetupAnimation()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0);
        animator.speed = 0;
        animationAudio.time = 0;
    }
    protected void SetupButtons()
    {
        startButtonGO.SetActive(true);
        backButtonGO.SetActive(true);
        playButtonGO.SetActive(false);
        unpauseButtonGO.SetActive(false);
        pauseButtonGO.SetActive(false);
        stopButtonGO.SetActive(false);
    }

    protected IEnumerator CheckForAnimationEnd()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
        } while (animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1);
        OnStopButtonPressed();
    }

    #endregion

    #region Public Methods

    public void OnStartButtonPressed()
    {
        animator.speed = 1;
        animationAudio.Play();
        startButtonGO.SetActive(false);
        backButtonGO.SetActive(false);
        playButtonGO.SetActive(false);
        unpauseButtonGO.SetActive(false);
        pauseButtonGO.SetActive(true);
        stopButtonGO.SetActive(true);
        StartCoroutine(CheckForAnimationEnd());
    }
    public void OnBackButtonPressed()
    {
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
        animationAudio.Pause();
        unpauseButtonGO.SetActive(true);
        pauseButtonGO.SetActive(false);
    }
    public void OnUnpauseButtonPressed()
    {
        animator.speed = 1;
        animationAudio.UnPause();
        pauseButtonGO.SetActive(true);
        unpauseButtonGO.SetActive(false);
    }
    public void OnStopButtonPressed()
    {
        animator.Play(animator.GetCurrentAnimatorStateInfo(0).fullPathHash, 0, 0);
        animationAudio.Stop();
        animator.speed = 0;
        animationAudio.time = 0;

        startButtonGO.SetActive(true);
        backButtonGO.SetActive(true);
        playButtonGO.SetActive(false);
        pauseButtonGO.SetActive(false);
        unpauseButtonGO.SetActive(false);
        stopButtonGO.SetActive(false);
    }
    public void OnPinButtonPressed()
    {
        radialView.enabled = !radialView.enabled;
    }
    
    #endregion

    #endregion
}