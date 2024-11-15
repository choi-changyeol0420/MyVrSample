using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class AmmoUI : MonoBehaviour
    {
        #region Variables
        public GameObject ammoUI;
        #endregion

        private void Start()
        {
            ShowAmmoUI();
        }
        private void ShowAmmoUI()
        {
            ammoUI.SetActive(PlayerState.Instance.HasGun);
        }
    }
}