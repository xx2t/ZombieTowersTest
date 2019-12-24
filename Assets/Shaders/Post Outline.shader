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
    Blend SrcAlpha OneMinusSrcAlpha
        Pass
        {
            CGPROGRAM
            sampler2D _MainTex;
            //<SamplerName>_TexelSize is a float2 that says how much screen space a texel occupies.
            float2 _MainTex_TexelSize;
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
                int NumberOfIterations=9;
                float TX_x=_MainTex_TexelSize.x;
                float TX_y=_MainTex_TexelSize.y;
                //intensity that increments based on surrounding intensities
                float ColorIntensityInRadius;
                if(tex2D(_MainTex,i.uvs.xy).r>0)
                {
                    discard;
                }
                //for horizontal iterations
                for(int k=0;k<NumberOfIterations;k+=1)
                {
                    //for every verticle iteration
                    for(int j=0;j<NumberOfIterations;j+=1)
                    {
                        //increase our output color by the pixels in the area
                        ColorIntensityInRadius+=tex2D(
                            _MainTex,i.uvs.xy+float2
                            (
                                (k-NumberOfIterations/2)*TX_x,
                                (j-NumberOfIterations/2)*TX_y
                            )
                        ).r;
                    }
                }
                //output some intensity of teal
                return ColorIntensityInRadius*half4(0,1,1,1);
            }
            ENDCG
        }
    }
}
