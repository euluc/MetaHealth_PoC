using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneController : MonoBehaviour
{
    #region Variables

    #region Protected Variables

    [Header("MixedRealityToolkit Settings")]
    [SerializeField] protected MixedRealityToolkit mixedRealityToolkit;
    
    [Header("Fade Settings")]
    [SerializeField] protected CanvasGroup fadeCanvasGroup;

    [Header("Scenes Settings")]
    [SerializeField] protected GameObject partOneButtonGO;
    [SerializeField] protected GameObject partTwoButtonGO;
    [SerializeField] protected GameObject partThreeButtonGO;
    
    
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
        CoreServices.DiagnosticsSystem.ShowProfiler = false;
    }
    protected void SetupFade()
    {
        fadeCanvasGroup.gameObject.SetActive(true);
        fadeCanvasGroup.alpha = 1;
    }
    protected void SetupButtons()
    {
        partOneButtonGO.SetActive(true);
        partTwoButtonGO.SetActive(true);
        partThreeButtonGO.SetActive(true);
    }

    #endregion

    #region Public Methods
    
    public void OnPartOneButtonPressed()
    {
        SurgeryOneSceneController.startFrame = 0;
        SurgeryOneSceneController.endFrame = 10;
        
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.SurgeryOneScene);
        });
    }
    public void OnPartTwoButtonPressed()
    {
        SurgeryOneSceneController.startFrame = 10;
        SurgeryOneSceneController.endFrame = 20;
        
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.SurgeryOneScene);
        });
    }
    public void OnPartThreeButtonPressed()
    {
        SurgeryOneSceneController.startFrame = 20;
        SurgeryOneSceneController.endFrame = 60;
        
        if (isFading) return;
        isFading = true;
        LeanTween.alphaCanvas(fadeCanvasGroup, 1, 1f).setDelay(0.15f).setOnComplete(() =>
        {
            isFading = false;
            SceneManager.LoadScene(Constants.Scenes.SurgeryOneScene);
        });
    }

    #endregion
    
    #endregion
}