Shader "Custom/WaveShader" {
    Properties {
        _Color ("Color", Color) = (0.0, 0.5, 1.0, 1.0)
        _Frequency ("Wave Frequency", Float) = 1.0
        _Amplitude ("Wave Amplitude", Float) = 0.1
        _Speed ("Wave Speed", Float) = 1.0
    }
    SubShader {
        Pass {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"

            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;
            };

            float _Frequency;
            float _Amplitude;
            float _Speed;
            float4 _Color;

            v2f vert(appdata v) {
                v2f o;

                // Applicare l'onda lungo l'asse X per deformare l'oggetto in modo ondulato
                float wave = sin(v.vertex.x * _Frequency + _Time.y * _Speed) * _Amplitude;

                // Sposta solo i vertici lungo l'asse Y con la sinusoide
                v.vertex.y += wave;

                // Trasformare il vertice nello spazio di clip per il rendering
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            fixed4 frag(v2f i) : SV_Target {
                return _Color; // Restituisce il colore impostato
            }
            ENDCG
        }
    }
}
