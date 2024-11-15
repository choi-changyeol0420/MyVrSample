using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Myfps
{
    public class CEnemytrigger : MonoBehaviour
    {
        #region Variables
        public GameObject theDoor;      //문
        public AudioSource doorBang;    //문 열기 사운드
        public AudioSource bgm01;  //메인씬 1 배경음
        public AudioSource bgm02;  //적 등장 배경음
        
        public GameObject theEnemy;     //적
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            StartCoroutine(FirstTrigger());
        }
        //트리거 작동시 플레이
        IEnumerator FirstTrigger()
        {
            //문 열기 애니메이션
            theDoor.GetComponent<Animator>().SetBool("IsOpen", true);
            theDoor.GetComponent<BoxCollider>().enabled = false;
            //문 사운드
            bgm01.Stop();
            doorBang.Play();
            //Enemy 활성화
            theEnemy.SetActive(true);

            yield return new WaitForSeconds(1f);

            //Enemy 등장 사운드
            bgm02.Play();
            EnemyController enemy = theEnemy.GetComponent<EnemyController>();
            if (enemy != null)
            {
                enemy.SetState(EnemyState.E_Walk);
            }
            Destroy(this.gameObject);
        }
    }
}