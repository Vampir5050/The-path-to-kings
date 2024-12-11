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
        SaveManager.Instance.ActivateLoadingScreen();
        StartCoroutine(DelayedLoading());
        SceneManager.LoadScene("SampleScene");
      
        SaveManager.Instance.DisableLoadingScreen();
        SoundManager.Instance.startingZoneBGMusic.Play();



    }
    public void ExitGame()
    {
        Application.Quit();
    }
    private IEnumerator DelayedLoading()
    {
      
        yield return new WaitForSeconds(1f);
        

    }


}
