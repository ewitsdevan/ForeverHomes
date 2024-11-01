Shader "Unlit/StarryNightSky"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (0.0, 0.0, 0.4, 1.0)
        _MiddleColor ("Middle Color", Color) = (0.0, 0.0, 0.6, 1.0)
        _BottomColor ("Bottom Color", Color) = (0.0, 0.0, 0.0, 1.0)
        _StarIntensity ("Star Intensity", Range(0, 1)) = 0.8
        _StarDensity ("Star Density", Range(0, 1)) = 0.15
        _StarSize ("Star Size", Range(0.01, 0.1)) = 0.02
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float4 _TopColor;
            float4 _MiddleColor;
            float4 _BottomColor;
            float _StarIntensity;
            float _StarDensity;
            float _StarSize;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                float gradientFactor = i.uv.y;
                fixed4 color;

                if (gradientFactor > 0.5)
                {
                    float blend = (gradientFactor - 0.5) * 2.0;
                    color = lerp(_MiddleColor, _TopColor, blend);
                }
                else
                {
                    float blend = gradientFactor * 2.0;
                    color = lerp(_BottomColor, _MiddleColor, blend);
                }

                float2 starPos = i.uv * float2(50.0, 50.0);
                float starValue = frac(sin(dot(starPos, float2(12.9898, 78.233))) * 43758.5453);

                float star = smoothstep(_StarDensity, _StarDensity + _StarSize, starValue) *
                             smoothstep(_StarDensity + _StarSize, _StarDensity, starValue);

                color += star * _StarIntensity;

                return color;
            }
            ENDCG
        }
    }
}

