using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;

namespace MyFps
{
    public class DoorCellOpen : Interactive
    {
        #region Variables
        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion

        private void Start()
        {
            animator = GetComponent<Animator>();
            m_Collider = GetComponent<BoxCollider>();
        }
        protected override void DoAction()
        {
            animator.SetBool("IsOpen", true);
            m_Collider.enabled = false;
            audioSource.Play();
        }
    }
}