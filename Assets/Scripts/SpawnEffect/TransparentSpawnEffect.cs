using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TransparentSpawnEffect : MonoBehaviour
{
    [SerializeField] private List<SpriteRenderer> _targetSprites;
    [SerializeField] private List<TextMeshPro> _targetTextMeshes;
    
    [SerializeField] private Rigidbody2D _targetBody;
    [SerializeField] private float _effectDuration;

    private void IncreaseAlphaColorForAllTargets(float alphaStep) {
        foreach (var sprite in _targetSprites) {
            Color color = sprite.color;
            color.a += alphaStep;
            sprite.color = color;
        }

        foreach (var text in _targetTextMeshes) {
            Color color = text.color;
            color.a += alphaStep;
            text.color = color;
        }
    }

    private void SetAlphaColorForAllTargets(float alpha) {
        foreach (var sprite in _targetSprites) {
            Color color = sprite.color;
            color.a = alpha;
            sprite.color = color;
        }

        foreach (var text in _targetTextMeshes) {
            Color color = text.color;
            color.a = alpha;
            text.color = color;
        }
    }

    private void Start() {
        _targetBody.simulated = false;

        SetAlphaColorForAllTargets(0);

        Destroy(this, _effectDuration);
    }

    private void Update() {
        float step = 1 / _effectDuration * Time.deltaTime;

        IncreaseAlphaColorForAllTargets(step);
    }

    private void OnDestroy() {
        _targetBody.simulated = true;    
    }
}
