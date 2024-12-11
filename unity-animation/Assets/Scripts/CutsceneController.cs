using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutsceneController : MonoBehaviour
{
    public Animator CutsceneAnimator;
    public Camera mainCamera;
    public CameraController cameraController;
    public Camera cutsceneCamera;
    public Canvas timerCanvas;
    public PlayerController playerController;
    // Start is called before the first frame update
    void Start()
    {
        playerController.enabled = false;
        mainCamera.enabled = false;
        cameraController.enabled = false;
        timerCanvas.gameObject.SetActive(false);
        int CutsceneIndex = SceneManager.GetActiveScene().buildIndex;
        StartCoroutine(PlayCutscene(CutsceneIndex));
    }

    private IEnumerator PlayCutscene(int cutsceneIndex)
    {
        CutsceneAnimator.SetInteger("CutsceneIndex", cutsceneIndex);
        yield return new WaitUntil(() => CutsceneAnimator.GetCurrentAnimatorStateInfo(0).IsName($"Intro0{cutsceneIndex}"));
        yield return new WaitForSeconds(CutsceneAnimator.GetCurrentAnimatorStateInfo(0).length);
        playerController.enabled = true;
        cutsceneCamera.enabled = false;
        mainCamera.enabled = true;
        cameraController.enabled = true;
        timerCanvas.gameObject.SetActive(true);
        this.enabled = false;
    }
}
