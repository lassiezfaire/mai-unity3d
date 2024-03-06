using UnityEngine;

public class AngleToPlayer : MonoBehaviour
{
    private Transform player;
    private Vector3 targetPos;
    private Vector3 targetDir;

    private SpriteRenderer spriteRenderer;
    // public Sprite[] sprites;
    
    private float angle;
    public int lastIndex;

    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        // получаем целевую позицию и направление
        targetPos = new Vector3(player.position.x, transform.position.y, player.position.z);
        targetDir = targetPos - transform.position;

        // получаем угол
        angle = Vector3.SignedAngle(targetDir, transform.forward, Vector3.up);

        // перевернуть спрайт, если нужно
        Vector3 tempScale = Vector3.one;
        if(angle > 0)
        {
            tempScale.x *= -1f;
        }

        spriteRenderer.transform.localScale = tempScale;
        
        lastIndex = GetIndex(angle);

        // spriteRenderer.sprite = sprites[lastIndex];
    }

    int GetIndex(float angle)
    {
        if (angle > -22.5f && angle < 22.5f)
            return 0;
        if (angle >= 22.5f && angle < 67.5f)
            return 7;
        if (angle >= 67.5f && angle < 112.5f)
            return 6;
        if (angle >= 112.5f && angle < 157.5f)
            return 5;

        if (angle <= -157.5f || angle >= 157.5f)
            return 4;
        if (angle >= -157.5f && angle < -122.5f)
            return 3;
        if(angle >= -122.5f && angle < -67.5f)
            return 2;
        if(angle >= -67.5f && angle <= -22.5f)
            return 1;
        return 0;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, targetPos);
    }
}
