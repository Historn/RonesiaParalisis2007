using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuManager : MonoBehaviour
{
    public GameObject StartMainMenuPanel;
    public GameObject LoadMainMenuPanel;

    public Button NewGameButton;
    public Button LoadButton;
    public Button ExitButton;

    public Button LoadGame1Button;
    public Button LoadGame2Button;
    public Button LoadGame3Button;
    public Button BackLoadGameButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewGameButton.onClick.AddListener(NewGameButtonPress);
        LoadButton.onClick.AddListener(LoadButtonPress);
        ExitButton.onClick.AddListener(ExitButtonPress);
        BackLoadGameButton.onClick.AddListener(BackLoadGameButtonPress);

        LoadGame1Button.onClick.AddListener(LoadSlot1Press);
        LoadGame2Button.onClick.AddListener(LoadSlot2Press);
        LoadGame3Button.onClick.AddListener(LoadSlot3Press);

        ActivateMainMenuPanelStart(true);
        ActivateMainMenuPanelLoad(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ActivateMainMenuPanelStart(bool activate)
    {
        StartMainMenuPanel.SetActive(activate);
    }

    void ActivateMainMenuPanelLoad(bool activate)
    {
        LoadMainMenuPanel.SetActive(activate);

        if(activate)
        {
            
            if (SaveSystem.SaveFileExists(1))
            {
                LoadGame1Button.GetComponentInChildren<TextMeshProUGUI>().text = "Load Save 1";
            }
            else
            {
                LoadGame1Button.GetComponentInChildren<TextMeshProUGUI>().text = "No Save Data";
            }
            if (SaveSystem.SaveFileExists(2))
            {
                LoadGame2Button.GetComponentInChildren<TextMeshProUGUI>().text = "Load Save 2";
            }
            else
            {
                LoadGame2Button.GetComponentInChildren<TextMeshProUGUI>().text = "No Save Data";
            }
            if (SaveSystem.SaveFileExists(3))
            {
                LoadGame3Button.GetComponentInChildren<TextMeshProUGUI>().text = "Load Save 3";
            }
            else
            {
                LoadGame3Button.GetComponentInChildren<TextMeshProUGUI>().text = "No Save Data";
            }
        }
    }

    public void NewGameButtonPress()
    {
      SceneManager.LoadScene("IntroScene",LoadSceneMode.Single);
    }

    public void LoadButtonPress()
    {
        ActivateMainMenuPanelStart(false);
        ActivateMainMenuPanelLoad(true);
    }

    public void ExitButtonPress()
    {

    }

    public void BackLoadGameButtonPress()
    {
        ActivateMainMenuPanelLoad(false);
        ActivateMainMenuPanelStart(true);
    }

    public void LoadSlot1Press()
    {

    }

    public void LoadSlot2Press()
    {

    }

    public void LoadSlot3Press()
    {

    }
}
