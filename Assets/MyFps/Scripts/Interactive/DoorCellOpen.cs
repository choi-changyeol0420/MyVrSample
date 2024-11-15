using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Myfps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        private Animator Door;
        private Collider m_collider;
        public AudioSource Audio;
        #endregion
        private void Start()
        {
            Door = GetComponent<Animator>();
            m_collider = GetComponent<BoxCollider>();
        }

        //마우스를 가져가면 액션 UI를 보여준다
        protected override void DoAction()
        {
            StartCoroutine(Colliderenabled());
        }
        IEnumerator Colliderenabled()
        {
            m_collider.enabled = true;
            if (Input.GetKeyDown(KeyCode.E))    //여는 키
            {
                //Debug.Log("Open the Door");
                Door.SetBool("IsOpen", true);
                Audio.Play();
                //닫을 때에 텍스트
                keyText.text = "[R]";
                actionText.text = "Close the Door";
                m_collider.enabled = false;
                yield return new WaitForSeconds(2);
                m_collider.isTrigger = true;
                m_collider.enabled = true;
            }
            else if (Input.GetKeyDown(KeyCode.R))   //닫는 키
            {
                //close the Door
                Door.SetBool("IsOpen", false);
                Audio.Play();
                //열 때에 텍스트
                keyText.text = "[E]";
                actionText.text = "Open the Door";
                m_collider.isTrigger= false;
            }
        }
    }
}