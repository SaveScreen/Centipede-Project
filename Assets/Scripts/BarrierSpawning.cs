using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrierSpawning : MonoBehaviour
{
   private BoxCollider2D area;
   public BarrierScript prefab;
   public int amount;

   void Awake() {
    area = GetComponent<BoxCollider2D>();

   }

   void Start() {
    Generate();
    
   }

   public void Generate() {

    Bounds bounds = area.bounds;

    for (int i = 0; i < amount; i++) {
        Vector2 position = Vector2.zero;

        position.x = Mathf.Round(Random.Range(bounds.min.x, bounds.max.x));
        position.y = Mathf.Round(Random.Range(bounds.min.y, bounds.max.y));

        Instantiate(prefab, position, Quaternion.identity, transform);

    }

   }

}
