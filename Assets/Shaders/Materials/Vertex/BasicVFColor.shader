Shader "Unlit/BasicVFColor"
{

    SubShader
    {
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
            };

            struct v2f
            {
                float4 color : COLOR;
                float4 vertex : SV_POSITION;
            };

            v2f vert (appdata v) //Worldspace
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
				//o.color.r = (v.vertex.x); //World x coordinate origin (center)
				//o.color.g = (v.vertex.z +2)/10;
                return o;
			}

            fixed4 frag (v2f i) : SV_Target //screenspace
            {
                // sample the texture
				fixed4 col;
				col.r = i.vertex.x/1000;
				col.g = i.vertex.y/1000; //No Z axis because its screenspace

                return col;
            }
            ENDCG
        }
    }
}
