using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Assets.code
{
    public class PlayerMovement : MonoBehaviour
    {
        /*
        Playerの操作系
        const V：一回当たりの移動量を設定
        moveSpeed：移動速度の設定…速すぎると判定抜けの可能性あり
         */
        private const float V = 5f;
        public float moveSpeed = 5.5f;

        void Start()
        {
            PlayerMovement playerMovement = this;
            playerMovement.gameObject.transform.position = new Vector2(-10, 150);
        }
        // playerの位置を特定
        private Vector2 pos;

        void Update()
        {
            /*
            // Inputの前に「-」を付ける。
            float moveH = -Input.GetAxis("Horizontal") * moveSpeed;
            float moveV = -Input.GetAxis("Vertical") * moveSpeed;
            //初期位置(0,0)からずれる方向、距離(⇓,⇑,前後)
            transform.localPosition(moveH, -moveV);

            */
            //上で入力した上限、下限値を設定 ⇒⇒⇒ 可動範囲域を設定できる
            Clamp();

            //現在の座標を取得
            //            Vector3 pos = this.gameObject.transform.position;



            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position = new Vector2(pos.x - V, pos.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.position = new Vector2(pos.x + V, pos.y);
            }
            else
            {
            }
        }

        // プレーヤーの移動できる範囲を制限する命令ブロック
        void Clamp()
        {
            // プレーヤーの位置情報を「pos」という箱の中に入れる。
            pos = transform.position;
            /*
            ≪注意≫現在の視点上での動き（変域の設定）
              x値　+：右側の可動域,-：左側の可動域
              y値　+：上部への可動域,-：下部への可動域
            　z値　+：,　　　　　　　　-：
            */
            pos.x = Mathf.Clamp(pos.x, 200, 500);
            pos.y = Mathf.Clamp(pos.y, 50, 50);
            transform.position = pos;


        }
    }
}