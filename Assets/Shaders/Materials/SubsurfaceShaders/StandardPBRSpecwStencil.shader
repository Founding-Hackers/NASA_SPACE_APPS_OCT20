Shader "StandardPBRSpec"{
	//Specular PBR Shader 

	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MetallicTex("Metallic (R)", 2D) = "white"{}
		_SpecColor("Specular Color", Color) = (1,1,1,1)
	}
		SubShader{
			Tags{
				"Queue" = "Geometry"
			}

			CGPROGRAM
			#pragma surface surf StandardSpecular //Changed to Standard Specular

			sampler2D _MetallicTex;
			fixed4 _Color;

			struct Input {
				float2 uv_MetallicTex;
			};

			void surf(Input IN, inout SurfaceOutputStandardSpecular o) { //Changed to Standard Specular
				o.Albedo = _Color.rgb;
				o.Smoothness = tex2D(_MetallicTex, IN.uv_MetallicTex).r; //changing based on the red channel
				o.Specular = _SpecColor;									//Color of the specular lighting 
			}
			ENDCG
		}
			Fallback "Diffuse"
}