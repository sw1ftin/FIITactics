// using System;
// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.SceneManagement;
// using UnityEngine.UI;
// using UnityEngine.EventSystems;
//
// public class CardDisplay : MonoBehaviour
// {
//     public Sprite sacrifice;
//     public Sprite money;
//     
//     public Card2 card;
//     public Text nameText;
//     public Text costText;
//     public Text damageText;
//     public Text healthText;
//     public Image typeImage;
//     public Image iconImage;
//
//     void Start()
//     {
//         nameText.text = card.name;
//         costText.text = card.cost.ToString();
//         damageText.text = card.power.ToString();
//         healthText.text = card.healthPoints.ToString();
//         typeImage.sprite = card.type == CostType.Sacrifice ? sacrifice : money;
//         iconImage.sprite = Resources.Load<Sprite>(card.iconPath);
//         
//     }
// }