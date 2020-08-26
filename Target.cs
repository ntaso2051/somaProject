using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public int color;
    public int attackedPlayerId;
    public GameObject attackedPlayer;
    void getAttackedPlayerId()
    {
        // なんらかの方法で攻撃されたプレイヤーのIDを取得
        // attackedPlayerId = attackedPlayer.GetComponent<sPlayer>().id;
    }

    void attacked()
    {
        // 消滅アニメーション
        // Destroy(gameObject);
        // or
        // this.SetActive(false);
    }
}
