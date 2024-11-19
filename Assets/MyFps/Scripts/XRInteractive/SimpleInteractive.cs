using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public abstract class SimpleInteractive : XRSimpleInteractable
    {
        protected abstract void DoAction();

        #region Variables
        private float theDistance;

        //action UI
        public GameObject actionUI;
        public TextMeshProUGUI actionText;
        [SerializeField] private string action = "Action Text";

        //true이면 Interactive 기능을 정지
        protected bool unInteractive = false;

        //카메라
        private Transform Head;
        #endregion

        protected virtual void Start()
        {
            //참조
            Head = Camera.main.transform;
        }
        protected virtual void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;

        }
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            if(unInteractive)
                return;

            base.OnHoverEntered(args);
            ShowActionUI();
            //Debug.Log("ShowAction");
        }
        protected override void OnHoverExited(HoverExitEventArgs args)
        {

            base.OnHoverExited(args);
            HideActionUI();
            //Debug.Log("HideAction");
        }
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);
            DoAction();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);
            actionUI.transform.position = Head.position
                + new Vector3(Head.forward.x, 0f, Head.forward.z).normalized * (theDistance - 0.02f);
            actionUI.transform.LookAt(new Vector3(Head.position.x,actionUI.transform.position.y, Head.position.z));
            actionUI.transform.forward *= -1;

            actionText.text = action;
            
        }

        void HideActionUI()
        {
            actionUI.SetActive(false);
            actionText.text = "";
            //extraCross.SetActive(false);
        }
    }
}