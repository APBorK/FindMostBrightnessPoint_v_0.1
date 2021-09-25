using UnityEngine;

public static class BrightnessPointSearcher
{
    private const float RedIndex = 0.2126f;
    private const float GreenIndex = 0.7152f;
    private const float BlueIndex = 0.0722f;

    public static Vector2 SearchMostBrightnessPoint(Texture2D imageToSearchPoint)
    {
        var brightnessPoint = Vector2.zero;
        var maximalBrightness = float.MinValue;
        
        for (var x = 0; x < imageToSearchPoint.height; x++)
        {
            for (var y = 0; y < imageToSearchPoint.width; y++)
            {
                var pixelColor = imageToSearchPoint.GetPixel(x, y);
                var pixelBrightness = RedIndex * pixelColor.r + GreenIndex * pixelColor.g +
                                      BlueIndex * pixelColor.b;
                
                if (maximalBrightness < pixelBrightness)
                {
                    maximalBrightness = pixelBrightness;
                    brightnessPoint = new Vector2(x, y);
                }
            }
        }
        
        return brightnessPoint;
    }
}
