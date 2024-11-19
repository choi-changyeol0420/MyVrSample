using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    public abstract class GrabInteractable : XRGrabInteractable
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

        private Vector3 grabObjectPosition;
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
            if (unInteractive)
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

            HideActionUI();

            DoAction();
        }

        void ShowActionUI()
        {
            actionUI.SetActive(true);

            //theDistance 와 오브젝트까지의 거리를 계산하여
            float distance = Vector3.Distance(Head.position, transform.position);
            if (distance < theDistance)
            {
                actionUI.transform.position = Head.position
                + new Vector3(Head.forward.x, 0f, Head.forward.z).normalized * (distance - 0.02f);
            }
            else
            {
                actionUI.transform.position = Head.position
                + new Vector3(Head.forward.x, 0f, Head.forward.z).normalized * (theDistance - 0.02f);
            }
            actionUI.transform.LookAt(new Vector3(Head.position.x, actionUI.transform.position.y, Head.position.z));
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