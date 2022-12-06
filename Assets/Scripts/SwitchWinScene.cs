using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchWinScene : MonoBehaviour
{
    public GameObject BlackPanel;
    public AudioSource AudioSrc;
    public void AnimationCallback()
    {
        SceneManager.LoadScene("WinScene", LoadSceneMode.Single);
    }
    private void Update()
    {
        if (AudioSrc == null) return;
        if (AudioSrc.time >= AudioSrc.clip.length)
        {
            if (!BlackPanel.activeSelf)
                BlackPanel.SetActive(true);
        }
    }
}
