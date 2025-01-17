using UnityEngine;
using System.Collections;
using DG.Tweening;
using UnityEngine.UI;

namespace CodingStrategy.Entities.Animations
{
    public class LilbotAnimation : MonoBehaviour
    {
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int Jump = Animator.StringToHash("Jump");
        private static readonly int Attack1 = Animator.StringToHash("Attack1");
        private static readonly int Attack2 = Animator.StringToHash("Attack2");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Hit = Animator.StringToHash("Hit");

        public Animator animator;

        public bool jump;
        public bool attack1;
        public bool attack2;
        public bool hit;
        public bool death;

        public float duration = 1f;
        public Camera playerCamera;


        LilboStatment lilboStatment;
        public Image[] statements;

        private SoundManager soundManager; // 사운드

        public void Start()
        {
            lilboStatment = gameObject.GetComponent<LilboStatment>();
            statements = lilboStatment.statements;
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.L))
            {
                StartCoroutine(StatementActive("Trojan"));
            }
        }

        private void Vibrate()
		{
        #if (UNITY_ANDROID || UNITY_IOS)
            // Handheld.Vibrate();
        #endif
		}

		public IEnumerator Walk(float speed, int x, int z)
        {
            //speed의 값이 1에 가까우면 가까울수록 달리는 애니메이션이 틀어질거에요.
            //1이면 나루토 달리기, 0.5면 뚜방뚜방 걷기, 0이면 가만히 서있기를 실행합니다.
            animator.SetFloat(Speed, speed);


            // 현재 객체를 (x, y, z) 위치로 speed 속도로 이동합니다. 그러니까,
            Vector3 targetPosition = new Vector3(x, transform.position.y, z);

            // 캐릭터가 걸을 때 나는 소리. 단, 이 코드는 한 발자국 이동했을 때 사운드만 들림.
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_CharacterWalk_Sound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f);
            Debug.Log("Character walk sound is comming out!");


            // DoTween의 DoMove 함수를 사용하여 이동합니다.
            transform.DOMove(targetPosition, duration).SetEase(Ease.Linear);


            // 이동 완료까지 기다립니다.
            yield return new WaitForSeconds(duration);


            // 이동이 완료되면 애니메이션 Speed를 0으로 설정하여 Idle 상태로 돌아갑니다.
            animator.SetFloat(Speed, 0);
        }

        public IEnumerator SpawnAnimationCoroutine()
        {
            Vector3 returnPosition = gameObject.transform.position;
            
            Vector3 endPosition = new Vector3(transform.position.x, transform.position.y + 1.3f, transform.position.z);

            gameObject.transform.position = new Vector3(transform.position.x, transform.position.y + 10.0f, transform.position.z);

            

            Sequence sequence = DOTween.Sequence();

            sequence.AppendCallback(() => animator.SetTrigger(Jump));

            sequence.Insert(0, transform.DOMove(endPosition, 0.8f).SetEase(Ease.OutCubic));

            sequence.AppendCallback(() => animator.ResetTrigger(Jump));

            sequence.Append(transform.DOMove(returnPosition, 0.2f));

            yield return sequence.WaitForCompletion();
            // 1초 대기

        }


        #region attack_Animation

        //로봇 기준 오른손 어퍼컷
        public IEnumerator AttackRightAnimationCoroutine()
        {
            animator.SetTrigger(Attack1);
            // 오른손 어퍼컷 사운드. 왼손과 동일
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_RobotAttacked_Sound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
            Debug.Log("Robot Attacked sound is comming out!");

            //Vibrate();

            yield return new WaitForSeconds(1); // 1초 대기
            animator.ResetTrigger(Attack1);
        }

        //로봇 기준 왼손 어퍼컷
        public IEnumerator AttackLeftAnimationCoroutine()
        {
            animator.SetTrigger(Attack2);
            // 왼손 어퍼컷 사운드. 오른손과 동일
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_RobotAttacked_Sound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
            Debug.Log("Robot Attacked sound is comming out!");

            //Vibrate();

            yield return new WaitForSeconds(1); // 1초 대기
            animator.ResetTrigger(Attack2);
        }

        #endregion


        #region Death_Animation

        public IEnumerator DeathAnimationCoroutine()
        {
            animator.SetTrigger(Death);
            // 죽고 나오는 사운드 GameScene_RobotDeath_Sound
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_RobotDeath_Sound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
            Debug.Log("Robot death sound is comming out!");

            playerCamera.DOShakePosition(1, 3);
            yield return new WaitForSeconds(1); // 1초 대기
            animator.ResetTrigger(Death);
        }

        #endregion


        #region Hit_Animation

        //피격할 때의 애니메이션 작업을 진행합니다.
        public IEnumerator HitAnimationCoroutine()
        {
            animator.SetTrigger(Hit);

            // 피격당하고 나오는 사운드
            soundManager = FindObjectOfType<SoundManager>();
            soundManager.Init();
            AudioClip effectClip = Resources.Load<AudioClip>("Sound/GameScene_GotAttacked_Sound");
            soundManager.Play(effectClip, Sound.Effect, 1.0f, 0.5f);
            Debug.Log("GetAttacked sound is comming out!");

            //Vibrate();

            playerCamera.DOShakePosition(1, 1);
            yield return new WaitForSeconds(1); // 1초 대기
            animator.ResetTrigger(Hit);
        }

        #endregion

        #region define Statement

        public IEnumerator StatementActive(string statement)
        {
            animator.SetTrigger(Hit);
            
            if(statement == "Trojan")
            {
                statements[0].gameObject.SetActive(true);
            }
            else if(statement == "Malware")
            {
                statements[1].gameObject.SetActive(true);
            }
            
            yield return new WaitForSeconds(0.8f); // 0.8초 대기

            for(int i =0;i<statement.Length;i++)
            {
                statements[i].gameObject.SetActive(false);
            }

            animator.ResetTrigger(Hit);
        }
        #endregion
    }
}
