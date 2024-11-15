using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.AI;

namespace Myfps
{
    public enum RobotState
    {
        E_Idle,     //대기
        E_Walk,     //걷기    - 적을 타겟팅하지 못한 경우
        E_Attack,   //스매시 공격
        E_Death,    //죽기
        E_Chase     //추격(걷기) - 적을 타겟팅한 경우
    }

    public class Enemy : MonoBehaviour, IDamageable
    {
        #region VAriables
        private Transform theplayer;
        private Animator animator;
        private NavMeshAgent agent;

        //로봇 현재 상태
        private RobotState currentState;
        //로봇 이전 상태
        private RobotState beforeState;

        //체력
        [SerializeField] private float maxhealth = 20;
        private float currenthealth;
        private bool isDeath;

        //공격
        [SerializeField] private float AttackRange = 1.5f;
        [SerializeField] private float AttackDamage = 5f;

        //적 감지
        private bool isAiming = false;
        public bool IsAiming
        {
            get { return isAiming; }
            private set 
            {
                isAiming = value; 

            }
        }
        [SerializeField] private float Range = 20f;
        //패트롤
        public Transform[] wayPoints;
        private int nowWayPoint = 0;

        private Vector3 startpoistion;  //시작위치, 타겟을 읿었을 때 돌아오는 지점
        #endregion

        private void Start()
        {
            //참조
            theplayer = GameObject.Find("Player").transform;
            animator = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();

            //초기화
            currenthealth = maxhealth;
            startpoistion = transform.position;

            if(wayPoints.Length > 0)
            {
                SetState(RobotState.E_Walk);
                GoNextPoint();
            }
            else
            {
                SetState(RobotState.E_Idle);
            }
        }
        private void Update()
        {
            if (isDeath) return;
            float distance = Vector3.Distance(theplayer.transform.position, transform.position);
            if(Range > 0)
            {
                IsAiming = distance <= Range;
            }
            if (distance <= AttackRange)
            {
                SetState(RobotState.E_Attack);
                agent.SetDestination(this.transform.position);
            }
            else if (Range > 0)
            {
                if(IsAiming)
                {
                    SetState(RobotState.E_Chase);
                }
            }
            switch (currentState)
            {
                case RobotState.E_Idle:
                    break;

                case RobotState.E_Walk:
                    //도착판정
                    if(agent.remainingDistance <= 0.2f)
                    {
                        if (wayPoints.Length > 0)
                        {
                            GoNextPoint();
                        }
                        else
                        {
                            SetState(RobotState.E_Idle);
                        }
                    }
                    break;

                case RobotState.E_Attack:
                    if (distance > AttackRange)
                    {
                        SetState(RobotState.E_Chase);
                    }
                    break;

                case RobotState.E_Chase:
                    if(Range > 0 && !IsAiming)
                    {
                        GoStartPosition();
                        return;
                    }
                    //플레이어 위치 업데이트
                    agent.SetDestination(theplayer.position);
                    break;
            }
        }
        public void SetState(RobotState robotstate)
        {
            if(isDeath) return;
            //현재 상태 체크
            if (currentState == robotstate)
                return;
            //이전 상태 저장
            beforeState = currentState;
            //상태 변경
            currentState = robotstate;
            //상태 변경에 따른 구현 내용
            if(currentState == RobotState.E_Chase)
            {
                animator.SetInteger("EnemyState", 1);      //애니메이션 걷기 동작
                animator.SetLayerWeight(1, 1f);
            }
            else
            {
                animator.SetInteger("EnemyState", (int)robotstate);
                animator.SetLayerWeight(1, 0f);
            }
            //agent초기화
            agent.ResetPath();
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
        void Die()
        {
            SetState(RobotState.E_Death);
            isDeath = true;
            Debug.Log("Robot Death!!");
            transform.GetComponent<BoxCollider>().enabled = false;
            Destroy(gameObject, 3f);
        }
        void Attack()
        {
            float distance = Vector3.Distance(theplayer.transform.position, transform.position);
            IDamageable damageable = theplayer.GetComponent<IDamageable>();
            if (distance > AttackRange)
            {
                return;
            }
            else if (distance <= AttackRange)
            {
                if (damageable != null)
                {
                    damageable.TakeDamage(AttackDamage);
                }
            }
        }
        private void GoNextPoint()
        {
            nowWayPoint++;
            if(nowWayPoint >= wayPoints.Length)
            {
                nowWayPoint = 0;
            }
            agent.SetDestination(wayPoints[nowWayPoint].position);
        }
        public void GoStartPosition()
        {
            if(isDeath) return;
            SetState(RobotState.E_Walk);
            nowWayPoint = 0;
            agent.SetDestination(startpoistion);
        }
        void OnDrawGizmosSelected()
        { 
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, Range);
        }
    }
}