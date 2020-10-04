Shader "RimCuttoff"
{

	Properties
	{
		_RimColor("RimColor", Color) = (0,0.5,0.5,0.0) //can be set in the inspector but teal blue to start
		_RimPower("Rim Power", Range(0.5, 8.0)) = 3.0 //set initially as 3
	}

		SubShader
	{
		CGPROGRAM
		#pragma surface surf Lambert
		struct Input {

			float3 viewDir; //ViewDirection tells us where the models edges are edges have value of 0 and closest to the camera will have val 1
			float3 worldPos; //Calculates world position

		};

		float4 _RimColor;
		float _RimPower;

		void surf(Input IN, inout SurfaceOutput o) {
			half rim = 1 - saturate(dot(normalize(IN.viewDir), o.Normal)); //use can always normalize values to make sure it's a value from 1 and 0
			//o.Emission = _RimColor.rgb * pow(rim, _RimPower); //standard rim shader
			//o.Emission = _RimColor.rgb * rim > 0.5 ? rim: 0; // checks to see if the distance is greater that .5 then applies the shader giving a hard line
			//o.Emission = rim > 0.5 ? float3(1,0,0): 0; //gives a solide harsh red shading around edges
			//o.Emission = rim > 0.5 ? float3(1, 0, 0) : rim > 0.3 ? float3(0,1,0):0; //creates 2 solid line shadings based on it's position 
			//o.Emission = IN.worldPos.y > 1 ? float3(0, 1, 0) : float3(1,0,0); //create world position on the Y-Axis it will render different colors
			o.Emission = frac(IN.worldPos.y * 10 * 0.5) > 0.4 ? //10 makes a larger stripe, divides by 2, .4 encapsulates floating point errors
							float3(0, 1, 0)*rim : float3(1, 0, 0)*rim; //multiplying by the rim adds the depth to the values
		}
		ENDCG
	}
		Fallback "Diffuse"
}