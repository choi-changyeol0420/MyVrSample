using TMPro;
using UnityEngine;

namespace Myfps
{
    public class PickupPistol : Interactive
    {
        #region Variables
        public GameObject realPistol;
        public GameObject Arrow;
        public GameObject enemyTrigger;
        public GameObject ammobox;
        public GameObject ammoUI;
        #endregion
        protected override void DoAction()
        {
            keyText.text = "[E]";
            /*if (Input.GetKeyDown(KeyCode.E))
            {
                Arrow.SetActive(false);
                enemyTrigger.SetActive(true);
                ammobox.SetActive(true);
                
                //무기 획득
                PlayerState.Instance.SetHasGun(true);
                ammoUI.SetActive(true);
                realPistol.SetActive(true);

                Destroy(gameObject);
                HideActionUI();
            }*/
        }
        
    }
}