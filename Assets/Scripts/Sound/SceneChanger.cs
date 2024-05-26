using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private SoundManager soundManager;

    private void Start()
    {
        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();
    }

    public void ChangeScene(string sceneName, string nextSceneBgmPath)
    {
        // BGM�� �����մϴ�.
        soundManager.ChangeBGM(nextSceneBgmPath);

        // �� ��ȯ�� �����մϴ�.
        SceneManager.LoadScene(sceneName);
    }
}
