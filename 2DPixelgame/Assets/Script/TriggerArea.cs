using UnityEngine;

public class TriggerArea : MonoBehaviour
{
    [Header("要關閉的障礙物們")]
    public GameObject[] stones;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "石頭")
        {
            stones[0].SetActive(false);
        }
    }
}
