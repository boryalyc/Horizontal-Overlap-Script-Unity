using UnityEngine;

[ExecuteAlways]
public class PreventOverlap : MonoBehaviour
{
    public enum StickDirection { Left, Right }
    public StickDirection stickTo;
    [Space]
    public RectTransform blockLeft;
    public RectTransform blockRight;

    float blockLeftWidth;
    float blockRightWidth;

    RectTransform rect;
    RectTransform parent;

    void Update(){
        AlignToFit();
    }
    void OnEnable(){
        rect = GetComponent<RectTransform>();
        parent = transform.parent.GetComponent<RectTransform>();
    }
    
    public void AlignToFit(){

        if (blockLeft != null) { blockLeftWidth = blockLeft.sizeDelta.x * blockLeft.localScale.x; }
        if (blockRight != null) { blockRightWidth = blockRight.sizeDelta.x * blockRight.localScale.x; }

        float thisWidth = rect.sizeDelta.x * rect.localScale.x;

        switch (stickTo)
        {
            case StickDirection.Left:
                if (blockLeft == null) { 
                    rect.anchoredPosition = new Vector2((rect.sizeDelta.x * rect.localScale.x) / 2, rect.anchoredPosition.y); 
                }
                if (blockLeft != null) {
                    float centerGap = (blockLeftWidth + thisWidth) / 2;

                    float newX = blockLeft.anchoredPosition.x + centerGap;

                    rect.anchoredPosition = new Vector2(newX, rect.anchoredPosition.y);
                }
                if (blockRight != null) {
                    float centerGap = (blockRightWidth + thisWidth) / 2;

                    float newX = rect.anchoredPosition.x + centerGap;

                    blockRight.anchoredPosition = new Vector2(newX, blockRight.anchoredPosition.y);
                }
                break;
            case StickDirection.Right:
                if (blockRight == null) { 
                    rect.anchoredPosition = new Vector2((parent.sizeDelta.x * parent.localScale.x - ((rect.localScale.x * rect.sizeDelta.x) / 2)), rect.anchoredPosition.y); 
                }
                if (blockLeft != null) {
                    float centerGap = (blockLeftWidth + thisWidth) / 2;
                    
                    float newX = rect.anchoredPosition.x - centerGap;

                    blockLeft.anchoredPosition = new Vector2(newX, blockLeft.anchoredPosition.y);
                }
                if (blockRight != null) {
                    float centerGap = (blockRightWidth + thisWidth) / 2;
                    
                    float newX = blockRight.anchoredPosition.x - centerGap;

                    rect.anchoredPosition = new Vector2(newX, rect.anchoredPosition.y);
                }
                break;
        }
    }
}
