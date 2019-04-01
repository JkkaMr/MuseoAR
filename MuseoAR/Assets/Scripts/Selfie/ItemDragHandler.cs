﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler {

  private RectTransform rectTransform;
  private RectTransform itemPanel;
  private RectTransform canvas;
  private RectTransform itemSlot;
  private DecorationListItem item;

  //private bool isOnCanvas = false;

  public void OnDrag(PointerEventData eventData)
  {
    transform.position = Input.mousePosition;
  }

  public void OnEndDrag(PointerEventData eventData)
  {
    // Check if the current mouse coordinates are inside the panel
    if (RectTransformUtility.RectangleContainsScreenPoint(itemPanel, Input.mousePosition))
    {
     transform.SetParent(itemSlot);
      rectTransform.anchoredPosition = Vector2.zero;
    }
    else
    {
      transform.SetParent(canvas);
    }
  }

  // Use this for initialization
  void Start() {
    rectTransform = gameObject.GetComponent<RectTransform>();
    itemSlot = transform.parent as RectTransform;
    itemPanel = GameObject.FindWithTag("Inventory").transform as RectTransform;
    canvas = GameObject.FindGameObjectWithTag("Canvas").transform as RectTransform;
    item = gameObject.GetComponent<DecorationListItem>();
  }
}