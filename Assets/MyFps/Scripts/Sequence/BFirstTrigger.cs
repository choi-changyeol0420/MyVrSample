using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using StarterAssets;

namespace Myfps
{
    public class BFirstTrigger : MonoBehaviour
    {
        #region Variables
        public GameObject thePlayer;
        public TextMeshProUGUI sceneText;
        private string lineText = "Looks like a weapon on that table.";
        public GameObject Arrow;
        public AudioSource line03;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(FirstTrigger());
        }
        //트리거 작동시 플레이
        IEnumerator FirstTrigger()
        {
            //플레이 캐릭터 비활성화  (플레이 멈춤)
            thePlayer.GetComponent<FirstPersonController>().enabled = false;

            //대사 출력 :  "Looks like a weapon on that table."
            line03.Play();
            sceneText.gameObject.SetActive(true);
            sceneText.text = lineText;

            //1초 딜레이
            yield return new WaitForSeconds(1);

            //화살표 활성화
            Arrow.SetActive(true);

            //1초 딜레이
            yield return new WaitForSeconds(1);

            //초기화
            sceneText.text = "";
            sceneText.gameObject.SetActive(false);

            //플레이 캐릭터 활성화 (다시 플레이)
            thePlayer.GetComponent<FirstPersonController>().enabled = true;
            Destroy(gameObject);
        }
    }
}