using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    //정면에 있는 충돌체와의 거리 구하기
    public class PlayerCasting : MonoBehaviour
    {
        #region Variables
        public static float distanceFromTarget = Mathf.Infinity;
        [SerializeField]private float totarget;
        //private float playerhealth = 20;
        #endregion
        // Update is called once per frame
        void Update()
        {
            RaycastHit hit;
            if(Physics.Raycast(transform.position,transform.TransformDirection(Vector3.forward), out hit))
            {
                distanceFromTarget = hit.distance;
                totarget = distanceFromTarget;
            }
        }

        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, maxDistance);
            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(transform.position, transform.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(transform.position, transform.transform.forward * maxDistance);
            }
            
        }
    }
}