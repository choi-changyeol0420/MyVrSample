using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class GEnemyZoneTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;

        public GameObject enemyZoneOut;     //out Trigger
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            //건맨이 추격시작
            if(other.tag == "Player")
            {
                if (gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().SetState(RobotState.E_Chase);
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                //gunMan 제자리로 가라
                enemyZoneOut.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}