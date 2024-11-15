using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;

namespace Myfps
{
    public class AOpening : MonoBehaviour
    {
        #region Variables
        public SceneFader sceneFader;
        public GameObject thePlayer;
        public GameObject pistol;

        //UI
        public TextMeshProUGUI sceneText;
        [SerializeField] private string sequence01 = "...Where am I?";
        [SerializeField] private string sequence02 = "I need get out of here";

        public AudioSource line01;
        public AudioSource line02;

        public static bool isSequence = false;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            StartCoroutine(OpeningFader());
        }
        IEnumerator OpeningFader()
        {
            isSequence = true;
            //다시 시작해도 총이 비활성화
            pistol.SetActive(false);
            //플레이 캐릭터 비 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = false;
            //페이드인 연출 (5초 대기후 페인드인 효과)
            sceneFader.FromFade(4);
            //화면 하단에 시나리오 텍스트 화면 출력(3초) (I need get out of here)
            sceneText.enabled = true;
            line01.Play();
            sceneText.text = sequence01;
            
            yield return new WaitForSeconds(3);
            line02.Play();
            sceneText.text = sequence02;
            
            yield return new WaitForSeconds(3);
            //3초후에 시나리오 텍스트 없어진다
            sceneText.text = "";
            sceneText.gameObject.SetActive(false);
            //플레이 캐릭터 활성화
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            isSequence = false;
        }
    }
}
