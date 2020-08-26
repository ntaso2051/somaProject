using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PvPMaster : MonoBehaviour
{
    public GameObject playerPrefab;
    List<pPlayer> players = new List<pPlayer>();
    const int TEAM_MENBER_NUM = 2;
    const int TOTAL_PLAYER = 4;
    public int teamOneRes = 0;
    public int teamTwoRes = 0;

    Vector3 initPos = new Vector3(0f, 0f, 0f);


    // ## playerのプロパティ
    // - bodyAttackedNum (胴体に弾が当たった回数)
    // - init() (初期位置に戻る)
    // - yourTeam
    // - bool death
    // - bodyAttacked()

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < TOTAL_PLAYER; i++)
        {
            GameObject tmpPlayer = Instantiate(playerPrefab, initPos, Quaternion.identity);
            players.Add(tmpPlayer.GetComponent<pPlayer>());
            players[i].init();
            players[i].yourTeam = i / TEAM_MENBER_NUM + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < TOTAL_PLAYER; i++)
        {
            if (players[i].death)
            {
                if (players[i].yourTeam == 1)
                {
                    teamTwoRes++;
                }
                else
                {
                    teamOneRes++;
                }
            }
        }
        if (teamOneRes == 2)
        {
            SceneManager.LoadScene("Results");
        }
        if (teamTwoRes == 2)
        {
            SceneManager.LoadScene("Results");
        }
    }
}
