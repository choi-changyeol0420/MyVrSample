using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class HEnemyZoneOutTrigger : MonoBehaviour
    {
        #region Variables
        public Transform gunMan;
        public GameObject enemyZoneIn;
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            //건맨 제자리로
            if(other.tag == "Player")
            {
                if(gunMan != null)
                {
                    gunMan.GetComponent<Enemy>().GoStartPosition();
                }
            }
        }
        private void OnTriggerExit(Collider other)
        {
            //In Trigger 활성화
            if (other.tag == "Player")
            {
                enemyZoneIn.SetActive(true);
                gameObject.SetActive(false);
            }
        }
    }
}