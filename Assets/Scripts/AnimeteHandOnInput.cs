using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyVrSample
{
    public class AnimeteHandOnInput : MonoBehaviour
    {
        #region Variables
        private Animator handanimator;

        //인풋 입력값 처리
        public InputActionProperty pinchAnimationAcion;
        public InputActionProperty gripAnimationAcion;
        #endregion
        // Start is called before the first frame update
        void Start()
        {
            //참조
            handanimator = GetComponent<Animator>();
        }

        // Update is called once per frame
        void Update()
        {
            float triggerValue = pinchAnimationAcion.action.ReadValue<float>();
            float gripValue = gripAnimationAcion.action.ReadValue<float>();
            handanimator.SetFloat("Grip", gripValue);
            handanimator.SetFloat("Trigger", triggerValue);
            //Debug.Log($"triggerValue: {triggerValue}");
            //Debug.Log($"gripValue: {gripValue.ToString()}");
        }
    }
}