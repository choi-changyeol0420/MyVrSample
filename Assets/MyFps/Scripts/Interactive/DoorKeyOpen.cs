using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Myfps
{
    public class DoorKeyOpen : Interactive
    {
        private Animator animator;
        private Collider m_collider;
        private PlayerState State;
        public TextMeshProUGUI TextBox;

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_collider = GetComponent<BoxCollider>();
            State = PlayerState.Instance;
        }
        protected override void DoAction()
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!State.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
                {
                    StartCoroutine(LockDoor());
                }
                else if (State.HasPuzzleItem(PuzzleKey.ROOM01_KEY))
                {
                    OpenDoor();
                }
            }    
        }
        void OpenDoor()
        {
            animator.SetBool("IsOpen", true);
            AudioManager.Instance.Play("DoorBang");
            keyText.gameObject.SetActive(false);
            actionText.gameObject.SetActive(false);
            m_collider.enabled = false;
        }
        IEnumerator LockDoor()
        {
            AudioManager.Instance.Play("DoorLocked");
            keyText.gameObject.SetActive(false);
            actionText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.2f);
            TextBox.enabled = true;
            TextBox.text = "You need the Key";
            yield return new WaitForSeconds(2);
            TextBox.enabled = false;
            TextBox.text = "";
            keyText.gameObject.SetActive(true);
            actionText.gameObject.SetActive(true);
        }
    }
}