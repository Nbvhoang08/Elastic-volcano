using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Fail : CanvasUI
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
    public void RetryBtn()
    {
        Time.timeScale = 1;
        StartCoroutine(ReLoad());
        SoundManager.Instance.PlayClickSound();
    }
    IEnumerator ReLoad()
    {
        yield return new WaitForSeconds(0.3f);
        ReloadCurrentScene();
    }
    public void ReloadCurrentScene()
    {
        // Lấy tên của scene hiện tại 
        string currentSceneName = SceneManager.GetActiveScene().name;
        //Tải lại scene hiện tại
        SceneManager.LoadScene(currentSceneName);
        UIManager.Instance.CloseUIDirectly<Fail>();
    }
}
