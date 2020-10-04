Shader "Fancier Bumpmap"
{
	//Interacts with light in the existing scene
	Properties{
		_myDiffuse("Diffuse Texture", 2D) = "white"{}
		_myTex("Bump Texture", 2D)= "bump"{}
		_mySlider("Bump Amount", Range(0,10)) = 1 //slider
		_myBright("Brightness", Range(0,10)) = 1
		_myCube("Cube Map", CUBE) = "white"{}
		_myBumpHeight("Bump Height", Range(0,10)) = 1 //depth of bumps
		_myScale("UVW Scale", Range(0,10)) = 1		// repeats the pattern more or less
	}

		SubShader{

			CGPROGRAM
			#pragma surface surf Lambert

			sampler2D _myDiffuse;
			sampler2D _myTex;
			half _mySlider;
			half _myBright;
			samplerCUBE _myCube;

			struct Input {
				float2 uv_myDiffuse;
				float2 uv_myTex;
				float3 worldRefl; INTERNAL_DATA			//Surface vectors to be reflected (you have to use the internal data to prevent errors)
			};

			void surf(Input IN, inout SurfaceOutput o) {
				o.Albedo = tex2D(_myDiffuse, IN.uv_myDiffuse).rgb;
				o.Normal = UnpackNormal(tex2D(_myTex, IN.uv_myTex)) *_myBright;
				o.Normal += float3(_mySlider, _mySlider, 1);
				o.Emission = texCUBE(_myCube, WorldReflectionVector(IN, o.Normal)).rgb;
			}

			ENDCG
		}
}