using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoloMaster : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject targetPrefab;
    List<sPlayer> players = new List<sPlayer>();
    List<Target> targets = new List<Target>();
    public int tPlayerNum = 3; //とりあえずテキトーな数字
    public int tTargetNum = 10; //とりあえずテキトーな数字
    int tmpTargetNum = 10;
    const int TARGET_NUM_MIN = 3;
    Vector3 initPos = new Vector3(0f, 0f, 0f); //とりあえずテキトーな数字
    public float timeLimit = 60; //とりあえず1分
    const int RED_POINTS = 700;
    const int BLUE_POINTS = 200;


    // ## playerのプロパティ
    // ここでは、プレイヤーとNPCを区別していない。
    // - id (start時に割り振る)
    // - score
    // - init()

    // ## targetのプロパティ
    // - attackedPlayerId (攻撃されたプレイヤーを取得)
    // - color (0: blue, 1: red)
    // - getAttackedPlayerId() (attackedPlayerIdを取得)
    // - Attacked() (自身消滅)

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < tPlayerNum; i++)
        {
            GameObject tmpPlayer = Instantiate(playerPrefab, initPos, Quaternion.identity);
            players.Add(tmpPlayer.GetComponent<sPlayer>());
        }
        for (int i = 0; i < tPlayerNum; i++)
        {
            GameObject tmpTarget = Instantiate(targetPrefab, initPos, Quaternion.identity);
            targets.Add(tmpTarget.GetComponent<Target>());
        }
    }

    // Update is called once per frame
    void Update()
    {

        timeLimit -= Time.deltaTime;
        if (timeLimit < 0)
        {
            //シーン遷移のアニメーションとかを挿入
            SceneManager.LoadScene("Results"); //テキトーなシーン名を入力
        }

        for (int i = 0; i < tmpTargetNum; i++) // すべての的を監視
        {
            if (targets[i].attackedPlayerId != -1) // 的が打たれたら
            {
                tmpTargetNum--;
                int tmpId = targets[i].attackedPlayerId;
                for (int j = 0; j < tPlayerNum; j++) // 的を当てたプレイヤーを識別
                {
                    if (tmpId == players[j].id) // スコアの更新
                    {
                        if (targets[i].color == 0)
                        {
                            players[j].score += BLUE_POINTS;
                        }
                        else if (targets[i].color == 1)
                        {
                            players[j].score += RED_POINTS;
                        }

                    }
                }
                targets[i].attackedPlayerId = -1;
            }
        }

        if (tmpTargetNum < TARGET_NUM_MIN) // 的が一定数以下になったら
        {
            GameObject tmpTarget = Instantiate(targetPrefab, initPos, Quaternion.identity);
            targets.Add(tmpTarget.GetComponent<Target>());
        }

    }
}
