using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    // ゲーム実行中の繰り返し処理
    void Update()
    {
        // 右・左のデジタル入力値を x に渡す
        float x = Input.GetAxisRaw("Horizontal");
        // 上・下のデジタル入力値 y に渡す
        float y = Input.GetAxisRaw("Vertical");
        // 移動する向きを求める
        // x と y の入力値を正規化して direction に渡す
        Vector2 direction = new Vector2(x, y).normalized;

        // 自機の移動制限処理を実行
        Clamp();
    }

    // 自機の移動制限処理
    void Clamp()
    {
        // 自機の移動座標最小値をビューポートから取得（最小値は0,0）
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(-0.1f, 0.1f));
        // 自機の移動座標最大値ををビューポートから取得（最大値は1,1）
        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(0.98f, 0f));
        // 自機の座標を取得してベクトル pos に格納
        Vector2 pos = transform.position;
        // pos.x の値を最小値 min 最大値 max の範囲に制限する
        pos.x = Mathf.Clamp(pos.x, min.x, max.x);
        // pos.y の値を最小値 min 最大値 max の範囲に制限する
        pos.y = Mathf.Clamp(pos.y, min.y, max.y);
        // 自機の移動範囲を pos の最小値と最大値の範囲に制限する
        transform.position = pos;
    }

    /*

    // トリガーに入った時の処理
    // 衝突した相手の Collider2D コンポーネントを引数 c に格納
    void OnTriggerEnter2D(Collider2D c)
    {
        // レイヤー名を取得して layerName に格納
        string layerName = LayerMask.LayerToName(c.gameObject.layer);
        // レイヤー名が Bullet (Enemy) の場合
        if (layerName == "Bullet (Enemy)")
        {
            // 弾の削除
            Destroy(c.gameObject);
        }
        // レイヤー名が Bullet (Enemy) または Enemy の場合
        if (layerName == "Bullet (Enemy)" || layerName == "Enemy")
        {
            /*
            // 爆発処理
            // スクリプト Spaceship の関数 Explosion() を実行
            spaceship.Explosion();
            // プレイヤーを削除
            Destroy(gameObject);
            //
        }
    }
    */

}