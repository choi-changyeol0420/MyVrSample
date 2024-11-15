using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class PickupItem : MonoBehaviour
    {
        #region Variables
        private Vector3 Pos;
        [SerializeField]private float movespeed = 5f;       //이동 속도
        [SerializeField]private float Yposi = 5f;           //이동 거리
        [SerializeField]private float rotatespeed = 5f;     //회전 속도
        #endregion
        private void Start()
        {
            Pos = transform.position;
        }
        private void Update()
        {
            float Ypos = Mathf.Sin(Time.time * movespeed)* Yposi;
            transform.position = Pos + Vector3.up * Ypos;


            transform.Rotate(Vector3.up, rotatespeed * Time.deltaTime, Space.World);
        }
        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                //아이템 획득
                if (OnPickup() == true)
                {
                    //킬
                    Destroy(gameObject);
                }
                
            }
        }
        //아이템 획득 성공, 실패 반환
        protected virtual bool OnPickup()
        {
            return true;
        }
    }
}