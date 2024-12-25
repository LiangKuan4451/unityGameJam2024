using Characters;
using UnityEngine;

public class MapBox : MonoBehaviour
{
    public ICharacter Character;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMouseUp()
    {
        // Character.Move(gameObject.transform);
    }
    private void OnMouseOver()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
    }

    private void OnMouseExit()
    {
        gameObject.GetComponent<SpriteRenderer>().color = new Color(135f / 255f, 173f / 255f, 114f / 255f, 1f);;

    }
}
