using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class XRDoorCellExit : SimpleInteractive
    {
        #region Variables
        public SceneFader fader;
        [SerializeField] private string loadToScene = "MainScene02";

        private Animator animator;
        private Collider m_Collider;
        public AudioSource creakyDoor; //문여는 소리

        public AudioSource bgm01;         //배경음
        #endregion

        protected override void Start()
        {
            base.Start();
            //참조
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<Collider>();
        }

        protected override void DoAction()
        {
            //1.문여는 애니메이션
            //2.문여는 사운드
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;

            creakyDoor.Play();

            StartCoroutine(ChangeScene());
        }

        IEnumerator ChangeScene()
        {
            //씬마무리, .... bmg stop
            bgm01.Stop();

            //다음씬으로 이동
            fader.FadeTo(-1);

            yield return new WaitForSeconds(2);

            Application.Quit();
        }
    }
}