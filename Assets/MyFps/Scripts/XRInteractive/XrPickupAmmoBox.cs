using UnityEngine;

namespace MyFps
{
    public class XrPickupAmmoBox : SimpleInteractive
    {
        #region Variables
        //AmmoBox 아이템 획득시 지급하는 ammo 갯수
        [SerializeField] private int giveAmmo = 7;
        public AmmoUI ammoUI;
        #endregion
        protected override void DoAction()
        {
            Debug.Log("탄환 7개를 지급 했습니다");
            PlayerStats.Instance.AddAmmo(giveAmmo);

            //UI
            ammoUI.ShowAmmoUI();

            //킬
            Destroy(gameObject);
        }
    }
}