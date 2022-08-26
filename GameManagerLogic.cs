using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerLogic : MonoBehaviour
{
    public Text jumpcountText;

    public void GetCoin(int count) {
        jumpcountText.text = count.ToString();
    }
}
