using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Success : CanvasUI
{

     [Header("Sound Setting")]
    public Sprite OnVolume;
    public Sprite OffVolume;
    [SerializeField] private Image buttonImage;
     

    void Update()
    {
        UpdateButtonImage();
    }

    public void SoundBtn()
    {
        SoundManager.Instance.TurnOn = !SoundManager.Instance.TurnOn;
        UpdateButtonImage();
        SoundManager.Instance.PlayVFXSound(2);

    }

    private void UpdateButtonImage()
    {
        if (SoundManager.Instance.TurnOn)
        {
            buttonImage.sprite = OnVolume;
        }
        else
        {
            buttonImage.sprite = OffVolume;
        }
    }


    public void NextBtn()
    {
        Time.timeScale = 1;
        SoundManager.Instance.PlayClickSound();
        StartCoroutine(NextSence());
    }
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        // Kiểm tra xem scene tiếp theo có tồn tại không
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene("Home");
            UIManager.Instance.CloseAll();
            UIManager.Instance.OpenUI<ChooseLV>();
        }
    }

    IEnumerator NextSence()
    {
        yield return new WaitForSeconds(0.3f);
        LoadNextScene();
        UIManager.Instance.CloseUIDirectly<Success>();

    }
}
