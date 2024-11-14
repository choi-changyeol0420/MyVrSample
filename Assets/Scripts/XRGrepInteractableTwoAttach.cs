using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

namespace MyVrSample
{
    /// <summary>
    /// 두개의 Attach Point 구현
    /// </summary>
    public class XRGrepInteractableTwoAttach : XRGrabInteractable
    {
        #region Variables
        public Transform leftAttachTranfrom;
        public Transform rightAttachTranfrom;
        #endregion
        protected override void OnSelectEntered(SelectEnterEventArgs args)
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

            base.OnSelectEntered(args);
        }
    }
}