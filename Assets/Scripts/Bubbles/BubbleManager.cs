using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleManager : MonoBehaviour
{
    //this script controls the bubbles in the scene. It will be responsible for spawning and destroying bubbles
    //it will also be responsible for keeping track of the bubbles in the scene
    [SerializeField] private GameObject _bubblePrefab;
    [SerializeField] private Transform _bubbleSpawnPoint;
    [SerializeField] private List<Bubble> _activeBubbles = new List<Bubble>();
    
    [SerializeField] private GameObject _bubble;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void NewBubble()
    {
        if (_bubble != null) { return;}
        //spawn a new bubble
        GameObject bubble = Instantiate(_bubblePrefab, _bubbleSpawnPoint.position, Quaternion.identity);
        bubble.GetComponent<PhysicsFollower>().isFollowing = true;
        bubble.GetComponent<Bubble>().GenerateBubble();
        _bubble = bubble;
        Debug.Log("bubble instantiated");
    }
    
    public void ReleaseBubble()
    {
        //release the bubble
        if (_bubble == null) { return;}
        _activeBubbles.Add(_bubble.GetComponent<Bubble>());
        _bubble.GetComponent<Bubble>().ReleaseBubble();
        _bubble = null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
