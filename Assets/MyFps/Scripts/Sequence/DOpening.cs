using StarterAssets;
using System.Collections;
using TMPro;
using UnityEngine;

namespace Myfps
{
    public class DOpening : MonoBehaviour
    {
        public SceneFader fader;
        public TextMeshProUGUI TextBox;
        public GameObject thePlayer;
        public GameObject pistol;
        
        // Start is called before the first frame update
        void Start()
        {
            //마우스 커서 상태 설정
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;

            StartCoroutine(SequencePlay());
        }

        
        IEnumerator SequencePlay()
        {
            pistol.SetActive(true);
            //플레이어 비활성화
            thePlayer.GetComponent<FirstPersonController>().MoveSpeed = 0f;
            thePlayer.GetComponent<FirstPersonController>().RotationSpeed = 0f;

            //배경음 시작
            AudioManager.Instance.PlayBgm("PlayBGM");
            //시퀀스 텍스트 초기화
            TextBox.text = "";
            yield return new WaitForSeconds(1);
            fader.FromFade();
            yield return new WaitForSeconds(1);
            thePlayer.GetComponent<FirstPersonController>().MoveSpeed = 4f;
            thePlayer.GetComponent<FirstPersonController>().RotationSpeed = 1f;
        }
    }
}