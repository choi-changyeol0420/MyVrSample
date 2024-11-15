using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class PlayerController : MonoBehaviour, IDamageable
    {
        #region Variables
        private float playerhealth;
        private float maxhealth = 20;
        private bool isDeath = false;

        public SceneFader scene;

        //데미지 효과
        public GameObject damagefalsh;      //데미지 플래쉬 효과
        public AudioSource hurt01;          //데미지 사운드1
        public AudioSource hurt02;          //데미지 사운드2
        public AudioSource hurt03;          //데미지 사운드3

        //무기
        public GameObject realPistol;
        #endregion
        private void Start()
        {
            playerhealth = maxhealth;
            isDeath = false;

            //무기획득
            if(PlayerState.Instance.HasGun)
            {
                realPistol.SetActive(true);
            }
        }
        public void TakeDamage(float damage)
        {
            if (isDeath) return;
            playerhealth -= damage;
            Debug.Log($"player health: {playerhealth}");

            //데미지 효과 vfx,sfx
            StartCoroutine(DamageEffect());

            if (playerhealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        void Die()
        {
            isDeath = true;
            Debug.Log("Game Over");
            scene.FadeTo("GameOver");
        }
        IEnumerator DamageEffect()
        {
            damagefalsh.SetActive(true);
            CinemachineShake.Instance.ShakeCamera(1f, 1f);
            int randNumber = Random.Range(1, 4);
            if (randNumber == 1)
            {
                hurt01.Play();
            }
            else if (randNumber == 2)
            {
                hurt02.Play();
            }
            else
            {
                hurt03.Play();
            }
            yield return new WaitForSeconds(1f);

            damagefalsh.SetActive(false);
        }
    }
}