using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class EJumpTrigger : MonoBehaviour
    {
        public GameObject activityObject;
        private GameObject thePlayer;

        private void Start()
        {
            thePlayer = GameObject.Find("Player");
        }
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(PlaySqequence());
        }
        IEnumerator PlaySqequence()
        {
            //플레이어 캐릭터 비활성화
            thePlayer.gameObject.GetComponent<FirstPersonController>().enabled = false;
            activityObject.SetActive(true);     //연출용 오브젝트 활성화
            yield return new WaitForSeconds(2f);
            Destroy(activityObject);            //연출용 오브젝트 킬
            //플레이어 캐릭터 활성화
            thePlayer.gameObject.GetComponent<FirstPersonController>().enabled = true;
            //트리거 킬
            Destroy(gameObject);
        }
    }
}