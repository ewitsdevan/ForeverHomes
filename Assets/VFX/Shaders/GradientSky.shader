Shader "Custom/GradientSky"
{
    Properties
    {
        _TopColor ("Top Color", Color) = (0.5, 0.7, 1, 1)
        _MiddleColor ("Middle Color", Color) = (0.6, 0.8, 1, 1)
        _BottomColor ("Bottom Color", Color) = (0.9, 0.8, 0.6, 1)
        _SunColor ("Sun Color", Color) = (1, 1, 0, 1)
        _SunPosition ("Sun Position", Vector) = (0, 1, 0, 1)
        _Blend ("Blend", Range(0, 1)) = 0.5
        _Height ("Height", Range(0, 1)) = 0.5
    }
    SubShader
    {
        Tags { "RenderType"="Skybox" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata_t
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 pos : SV_POSITION;
                float3 worldPos : TEXCOORD0;
            };

            uniform float4 _TopColor;
            uniform float4 _MiddleColor;
            uniform float4 _BottomColor;
            uniform float4 _SunColor;
            uniform float4 _SunPosition;
            uniform float _Blend;
            uniform float _Height;

            v2f vert(appdata_t v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.worldPos = mul(unity_ObjectToWorld, v.vertex).xyz;
                return o;
            }

            half4 frag(v2f i) : SV_Target
            {
                float y = i.pos.y / i.pos.w;
                float blend = (_Blend + y) * 0.5;

                float skyHeight = (y + 1.0) * _Height;
                float3 skyColor = lerp(_BottomColor.rgb, _MiddleColor.rgb, skyHeight);

                float sunIntensity = max(0.0, dot(normalize(i.worldPos), normalize(_SunPosition.xyz)));
                float3 sunEffect = _SunColor.rgb * sunIntensity * 0.5;

                skyColor = lerp(skyColor, _TopColor.rgb, blend);
                skyColor += sunEffect;

                return half4(skyColor, 1.0);
            }
            ENDCG
        }
    }
}
