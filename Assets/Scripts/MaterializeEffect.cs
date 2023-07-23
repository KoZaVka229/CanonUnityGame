using UnityEngine;

public class Materialize : MonoBehaviour
{
    public Material material1;
    public Material material2;
    public float duration = 2.0f;
    SpriteRenderer rend;

    void Start()  { 
        rend = GetComponent<SpriteRenderer> ();
    }

    void Update()
    {
        float lerp = Mathf.PingPong(Time.time, duration) / duration;
        rend.material.Lerp(material1, material2, lerp);
    }
}
