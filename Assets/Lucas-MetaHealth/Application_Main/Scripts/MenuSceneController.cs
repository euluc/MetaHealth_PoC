using Microsoft.MixedReality.Toolkit;
using Microsoft.MixedReality.Toolkit.Utilities.Solvers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class MenuSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [Header("MixedRealityToolkit Settings")]
    [SerializeField] protected MixedRealityToolkit mixedRealityToolkit;
    [SerializeField] protected RadialView radialView;
    
    [Header("Fade Settings")]
    [SerializeField] protected CanvasGroup fadeCanvasGroup;

    [FormerlySerializedAs("playButtonGO")]
    [Header("Scenes Settings")]
    [SerializeField] protected GameObject surgeryOneButtonGO;
    [SerializeField] protected GameObject micButtonGO;

    protected bool isFading;
    
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
        surgeryOneButtonGO.SetActive(true);
        micButtonGO.SetActive(true);
    }

    #endregion

    #region Public Methods

    public void OnOpenSurgeryOneSceneButtonPressed()
    {
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.SurgeryOneScene);
        });
    }
    public void OnOpenAiSceneButtonPressed()
    {
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.AIScene);
        });
    }
    public void OnPinButtonPressed()
    {
        radialView.enabled = !radialView.enabled;
    }

    #endregion
    
    #endregion
}