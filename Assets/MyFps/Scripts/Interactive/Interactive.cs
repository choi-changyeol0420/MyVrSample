using TMPro;
using UnityEngine;

namespace Myfps
{
    //인터렉티브를 액션을 구현하는 클래스
    public abstract class Interactive : MonoBehaviour
    {
        protected abstract void DoAction();

        #region Variables
        //actionUI
        public GameObject actinUI;
        public TextMeshProUGUI actionText;
        public string action = "";
        public TextMeshProUGUI keyText;
        public GameObject extraCross;

        private float theDistance;

        #endregion

        private void Update()
        {
            theDistance = PlayerCasting.distanceFromTarget;
        }
        private void OnMouseOver()
        {
            actionText.text = action;
            if (theDistance <= 2)   //Player와 충돌체 사이의 거리
            {
                ActionUI();
                DoAction();
            }
            else
            {
                HideActionUI();
            }
        }
        void ActionUI()
        {
            actinUI.SetActive(true);
            keyText.gameObject.SetActive(true);
            actionText.gameObject.SetActive(true);
            extraCross.SetActive(true);
        }
        private void OnMouseExit()
        {
            HideActionUI();
        }
        protected void HideActionUI()
        {
            actinUI.SetActive(false);
            actionText.gameObject.SetActive(false);
            keyText.gameObject.SetActive(false);
            extraCross.SetActive(false);
        }
    }
}