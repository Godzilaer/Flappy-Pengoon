using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxManager : MonoBehaviour
{
    public float parallaxSpeed;

    [SerializeField] private Transform parallaxSet;
    private Transform currentParallaxSet;

    private void Start()
    {
        currentParallaxSet = transform.Find(gameObject.name + "Set");
    }

    private void Update()
    {
        if(!GameManager.Instance.gameStarted)
        {
            return;
        }

        if(currentParallaxSet.position.x <= -17.74f)
        {
            currentParallaxSet = Instantiate(parallaxSet, transform);
        }
    }
}
