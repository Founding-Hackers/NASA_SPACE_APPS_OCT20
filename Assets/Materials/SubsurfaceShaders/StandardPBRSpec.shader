Shader "StandardPBRSpecStencil"{
	//Specular PBR Shader 

	Properties{
		_Color("Color", Color) = (1,1,1,1)
		_MetallicTex("Metallic (R)", 2D) = "white"{}
		_SpecColor("Specular Color", Color) = (1,1,1,1)
		S_Ref("Stencil Ref", Float) = 1
		[Enum(UnityEngine.Rendering.CompareFunction)] _SComp("Stencil Comp", Float) = 8
		[Enum(UnityEngine.Rendering.StencilOp)] _SOp("Stencil Op", Float) = 2

	}

	SubShader
	{
		Tags
		{
			"Queue" = "Geometry"
		}

		Stencil
		{
			Ref[_SRef]
			Comp[_SComp] //compare what is in the stencil buffer and always writes a 1
			Pass[_SOp]
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