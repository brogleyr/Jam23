Shader "Unlit/HealthBar"
{
    Properties
    {
        _MainTex ( "Main Texture", 2D) = "white" {}
        _ColorA ( "Color A", Color ) = (0,1,0,1)
        _ColorB ( "Color B", Color ) = (1,0,0,1)
        _HighThresh ( "High Threshold", Range(0,1)) = .8
        _LowThresh ( "Low Threshold", Range(0,1)) = .2
        _Health ( "Health", Range(0,1) ) = 1
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }

        Pass
        {
            Blend SrcAlpha OneMinusSrcAlpha

            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            #define TAU 6.28318530718

            sampler2D _MainTex;
            float4 _ColorA;
            float4 _ColorB;
            float _HighThresh;
            float _LowThresh;
            float _Health;

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

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            float InvLerp(float a, float b, float v) {
                return ( v - a ) / ( b - a);
            }

            float4 frag (v2f i) : SV_Target
            {
                
                
                //float invLerpThresh = InvLerp( _LowThresh, _HighThresh, _Health);
                //float4 col = lerp( _ColorB, _ColorA, invLerpThresh);
                //if (_Health > _HighThresh) {
                //    col = _ColorA;
                //}
                
                //clip(_Health - i.uv.x);
                float healthBarMask = _Health > i.uv.x;
                float3 col = tex2D( _MainTex, float2(_Health, i.uv.y));

                col *= healthBarMask;
                if (_Health < _LowThresh) { 
                    float pulse = 1 + (cos( _Time.y * 4) * .15);
                    col *= pulse;
                }
                if (healthBarMask == 0) {
                    return float4(col, 0);
                }
                
                return float4 (col, 1);
            }
            ENDCG
        }
    }
}
