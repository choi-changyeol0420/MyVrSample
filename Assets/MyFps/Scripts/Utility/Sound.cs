using UnityEngine;

namespace Myfps
{
    //사운드 목록 관리
    [System.Serializable]
    public class Sound
    {
        public string name;         //재생할 사운드 이름

        #region Variables
        public AudioClip clip;      //재생할 음원
        [Range(0f,1f)]
        public float volume;        //재생할 음원의 소리 크기
        [Range(0.1f, 3f)]
        public float pitch;         //재생 속도

        public bool loop;           //반복 재생
        [HideInInspector]
        public AudioSource Source;  //음원을 재생할 오디오소스
        #endregion
    }
}