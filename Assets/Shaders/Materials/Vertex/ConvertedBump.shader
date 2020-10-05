Shader "Unlit/ConvertedBump"
{
	Properties
	{
		_MainTex("Texture", 2D) = "white" {}
		_Diffuse("Diffuse Texture", 2D) = "white"{}
		//_Tex("Bump Texture", 2D) = "bump"{}
		//_Slider("Bump Amount", Range(0,10)) = 1 //slider
		_Brightness("Brightness", Range(0,10)) = 1
		_Skybox("Skybox", CUBE) = "white"{}
		_BumpHeight("Bump Height", Range(0,10)) = 1 //depth of bumps
		_Scale("UVW Scale", Range(0,10)) = 1		// repeats the pattern more or less
		_MipMap("Mip Mapping", Int) = 1;
	}
		SubShader
	{
		Tags { "LightMode" = "ForwardBase" }
		LOD 100

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#pragma target 3.0
			#include "UnityLightingCommon.cginc"
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 Position : POSITION0;
				float4 Normal : NORMAL0;
				float4 Tangent : TANGENT0;
				float2 TexCoord : TEXCOORD0;
			};

			struct v2f
			{
				float4 Position : POSITION0;
				float3 Normal : NORMAL;
				float3 Tangent : TANGENT0;
				float3 WorldPosition : POSITION1;
				float2 TexCoord : TEXCOORD0;
			};

			sampler2D _MainTex;
			float4 _MainTex_ST;

			v2f vert(appdata v)
			{
				v2f output;
				float4 worldpos = mul(input.Position, Model);
				output.Position = mul(mul(worldpos, View), Projection);
				output.WorldPosition = worldpos.xyz;
				output.Normal = normalize(mul(float4(input.Normal.xyz, 0), Model).xyz);
				output.Tangent = normalize(mul(float4(input.Tangent.xyz, 0), Model).xyz);
				output.TexCoord = input.TexCoord;
				return output;
			}

			fixed4 frag(v2f i) : SV_Target
			{
				float3 normalTex;
				if (MipMap)
				{
					normalTex = tex2D(NormalMapSamplerNone, input.TexCoord * UvwScale.xy).rgb;
				}
				else
				{
					normalTex = tex2D(NormalMapSamplerNormalLinear, input.TexCoord * UvwScale.xy).rgb;
				}
				normalTex = lerp(float3(0.5, 0.5, 1), normalTex, UvwScale.z);
				return float4(normalTex, 1.0);
			}

			
			ENDCG
		}

		
	}
}
