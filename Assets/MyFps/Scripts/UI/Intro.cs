using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class Intro : MonoBehaviour
    {
        #region Variables
        public SceneFader fader;
        [SerializeField]private string loadToSecen = "MainScene01";

        //Speed 2.5
        public CinemachineDollyCart cart;

        [SerializeField]private bool[] isArrive;
        [SerializeField]private int wayPointIndex = 0;  //이동 목표지점 인덱스

        public Animator cameraanimator;
        public GameObject introUI;
        public GameObject theShedlight;
        #endregion
        private void Start()
        {
            //초기화
            cart.m_Speed = 0;
            wayPointIndex = 0;
            isArrive = new bool[6];
            StartCoroutine(StartIntro());
        }
        private void Update()
        {
            //도착판정
            if(cart.m_Position >= wayPointIndex && isArrive[wayPointIndex] == false)
            {
                //연출 - 
                if(wayPointIndex == isArrive.Length - 1)
                {
                    //마지막지점
                    StartCoroutine(EndIntro());
                }
                else
                {
                    StartCoroutine(StayIntro());
                }
            }
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                fader.FadeTo(loadToSecen);
                AudioManager.Instance.StopBgm();
            }
        }
        IEnumerator StartIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;

            fader.FromFade();
            AudioManager.Instance.PlayBgm("Opening");
            yield return new WaitForSeconds(1f);
            cameraanimator.SetTrigger("ArroundTrigger");
            yield return new WaitForSeconds(3.5f);

            cart.m_Speed = 0.065f;
            
        }
        IEnumerator StayIntro()
        {
            isArrive[wayPointIndex] = true;
            wayPointIndex++;
            Debug.Log($"{wayPointIndex}번 도착");
            cart.m_Speed = 0f;
            //카메라 애니메이션
            cameraanimator.SetTrigger("ArroundTrigger");

            int nowIndex = wayPointIndex - 1;
            if (nowIndex == 0)
            {
                introUI.SetActive(false);
            }
            else if (nowIndex == 1)
            {
                introUI.SetActive(true);
            }
            yield return new WaitForSeconds(4f);
            if (nowIndex == 4)
            {
                theShedlight.SetActive(true);
                yield return new WaitForSeconds(1f);
            }
            //출발
            cart.m_Speed = 0.065f;
        }

        //
        IEnumerator EndIntro()
        {
            isArrive[wayPointIndex] = true;
            cart.m_Speed = 0f;
            yield return new WaitForSeconds(2f);
            theShedlight.SetActive(false);
            yield return new WaitForSeconds(2f);

            theShedlight.SetActive(false);
            AudioManager.Instance.StopBgm();
            fader.FadeTo(loadToSecen);

        }
    }
}