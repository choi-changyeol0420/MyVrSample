using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Myfps
{
    //파일에 저장할 게임 플레이 데이터 목록
    [System.Serializable]
    public class PlayData
    {
        public int sceneNumber;
        public int ammoCount;
        public bool hasGun;

        //..health

        //생성자 - PlayerStats에 있는 데이터로 초기화
        public PlayData()
        {
            sceneNumber = PlayerState.Instance.SceneNumber;
            ammoCount = PlayerState.Instance.AmmoCount;
            hasGun = PlayerState.Instance.HasGun;
        }
    }
}