using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSoundManager : MonoBehaviour
{

    private SoundManager soundManager;

    // ���� �ﰢ�� ��ư Ŭ�� �� �� ����
    public IEnumerator ShopDragBtnClicked(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_DragBtnClick_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Drag sound is comming out!");
    }

    // �������� ���� ����
    public IEnumerator RerollBtnClicked(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_Reroll_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Reroll sound is comming out!");
    }

    // �������� ������ ����
    public IEnumerator LevelupBtnClicked(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_Levelup_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Levelup sound is comming out!");
    }

    // �������� Ŀ��� �ű�� ���� Ŭ���� �� ����
    public IEnumerator CommnadClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_CommandClick_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("CommnadClickedSound is comming out!");
    }

}
