using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public enum Sound
{
    Bgm, // �������
    Effect, // ȿ����
    MaxCount, // Sound enum�� ���� ���� ���� ����
}

// SoundManager Ŭ���� 
public class SoundManager : MonoBehaviour
{
    // ����� �ҽ����� ������ ����Ʈ
    private AudioSource[] _audioSources = new AudioSource[(int)Sound.MaxCount];

    // ����� Ŭ������ ������ ��ųʸ�
    private Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public SceneChanger sceneChanger;
    public InputField nicknameInputField;
    public GameObject RoomEnterBtn;

    private void Awake()
    {
        Init();
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        // �� �̸��� GameStartScene�̶��
        string sceneName = SceneManager.GetActiveScene().name;
        if (sceneName == "GameStartScene")
        {
            Init();

            // SceneChanger �ʱ�ȭ
            sceneChanger = FindObjectOfType<SceneChanger>();

            if (sceneChanger == null)
            {
                GameObject sceneChangerObj = new GameObject("SceneChanger");
                sceneChanger = sceneChangerObj.AddComponent<SceneChanger>();
            }

            // Bgm�� �ҷ����� ����մϴ�.
            AudioClip BgmClip = Resources.Load<AudioClip>("Sound/Game_Play_Ost");
            Play(BgmClip, Sound.Bgm, 1.0f, 0.1f);

            // �г��� �Է� �ʵ��� �̺�Ʈ�� ������ �߰�
            nicknameInputField.onValueChanged.AddListener(OnNicknameChanged);
        }
        // �� �̸��� GameLobby���
        else if (sceneName == "GameLobby")
        {
            StartCoroutine(sceneChanger.SoundsVolumesUp("Sound/GameLobby_Sleepy Sunshine"));
           
            RoomEnterBtn = GameObject.Find("EnterRoom");
            
            Button EnterBtn = RoomEnterBtn.GetComponent<Button>();

            EnterBtn.onClick.AddListener(OnStartButtonClick);
        }
        else if (sceneName == "GameRoom")
        {
            RoomEnterBtn = GameObject.Find("GameReadyBtn");

            Button EnterBtn = RoomEnterBtn.GetComponent<Button>();

            EnterBtn.onClick.AddListener(OnStartButtonClick);

            GameObject chatInputField = GameObject.Find("ChatInputField");

            nicknameInputField = chatInputField.GetComponent<InputField>();

            nicknameInputField.onValueChanged.AddListener(OnNicknameChanged);
        }
    }

    public void OnStartButtonClick()
    {
        // ȿ������ �ҷ����� ����մϴ�.
        AudioClip effectClip = Resources.Load<AudioClip>("Sound/Shop_Experience_Up");
        Play(effectClip, Sound.Effect, 1.0f);
        Debug.Log("Start button sound is comming out!");
    }

    private void OnNicknameChanged(string newNickname)
    {
        // �г����� ����� ������ ȿ���� ���
        AudioClip typingSoundClip = Resources.Load<AudioClip>("Sound/Keyboard_Click_Sound");
        Play(typingSoundClip, Sound.Effect, 3.0f, 0.6f);
    }

    // �ʱ�ȭ
    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");

        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root); // Bgm�� ������ �ٸ��� �ҰŶ�� �ּ�ó�� �ؾ���.

            string[] soundNames = System.Enum.GetNames(typeof(Sound)); // "Bgm", "Effect"
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Sound.Bgm].loop = true; // bgm ������ ���� �ݺ� ���
        }
    }

    // ��� ���� �ʱ�ȭ
    public void Clear()
    {
        // ��� ����� �ҽ� ���� �� Ŭ�� ����
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.Stop();
            audioSource.clip = null;
        }

        // ȿ���� Dictionary ����
        _audioClips.Clear();
    }

    // ����� Ŭ�� ���
    public void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        if (audioClip == null)
        {
            Debug.LogWarning("AudioClip is null");
            return;
        }

        if (type == Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Sound.Bgm];
            if (audioSource.isPlaying) // BGM ��ø ����
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            //audioSource.volume = 0.5f; // ���� ����
            audioSource.Play();
        }

        else
        {
            AudioSource audioSource = _audioSources[(int)Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    // ���� ���� ������ ����� Ŭ�� ���
    public void Play(AudioClip audioClip, Sound type = Sound.Effect, float pitch = 1.0f, float volumn = 1.0f)
    {
        if (audioClip == null)
        {
            Debug.LogWarning("AudioClip is null");
            return;
        }

        if (type == Sound.Bgm)
        {
            AudioSource audioSource = _audioSources[(int)Sound.Bgm];
            if (audioSource.isPlaying) // BGM ��ø ����
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.volume = volumn; // ���� ����
            audioSource.Play();
        }

        else
        {
            AudioSource audioSource = _audioSources[(int)Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.volume = volumn; // ���� ����
            audioSource.PlayOneShot(audioClip);
        }
    }


    // ��θ� ���� ����� Ŭ�� ���
    public void Play(string path, Sound type = Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetorAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }


    // ����� Ŭ�� �ε� �Ǵ� ��ųʸ����� �˻�
    public AudioClip GetorAddAudioClip(string path, Sound type = Sound.Effect)
    {
        if (!path.Contains("Sound/"))
            path = $"Sounds/{path}"; // Sound ���� �ȿ� ����� �� �ֵ���

        AudioClip audioClip = null;

        if (type == Sound.Bgm) // BGM ������� Ŭ�� �ε�
        {
            audioClip = Resources.Load<AudioClip>(path);
        }
        else // Effect ȿ���� Ŭ�� ���̱�
        {
            if (_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Resources.Load<AudioClip>(path);
                _audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }

    public AudioSource GetBgmSource()
    {
        return _audioSources[(int)Sound.Bgm];
    }
}


// Manager Ŭ����
public class Manager : MonoBehaviour
{
    private static Manager s_instance;

    public static Manager Instance
    {
        get
        {
            if (s_instance == null)
                Init();
            return s_instance;
        }
    }

    private SoundManager _soundManager;
    public static SoundManager Sound
    {
        get { return Instance._soundManager; }
    }

    private static void Init()
    {
        if (s_instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Manager>();
                DontDestroyOnLoad(go);
            }

            s_instance = go.GetComponent<Manager>();
            s_instance._soundManager = go.AddComponent<SoundManager>();
            s_instance._soundManager.Init();
        }
    }

    private void Awake()
    {
        if (s_instance == null)
        {
            s_instance = this;
            DontDestroyOnLoad(gameObject);
            _soundManager = gameObject.AddComponent<SoundManager>();
            _soundManager.Init();
        }
        else if (s_instance != this)
        {
            Destroy(gameObject);
        }
    }
}


