using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSoundManager : MonoBehaviour
{

    private SoundManager soundManager;

    // ���� �ﰢ�� ��ư Ŭ�� �� �� ����
    public void ShopDragBtnClicked()
    {
        StartCoroutine(ShopDragBtnClickedSound(0));
    }
    public IEnumerator ShopDragBtnClickedSound(float delay)
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
    public void RerollBtnClicked()
    {
        StartCoroutine(RerollBtnClickedSound(0));
    }
    public IEnumerator RerollBtnClickedSound(float delay)
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
    public void LevelupClicked()
    {
        StartCoroutine(LevelupBtnClickedSound(0));
    }
    public IEnumerator LevelupBtnClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_Levelup_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Levelup sound is comming out!");
    }

    /*
    // �������� Ŀ��� �ű�� ���� Ŭ���� �� ����
    public void CommandClicked()
    {
        StartCoroutine(CommandClickedSound(0));
    }
    public IEnumerator CommandClickedSound(float delay)
    {
        yield return new WaitForSeconds(delay);

        soundManager = FindObjectOfType<SoundManager>();
        soundManager.Init();

        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_CommandClick_Sound");
        soundManager.Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("CommnadClickedSound is comming out!");
    }*/

}
