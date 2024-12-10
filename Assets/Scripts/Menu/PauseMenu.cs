using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseGameMenu, uiCanvas, menuCanvas, buttonIneraction;
    [SerializeField] bool _pauseGame;
    TextMeshProUGUI textInteraction;

    private void Start()
    {
        textInteraction = buttonIneraction.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)&&!_pauseGame)
        {
            Pause();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && _pauseGame)
        {
            Resume();
        }
    }

    public void Pause()
    {
        SoundManager.Instance.startingZoneBGMusic.Pause();
        uiCanvas.SetActive(false);
        menuCanvas.SetActive(true);
        textInteraction.enabled = false;
        InstantiateDialog.ShowDialog = false;
        Cursor.visible = true;
        pauseGameMenu.SetActive(true);
        Time.timeScale = 0f;
        _pauseGame = true;
    }

    public void Resume()
    {
        Cursor.visible = false;
        SoundManager.Instance.startingZoneBGMusic.Play();
        menuCanvas.SetActive(false);
        uiCanvas.SetActive(true);
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        _pauseGame = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
}
