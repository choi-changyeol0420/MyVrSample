using Unity.Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class CinemachineShake : Singleton<CinemachineShake>
    {
        #region Variables
        [SerializeField]private CinemachineVirtualCamera cvCamera;
        [SerializeField] private CinemachineBasicMultiChannelPerlin channelPerlin;

        [SerializeField]private bool isShake = false;
        //[SerializeField]protected float amplitued = 1f;     //진폭 흔들림의 크기
        [SerializeField]private float frequency = 1f;     //흔들림의 속도
        #endregion

        protected override void Awake()
        {
            base.Awake();

            cvCamera = this.GetComponent<CinemachineVirtualCamera>();
            channelPerlin = cvCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
        }

        private void Update()
        {
            //Cheating
            /*if(Input.GetKeyDown(KeyCode.G))
            {
                ShakeCamera(1f,1f);
            }*/
        }
        //카메라 흔들기
        //amplitued : 진폭 흔들림의 크기, shakeTime : 흔들리는 시간
        public void ShakeCamera(float amplitued, float shakeTime)
        {
            //현재 흔들리고 있으면 더 흔들리지 않는다
            if (isShake) return;

            StartCoroutine(StartShake(amplitued, shakeTime));
        }
        IEnumerator StartShake(float amplitued, float shakeTime)
        {
            isShake = true;
            channelPerlin.AmplitudeGain = amplitued;
            channelPerlin.FrequencyGain = frequency;
            yield return new WaitForSeconds(shakeTime);
            channelPerlin.FrequencyGain = 0f;
            channelPerlin.FrequencyGain = 0f;
            isShake = false;
        }
    }
}