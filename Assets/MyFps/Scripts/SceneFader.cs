using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Myfps
{
    public class SceneFader : MonoBehaviour
    {
        #region Variables
        //Fader 이미지
        public Image sceneFader;
        public AnimationCurve curve;
        #endregion
        private void Start()
        {
            //초기화: 시작시 화면을 검정색으로 시작
            sceneFader.color = new Color(0, 0, 0, 1);
            //FromFade();
        }

        public void FadeTo(string scenename)
        {
            StartCoroutine(FadeOut(scenename));
        }
        public void FadeTo(int sceneNumber)
        {
            StartCoroutine(FadeOut(sceneNumber));
        }
        public void FromFade(float delayTime = 0f)
        {
            StartCoroutine (FadeIn(delayTime));
        }
        IEnumerator FadeIn(float delayTime)
        {
            if (delayTime > 0)
            {
                yield return new WaitForSeconds(delayTime);
            }
            float t = 1f;
            while(t > 0)
            {
                t -= Time.deltaTime;
                float a = curve.Evaluate(t);
                sceneFader.color = new Color(0, 0, 0, a);

                yield return 0f;
            }
        }
        IEnumerator FadeOut(string scenename)
        {
            float t = 0f;
            while (t < 1)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                sceneFader.color = new Color(0, 0, 0, a);

                yield return 0f;
            }

            //다음씬 로드
            SceneManager.LoadScene(scenename);
        }
        IEnumerator FadeOut(int sceneNumber)
        {
            float t = 0f;
            while (t < 1)
            {
                t += Time.deltaTime;
                float a = curve.Evaluate(t);
                sceneFader.color = new Color(0, 0, 0, a);

                yield return 0f;
            }

            //다음씬 로드
            SceneManager.LoadScene(sceneNumber);
        }
    }
}