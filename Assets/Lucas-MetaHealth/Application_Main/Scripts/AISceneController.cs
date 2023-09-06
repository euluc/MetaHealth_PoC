using System.Collections;
using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AISceneController : MonoBehaviour
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
    [SerializeField] protected AudioSource answerAudio;
    [SerializeField] protected GameObject answer1ButtonGO;
    [SerializeField] protected GameObject answer2ButtonGO;
    [SerializeField] protected GameObject answer3ButtonGO;
    [SerializeField] protected GameObject answer4ButtonGO;
    [SerializeField] protected GameObject backButtonGO;
    
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
    protected void SetupButtons()
    {
        answer1ButtonGO.SetActive(true);
        answer2ButtonGO.SetActive(true);
        answer3ButtonGO.SetActive(true);
        answer4ButtonGO.SetActive(true);
        backButtonGO.SetActive(true);
    }

    protected IEnumerator CheckForAudioEnd()
    {
        do
        {
            yield return new WaitForSeconds(0.01f);
        } while (answerAudio.isPlaying);
        
        animator.Play("Idle-Non-Talking");
    }

    #endregion

    #region Public Methods

    public void OnAnswerButtonPressed(AudioClip clip)
    {
        answerAudio.Stop();
        answerAudio.clip = clip;
        answerAudio.Play();
        animator.Play("Idle-Talking");
        StartCoroutine(CheckForAudioEnd());
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
    public void OnPinButtonPressed()
    {
        radialView.enabled = !radialView.enabled;
    }

    #endregion

    #endregion
}