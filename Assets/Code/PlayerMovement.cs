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
        public float moveSpeed = 70f;

        void Start()
        {
           /*
            PlayerMovement playerMovement = this;
            playerMovement.gameObject.transform.position = new Vector2(-10, 150);
            */

        }
        // playerの位置を特定
        private Vector2 positon;

        void Update()
        {
            float x = Input.GetAxis("Horizontal") * moveSpeed;
            float y = Input.GetAxis("Vertical") * moveSpeed;
            //初期位置(0,0)からずれる方向、距離(⇓,⇑,前後)
            // transform.localPosition(moveH, -moveV);

            // 移動する向きを求める
            // x と y の入力値を正規化して direction に渡す
            Vector2 direction = new Vector2(x, y).normalized;

            //上で入力した上限、下限値を設定 ⇒⇒⇒ 可動範囲域を設定できる
            Clamp();

            //現在の座標を取得
            //            Vector3 pos = this.gameObject.transform.position;



            if (Input.GetKey(KeyCode.LeftArrow))
            {
                this.gameObject.transform.position = new Vector2(positon.x - V, positon.y);
            }
            else if (Input.GetKey(KeyCode.RightArrow))
            {
                this.gameObject.transform.position = new Vector2(positon.x + V, positon.y);
            }
            else
            {
            }
        }

        // プレーヤーの移動できる範囲を制限する命令ブロック
        void Clamp()
        {
            // 自機の移動座標最小値をビューポートから取得（最小値は0,0）
            Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(.0f, .0f));
            // 自機の移動座標最大値ををビューポートから取得（最大値は1,1）
            Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(.9f, .9f));
            // 自機の座標を取得してベクトル pos に格納
            Vector2 pos = transform.position;
            // pos.x の値を最小値 min 最大値 max の範囲に制限する
            pos.x = Mathf.Clamp(pos.x, min.x, max.x);
            // pos.y の値を最小値 min 最大値 max の範囲に制限する
            pos.y = Mathf.Clamp(pos.y, min.y, max.y);
            // 自機の移動範囲を pos の最小値と最大値の範囲に制限する
            transform.position = pos;
        }
    }
}