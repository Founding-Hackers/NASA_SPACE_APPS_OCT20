Shader "Transparent"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "black" {}
    }
    SubShader
    {
		Tags { "Queue" = "Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha //uses the alpha from the image
		Cull Off //turns back culling off
		Pass{
			SetTexture[_MainTex]{ combine texture}
		}
    }
}
