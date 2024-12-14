using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Button LoadGameBTN;

    private void Start()
    {
       
    }

    public void PlayGame()
    {
        SoundManager.Instance.startingMenuAndPause.Stop();
        SceneManager.LoadScene("SampleScene");
        SoundManager.Instance.startingZoneBGMusic.Play();
        SoundManager.Instance.startingZoneBGMusic.loop = true;




    }
    public void ExitGame()
    {
        Application.Quit();
    }
   

}
