using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    //로봇 상태
    public enum EnemyState
    {
        E_Idle,
        E_Walk,
        E_Attack,
        E_Death
    }

    //로봇Enemy 관리 클래스
    public class EnemyController : MonoBehaviour, IDamageable
    {
        #region Variables
        public GameObject theplayer;
        private Animator animator;

        //로봇 현재 상태
        private EnemyState enemyState;
        //로봇 이전 상태
        private EnemyState beforeState;

        [SerializeField]private float movespeed = 5f;
        [SerializeField]private float enemyAttack = 5f;
        [SerializeField] private float AttackRange = 1.5f;
        [SerializeField] private float AttackDelay = 2f;
        private float countdown;
        //체력
        [SerializeField]private float maxhealth = 20;
        private float currenthealth;
        private bool isDeath;

        public AudioSource bgm01;  //메인씬 1 배경음
        public AudioSource bgm02;  //적 등장 배경음
        #endregion
        private void Start()
        {   
            //초기화
            currenthealth = maxhealth;
            SetState(EnemyState.E_Idle);
            isDeath = false;
            countdown = AttackDelay;
            //참조
            animator = GetComponent<Animator>();
        }
        private void Update()
        {
            if (isDeath) return;
            Vector3 dir = theplayer.transform.position - transform.position;
            float distance = Vector3.Distance(theplayer.transform.position, transform.position);
            if (distance <= AttackRange)
            {
                SetState(EnemyState.E_Attack);

            }
            else if (distance > AttackRange)
            {
                SetState(EnemyState.E_Walk);
            }
            //로봇 상태 구현
            switch (enemyState)
            {
                case EnemyState.E_Idle:
                    break;
                case EnemyState.E_Walk:     //플레이어를 향해 걷는다(이동)
                    transform.Translate(dir.normalized * movespeed * Time.deltaTime, Space.World);
                    transform.LookAt(theplayer.transform);
                    break;
                case EnemyState.E_Attack:
                    break;
                /*case EnemyState.E_Death:
                    break;*/
            }
        }
        void Die()
        {
            isDeath = true;
            Debug.Log("Enemy Death");
            SetState(EnemyState.E_Death);
            transform.GetComponent<BoxCollider>().enabled = false;
            bgm02.Stop();
            bgm01.Play();
            Destroy(gameObject,10f);
            //gameObject.SetActive(false);
        }
        public void TakeDamage(float damage)
        {
            currenthealth -= damage;
            Debug.Log($"Remain Health: {currenthealth}");
            if (currenthealth <= 0 && !isDeath)
            {
                Die();
            }
        }
        /*void AttackOnTimer()
        {
            if(countdown < 0f)
            {
                //공격
                Attack();
                //타이머 초기화
                countdown = AttackDelay;
            }
            countdown -= Time.deltaTime;
        }*/
        void Attack()
        {
            float distance = Vector3.Distance(theplayer.transform.position, transform.position);
            IDamageable damageable = theplayer.GetComponent<IDamageable>();
            if(distance > AttackRange)
            {
                return;
            }
            else if (distance <= AttackRange)
            {
                if (damageable != null)
                {
                    damageable.TakeDamage(enemyAttack);
                }
            }
        }
        //로봇Enemy 상태 변경
        public void SetState(EnemyState Enemystate)
        {
            //현재 상태 체크
            if (enemyState == Enemystate)
                return;
            //이전 상태 저장
            beforeState = enemyState;
            //상태 변경
            enemyState = Enemystate;
            //상태 변경에 따른 구현 내용
            animator.SetInteger("EnemyState", (int)Enemystate);
        }
    }
}