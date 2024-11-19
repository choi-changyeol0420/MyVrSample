using UnityEngine;

namespace MyFps
{
    public class XrDoorCellOpen : SimpleInteractive
    {
        #region Variables
        //action
        private Animator animator;
        private Collider m_Collider;
        public AudioSource audioSource;
        #endregion
        protected override void Start()
        {
            base.Start();

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