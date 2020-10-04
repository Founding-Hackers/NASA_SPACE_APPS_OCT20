Shader "DecalAdded"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
		_DecalTex("Decal", 2D) = "white" {}
		[Toggle] _ShowDecal("ShowDecal?", Float) = 0
	}
	SubShader
	{
		Tags { "Queue" = "Geometry" }

		CGPROGRAM
		#pragma surface surf Lambert

		sampler2D _MainTex;
		sampler2D _DecalTex;
		float _ShowDecal;

		struct Input
		{
			float2 uv_MainTex;
		};

		void surf(Input IN, inout SurfaceOutput o) 
		{
			fixed4 a = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 b = tex2D(_DecalTex, IN.uv_MainTex) * _ShowDecal;
			// o.Albedo = a.rgb * b.rgb; //layers them on top and combines the colors of the decal
			//o.Albedo = b.r > 0.9 ? b.rgb: a.rgb;  //adds the decals color entirely 
			o.Albedo = a.rgb + b.rgb;
		}
		ENDCG

	}
	Fallback "Diffuse"
}
