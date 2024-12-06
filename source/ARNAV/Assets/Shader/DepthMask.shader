Shader "Custom/DepthMask"
{
    SubShader
    {
        Tags { "Queue" = "Geometry-1" }
        Pass
        {
            ZWrite On
            ColorMask 0

        }
    }


}