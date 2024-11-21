using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

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
        [SerializeField] private float offset = 0f;

        private bool isHover = false;

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
            if(unInteractive)
                return;
            //theDistance = PlayerCasting.distanceFromTarget;
            theDistance = GetDistanceFormHead();
        }
        protected override void OnHoverEntered(HoverEnterEventArgs args)
        {
            if(unInteractive)
                return;

            base.OnHoverEntered(args);

            /*if(args.interactorObject is XRDirectInteractor)
            {
                ShowActionUI();
            }
            else*/
            {
                if(theDistance < 2.0f)
                {
                    ShowActionUI();
                }
            }
            
        }
        protected override void OnHoverExited(HoverExitEventArgs args)
        {
            base.OnHoverExited(args);

            HideActionUI();
        }
        protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            base.OnSelectEntered(args);

            if (theDistance < 2.0)
            {
                unInteractive = true;
                HideActionUI();

                DoAction();
            }
        }
        protected override void OnSelectExited(SelectExitEventArgs args)
        {
            base.OnSelectExited(args);
            GetComponent<BoxCollider>().isTrigger = false;
        }
        void ShowActionUI()
        {
            if (isHover)
                return;
            isHover = true;
            actionUI.SetActive(true);
            //theDistance 와 오브젝트까지의 거리를 계산하여
            actionUI.transform.position = Head.position
                + new Vector3(Head.forward.x, 0f, Head.forward.z).normalized * (theDistance - offset);
            actionUI.transform.LookAt(new Vector3(Head.position.x, actionUI.transform.position.y, Head.position.z));
            actionUI.transform.forward *= -1;

            actionText.text = action;
        }

        void HideActionUI()
        {
            if (!isHover)
                return;
            isHover = false;
            actionUI.SetActive(false);
            actionText.text = "";
            //extraCross.SetActive(false);
        }
        float GetDistanceFormHead()
        {
            float distance = 0f;
            Vector3 pos = new Vector3(transform.position.x,Head.position.y,transform.position.z);
            distance = Vector3.Distance(pos, Head.position);
            return distance;
        }
    }
}