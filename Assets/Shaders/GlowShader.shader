Shader "Glow/GlowShader"
{
    SubShader
    {
        ZWrite Off
        ZTest Always
        Lighting Off
        Pass
        {
            CGPROGRAM
            #pragma vertex VShader
            #pragma fragment FShader
            struct VertexToFragment
            {
                float4 pos:SV_POSITION;
            };
            //correct position
            VertexToFragment VShader(VertexToFragment i)
            {
                VertexToFragment o;
                o.pos=mul(UNITY_Matrix_MVP,i.pos);
                return o;
            }
            //return white
            half4 FShader():COLOR0
            {
                return half4(1,1,1,1);
            }
            ENDCG
        }
}
