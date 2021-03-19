
using UnityEngine;

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

    private void Attack()
    {

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

}
