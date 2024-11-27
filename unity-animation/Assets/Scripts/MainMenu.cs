using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    private Button Level01;
    private Button Level02;
    private Button Level03;

    private Button _b_Options;
    private Button _b_Exit;
    // Start is called before the first frame update
    void Start()
    {
        // Get All Button Components
        Level01 = GameObject.Find("Level01").GetComponent<Button>();
        Level02 = GameObject.Find("Level02").GetComponent<Button>();
        Level03 = GameObject.Find("Level03").GetComponent<Button>();
        _b_Options = GameObject.Find("OptionsButton").GetComponent<Button>();
        _b_Exit = GameObject.Find("ExitButton").GetComponent<Button>();

        // Add EventListeners to Buttons
        Level01.onClick.AddListener(delegate {LevelSelect(1); });
        Level02.onClick.AddListener(delegate {LevelSelect(2); });
        Level03.onClick.AddListener(delegate {LevelSelect(3); });
        _b_Options.onClick.AddListener(delegate {Options(); });
        _b_Exit.onClick.AddListener(delegate {Application.Quit(); });
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Loads the corresponding level
    public void LevelSelect(int level)
    {
        Debug.Log("Attempting Scene Load");
        SceneManager.LoadScene(level);
    }

    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
}
