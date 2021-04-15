
using UnityEngine;
using UnityEngine.UI; // 引用 介面 API
public class Player : MonoBehaviour
{
    [Header("等級")]
    public int lv = 1;
    [Header("移動速度"),Range(0,300)]
    public float speed = 0.5f;
    [Header("角色是否死亡")]
    public bool isDead = false;
    [Header("角色名稱"),Tooltip("這是角色的名稱")]
    public string cName = "貓咪";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;
    [Header("變形元件")]
    public Transform tra;
    [Header("動畫元件")]
    public Animator ani;
    [Header("偵測範圍")]
    public float rangeAttack = 1.2f;
    [Header("音效來源")]
    public AudioSource aud;
    [Header("攻擊音效")]
    public AudioClip soundAttack;

    //事件:繪製圖示
    private void OnDrawGizmos()
    {
        //指定圖示顏色(紅，綠，藍，透明度)
        Gizmos.color = new Color(1, 0, 0, 0.2f);
        //繪製圖示 球體(中心點，半徑)
        Gizmos.DrawSphere(transform.position, rangeAttack);
    }

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {

        float h = joystick.Horizontal;
        float v = joystick.Vertical;

        //變形元件.位移
        tra.Translate( h * speed * Time.deltaTime , v * speed * Time.deltaTime ,0);

        ani.SetFloat("水平", h);
        ani.SetFloat("垂直", v);

    }

    //要被按鈕呼叫必須設定為公開 public
    public void Attack()
    {
        //音效來源,播放一次(音效片段，音量)
        aud.PlayOneShot(soundAttack, 0.5f);

        //2D物理 圓形碰撞(中心點，半徑，方向，距離，圖層編號(1<<X))
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, rangeAttack, -transform.up, 0, 1 << 8);

        //如果 碰到物件存在 並且 碰到的物件 標籤 為 道具 就 取得道具腳本並呼叫掉落道具方法
        if (hit && hit.collider.tag == "道具") hit.collider.GetComponent<Item>().DropProp();



    }

    private void Hit()
    {
        
    }

    private void Dead()
    {

    }

    private void Start()
    {
        Move();
    }
    private void Update()
    {
        Move();
    }

    [Header("吃金塊音效")]
    public AudioClip souondEat;
    [Header("金幣數量")]
    public Text textCoin;



    private int coin;


    //觸發事件 - 進入 : 兩個物件必須有一個勾選 Is Trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "金塊")
        {
            coin++;
            aud.PlayOneShot(souondEat);
            Destroy(collision.gameObject);
            textCoin.text = "金幣 :" + coin;
        }
    }


}
