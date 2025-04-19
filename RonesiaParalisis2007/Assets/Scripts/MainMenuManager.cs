using UnityEngine;
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
        NewGameButton.GetComponent<Button>().onClick.AddListener(NewGameButtonPress);
        LoadButton.GetComponent<Button>().onClick.AddListener(LoadButtonPress);
        ExitButton.GetComponent<Button>().onClick.AddListener(ExitButtonPress);
        BackLoadGameButton.GetComponent<Button>().onClick.AddListener(BackLoadGameButtonPress);

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
    }

    public void NewGameButtonPress()
    {
      
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
}
