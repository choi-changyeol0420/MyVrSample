using UnityEngine;

namespace MyFps
{
    public class XrPickupPistol : XRGrapInteractableTwoAttach
    {
        #region Variables
        //Action
        public GameObject arrow;

        public GameObject enemyTrigger;
        public GameObject ammoBox;
        public AmmoUI ammoUI;
        #endregion
        protected override void DoAction()
        {
            arrow.SetActive(false);
            if(ammoBox)
            {
                ammoBox.SetActive(true);
            }
            if(enemyTrigger)
            {
                enemyTrigger.SetActive(true);
            }
            
            //무기획득
            PlayerStats.Instance.SetHasGun(true);
            ammoUI.ShowAmmoUI();
        }
    }
}