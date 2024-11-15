using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class Breakable : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject real;     //깨진 오브젝트
        public GameObject Fake;     //온전한 오브젝트
        public GameObject effect;   //깨진 오브젝트를 멀리 나가게 하는 오브젝트
        private bool isBreak = false;

        [SerializeField]private bool Unbeakable = false;
        public GameObject key;
        #endregion
        public void TakeDamage(float damage)
        {
            // 깨진 여부 체크
            if (Unbeakable)
                return;

            //1 shot 1 kill
            if (!isBreak)
            { 
                StartCoroutine(BreakObject()); 
            }
        }

        IEnumerator BreakObject()
        {
            isBreak = true;
            this.GetComponent<BoxCollider>().enabled = false;
            Fake.SetActive(false);
            yield return new WaitForSeconds(0.1f);
            AudioManager.Instance.Play("PotterySmash");
            real.SetActive(true);

            if (effect != null)
            {
                effect.SetActive(true);
                yield return new WaitForSeconds(0.05f);
                effect.SetActive(false);
            }

            if(key != null)
            {
                yield return new WaitForSeconds(0.15f);
                key.SetActive(true);
            }
        }
    }
}