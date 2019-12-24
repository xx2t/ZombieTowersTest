// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Glow/Post Outline"
{
    Properties
    {
        //Graphics.Blit() sets the "_MainTex" property to the texture passed in
        _MainTex("MainTexture",2D)="black"{}
    }
    SubShader
    {
        Pass
        {
            CGPROGRAM
            sampler2D _MainTex;
            #pragma vertex vert
            #pragma fragment frag
            #include "UnityCG.cginc"
            struct v2f
            {
                float4 pos : SV_POSITION;
                float2 uvs : TEXCOORD0;
            };
            v2f vert (appdata_base v)
            {
                v2f o;
                o.pos = UnityObjectToClipPos(v.vertex);
                o.uvs = o.pos.xy / 2 + 0.5;
                return o;
            }
            half4 frag(v2f i) : COLOR
            {
                return tex2D(_MainTex,i.uvs.xy);
            }
            ENDCG
        }
    }
}
