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
        if (soundManager == null)
        {
            Debug.LogError("SoundManager not found in the scene.");
            return;
        }
        soundManager.Init();
    }

    public void ChangeSceneWithCrossFade(string sceneName, string nextSceneBgmPath, float fadeDuration)
    {
        if (soundManager == null)
        {
            Debug.LogError("SoundManager is null. Make sure it's properly initialized.");
            return;
        }

        StartCoroutine(CrossFadeBGM(nextSceneBgmPath, fadeDuration)); // CrossFadeBGM �ڷ�ƾ ����

        // �� ��ȯ�� �����մϴ�.
        StartCoroutine(LoadSceneWithDelay(sceneName, fadeDuration));
    }

    // BGM Cross Fade ȿ��
    private IEnumerator CrossFadeBGM(string nextSceneBgmPath, float fadeDuration)
    {
        AudioSource bgm1 = soundManager.GetAudioSource(Sound.Bgm); // ���� ��� ���� BGM1 AudioSource ��������

        // Fade Out ȿ��
        float startVolume = bgm1.volume;
        float startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            bgm1.volume = Mathf.Lerp(startVolume, 0f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }
        bgm1.Stop(); // BGM1 ��� ����

        // BGM2 ���
        soundManager.ChangeBGM(nextSceneBgmPath, 0f); // BGM2�� 0 �������� ��� ����

        AudioSource bgm2 = soundManager.GetAudioSource(Sound.Bgm); // BGM2 AudioSource ��������

        // Fade In ȿ��
        startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            bgm2.volume = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }
        bgm2.volume = 1f; // ���������� ������ 1�� ����
    }

    // �� ��ȯ�� ������Ű�� �ڷ�ƾ
    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
