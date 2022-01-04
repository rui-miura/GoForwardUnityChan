using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeGenerator : MonoBehaviour
{
    public GameObject CubePrefab;
    private float delta = 0;
    private float span = 1.0f;
    private float genPosX = 12;
    private float offsetY = 0.3f;
    private float spaceY = 6.9f;
    private float offsetX = 0.5f;
    private float spaceX = 0.4f;
    private int MaxBlockNum = 4;
    AudioSource audioData;
    // Start is called before the first frame update
    void Start()
    {
        audioData = GetComponent<AudioSource>();       
    }

    // Update is called once per frame
    void Update()
    {
        this.delta += Time.deltaTime;
        if(this.delta > this.span)
        {
            this.delta = 0;
            int n = Random.Range(1, MaxBlockNum + 1);
            for(int i = 0; i < n; i++)
            {
                GameObject go = Instantiate(CubePrefab);
                go.transform.position = new Vector2(this.genPosX, this.offsetY + i * this.spaceY);
            }
            this.span = this.offsetX + this.spaceX * n;
        }
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "CubePrefab" || other.gameObject.tag == "Ground")
        {
            audioData.Play(1);
        }
    }
}
