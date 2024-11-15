using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class PickupAmmo : PickupItem
    {
        #region Variables
        [SerializeField] private int giveAmmo = 7;           //획득한 탄환갯수
        #endregion
        protected override bool OnPickup()
        {
            //탄환 7개 지급
            PlayerState.Instance.AddAmmo(giveAmmo);
            return true;
        }
    }
}
