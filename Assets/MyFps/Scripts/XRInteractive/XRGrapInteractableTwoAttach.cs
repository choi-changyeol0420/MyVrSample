using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyFps
{
    /// <summary>
    /// 두개의 Attach Point 구현
    /// </summary>
    public class XRGrapInteractableTwoAttach : GrabInteractable
    {
        #region Variables
        public Transform leftAttachTranfrom;
        public Transform rightAttachTranfrom;

        
        #endregion
        protected override void OnSelectEntering(SelectEnterEventArgs args)
        {
            //두개의 Attach Point를 잡는 손에 따라 구분해서 적용
            if(args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTranfrom;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTranfrom;
            }

            base.OnSelectEntering(args);
        }
        /*protected override void OnSelectEntered(SelectEnterEventArgs args)
        {
            //두개의 Attach Point를 잡는 손에 따라 구분해서 적용
            if (args.interactorObject.transform.CompareTag("LeftHand"))
            {
                attachTransform = leftAttachTranfrom;
            }
            else if (args.interactorObject.transform.CompareTag("RightHand"))
            {
                attachTransform = rightAttachTranfrom;
            }

            base.OnSelectEntered(args);
        }*/
        protected override void DoAction()
        {
            throw new System.NotImplementedException();
        }
    }
}