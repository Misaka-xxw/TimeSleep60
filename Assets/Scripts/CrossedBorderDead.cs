using UnityEngine;

public class CrossedBorderDead : ScriptParent
{
    public float border = 17f;
    private Transform _transform;

    void Start()
    {
        _transform = GetComponent<Transform>();
    }
    void Update()
    {
        if (ShouldDie())
        {
            Destroy(this.gameObject);
        }
    }

    private bool ShouldDie()
    {
        var x = _transform.position.x;
        var y = _transform.position.y;
        return x < -border || x > border || y < -border || y > border;

    }
}
