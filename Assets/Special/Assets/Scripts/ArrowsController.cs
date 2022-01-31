using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowsController : MonoBehaviour
{
    [SerializeField] 
    private GameObject redArrow;
    [SerializeField]
    private GameObject greenArrow;
    [SerializeField]
    private GameObject blueArrow;
    [SerializeField]
    private GameObject yellowArrow;
    [SerializeField]
    private Transform redArrowSource;
    [SerializeField]
    private Transform greenArrowSource;
    [SerializeField]
    private Transform blueArrowSource;
    [SerializeField]
    private Transform yellowArrowSource;


        
    [SerializeField]
    private float waitTime;
    private float deltaTime;
    private int index = 0;
    int[] orderArrows = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 4, 0, 1, 0, 2, 2, 3, 3, 4, 4, 3, 3, 2, 2, 1, 1, 2, 2, 1, 1, 2, 2, 3, 3, 4, 3, 2, 1, 3, 2, 1, 1 };
    // 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,,0,1,0,4,0,1,0,4,0,1,0,4,0,1,0,4,0,1,0,4,0,1,0,4,0,1,0,4,0,1,0,4,
    // Start is called before the first frame update
    void Start()
    {
        // 33 batidas iniciais do vermelho
        deltaTime = waitTime;
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        deltaTime -= Time.deltaTime;
        
        
        if (deltaTime <= 0.0f)
        {
            switch (orderArrows[index])
            {
                case 1:
                    Instantiate(redArrow, redArrowSource.position, redArrow.transform.rotation);
                    index += 1;
                    if (this.isOutOfBounds())
                    {
                        index = 0;
                    }
                    break;
                case 4:
                    Instantiate(greenArrow, greenArrowSource.position, greenArrow.transform.rotation);
                    index += 1;
                    if (this.isOutOfBounds())
                    {
                        index = 0;
                    }
                    break;
                case 3:
                    Instantiate(blueArrow, blueArrowSource.position, blueArrow.transform.rotation);
                    index += 1;
                    if (this.isOutOfBounds())
                    {
                        index = 0;
                    }
                    break;
                case 2:
                    Instantiate(yellowArrow, yellowArrowSource.position, yellowArrow.transform.rotation);
                    index += 1;
                    if (this.isOutOfBounds())
                    {
                        index = 0;
                    }
                    break;
                default:
                    index += 1;
                    if (this.isOutOfBounds())
                    {
                        index = 0;
                    }
                    break;
            }
            
            deltaTime = waitTime;
        }
    }
    public bool isOutOfBounds()
    {
        return (this.index >= orderArrows.Length);
    }
}
