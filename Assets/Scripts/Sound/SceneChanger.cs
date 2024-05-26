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

        StartCoroutine(CrossFadeBGM(nextSceneBgmPath, fadeDuration)); // CrossFadeBGM 코루틴 시작

        // 씬 전환을 실행합니다.
        StartCoroutine(LoadSceneWithDelay(sceneName, fadeDuration));
    }

    // BGM Cross Fade 효과
    private IEnumerator CrossFadeBGM(string nextSceneBgmPath, float fadeDuration)
    {
        AudioSource bgm1 = soundManager.GetAudioSource(Sound.Bgm); // 현재 재생 중인 BGM1 AudioSource 가져오기

        // Fade Out 효과
        float startVolume = bgm1.volume;
        float startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            bgm1.volume = Mathf.Lerp(startVolume, 0f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }
        bgm1.Stop(); // BGM1 재생 중지

        // BGM2 재생
        soundManager.ChangeBGM(nextSceneBgmPath, 0f); // BGM2를 0 볼륨으로 재생 시작

        AudioSource bgm2 = soundManager.GetAudioSource(Sound.Bgm); // BGM2 AudioSource 가져오기

        // Fade In 효과
        startTime = Time.time;
        while (Time.time < startTime + fadeDuration)
        {
            bgm2.volume = Mathf.Lerp(0f, 1f, (Time.time - startTime) / fadeDuration);
            yield return null;
        }
        bgm2.volume = 1f; // 최종적으로 볼륨을 1로 설정
    }

    // 씬 전환을 지연시키는 코루틴
    private IEnumerator LoadSceneWithDelay(string sceneName, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(sceneName);
    }
}
