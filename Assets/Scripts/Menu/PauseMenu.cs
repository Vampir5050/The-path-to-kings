using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] bool _pauseGame;
    [SerializeField] GameObject pauseGameMenu, buttonIneraction;
    TextMeshProUGUI textInteraction;

    private void Start()
    {
        textInteraction = buttonIneraction.GetComponent<TextMeshProUGUI>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_pauseGame == true)
            {
                Resume();
                Cursor.visible = false;
            }
            else
            {
                Pause();
            }
            
        }
    }

    public void Pause()
    {
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
        pauseGameMenu.SetActive(false);
        Time.timeScale = 1f;
        _pauseGame = false;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
