Shader "RimShader"
{

	Properties
	{
		_RimColor("RimColor", Color)= (0,0.5,0.5,0.0) //can be set in the inspector but teal blue to start
		_RimPower("Rim Power", Range(0.5, 8.0)) = 3.0 //set initially as 3
	}

	SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input {

			float3 viewDir; //ViewDirection tells us where the models edges are edges have value of 0 and closest to the camera will have val 1

		};
		
		float4 _RimColor;
		float _RimPower;

		void surf(Input IN, inout SurfaceOutput o) {
			half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal)); //use can always normalize values to make sure it's a value from 1 and 0
			o.Emission = _RimColor.rgb * pow(rim, _RimPower);
		}
		ENDCG
	}
	Fallback "Diffuse"
}