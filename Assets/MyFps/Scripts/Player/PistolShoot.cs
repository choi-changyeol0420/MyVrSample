using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    public class PistolShoot : MonoBehaviour
    {
        #region Variables
        private Animator animator;
        public ParticleSystem muzzle;
        public AudioSource pistolshot;

        //public Transform pistolcamera;
        public Transform firePoint;

        //연사 딜레이
        private float fireDelay = 0.5f;
        private bool isFire =false;

        //pistol 공격력
        [SerializeField]private float pistoldamage = 5;

        //임펙트 효과
        public GameObject ImpactPrefab;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //참조
            animator = this.GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            /*if(Input.GetButtonDown("Fire") && !isFire)
            {
                if(PlayerState.Instance.UseAmmo(1) == true)
                {
                    StartCoroutine(Shoot());
                }
            }*/
        }
        IEnumerator Shoot()
        {
            isFire = true;
            //내 앞에 100안에 적이 있으면 적에게 데미지를 준다
            float maxDistance = 100f;
            RaycastHit hit;
            if(Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance))
            {

                //임펙트 효과
                GameObject effectGo = Instantiate(ImpactPrefab, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(effectGo, 2f);
                //적에게 데미지를 준다
                //Debug.Log($"{hit.transform.name}에게 데미지를 준다");
                IDamageable damageable = hit.transform.GetComponent<IDamageable>();
                if(damageable != null)
                {
                    damageable.TakeDamage(pistoldamage);

                }
            }
            //슛 효과 - VFS, SFX
            muzzle.gameObject.SetActive(true);
            muzzle.Play();
            animator.SetTrigger("Fire");

            pistolshot.Play();

            yield return new WaitForSeconds(fireDelay);
            muzzle.Stop();
            muzzle.gameObject.SetActive(false);

            isFire = false;
        }
        //gizmo 총
        private void OnDrawGizmosSelected()
        {
            float maxDistance = 100f;
            RaycastHit hit;
            bool isHit = Physics.Raycast(firePoint.position, firePoint.TransformDirection(Vector3.forward), out hit, maxDistance);
            Gizmos.color = Color.red;
            if (isHit)
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * hit.distance);
            }
            else
            {
                Gizmos.DrawRay(firePoint.position, firePoint.forward * maxDistance);
            }

        }
    }
}