using UnityEngine;
using UnityEngine.UI;
using TMPro;
//@Author Krystian Sarowski

public class FoodCount : MonoBehaviour
{
    public TextMeshProUGUI m_foodCollectedText;

    private PlayerGrowth m_player;

    // Start is called before the first frame update
    void Start()
    {
        m_foodCollectedText = GetComponent<TextMeshProUGUI>();
        m_player = GameObject.Find("Player").GetComponent<PlayerGrowth>();
    }

    // Update is called once per frame
    void Update()
    {
        m_foodCollectedText.text = "Food Collected: " + m_player.GetFoodCollected().ToString("0");
    }
}
