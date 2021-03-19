
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("等級")]
    public int lv = 1;
    [Header("移動速度"),Range(0,300)]
    public float speed = 10.5f;
    [Header("角色是否死亡")]
    public bool isDead = false;
    [Header("角色名稱"),Tooltip("這是角色的名稱")]
    public string cName = "貓咪";
    [Header("虛擬搖桿")]
    public FixedJoystick joystick;

    /// <summary>
    /// 移動
    /// </summary>
    private void Move()
    {
        print("移動");

        float h = joystick.Horizontal;
        print("水平:" + h);

        float v = joystick.Vertical;
        print("垂直:" + v);

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
