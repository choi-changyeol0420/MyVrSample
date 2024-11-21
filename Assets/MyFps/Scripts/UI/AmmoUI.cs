using System.Collections;
using UnityEngine;

namespace MyFps
{
    public class AmmoUI : WorldMenu
    {
        #region Variables
        private float showDelay = 2f;
        #endregion
        //AmmoUI 보여주고 2초후에 사라진다

        public void ShowAmmoUI()
        {
            StartCoroutine(ShowUI());
        }

        IEnumerator ShowUI()
        {
            ShowMenuUI(PlayerStats.Instance.AmmoCount.ToString());
            yield return new WaitForSeconds(showDelay);
            HideMenuUI();
        }
    }
}