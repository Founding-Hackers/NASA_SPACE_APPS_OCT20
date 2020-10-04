Shader "Unlit/TEST3"
{
   
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        Pass
        {
            CGPROGRAM
            #pragma vertex vert_img
            #pragma fragment frag
			#pragma target 3.0

			#include "UnityCG.cginc"

            fixed4 frag (v2f_img i) : COLOR
            {
				/*float2 rg = sp.xy / _ScreenParams.xy;
				fixed blue = 0.0;
				fixed alpha = 1.0f;

                return fixed4(rg, blue, alpha);*/

				return float4(i.uv, 0.0, 1.0);
            }
            ENDCG
        }
    }
}
