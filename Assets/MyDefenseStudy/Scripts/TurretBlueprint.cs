using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBlueprint : MonoBehaviour
{
    // 공개 필드는 기본적으로 직렬화됩니다.
    public string playerName;
    public int health;
    public float speed;

    // 비공개 필드도 [SerializeField] 어트리뷰트를 사용하면 직렬화됩니다.
    [SerializeField]
    private int armor;

    // 프로퍼티는 직렬화되지 않습니다. 필요 시 커스텀 에디터를 사용해야 합니다.
    public int Armor
    {
        get { return armor; }
        set { armor = value; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
