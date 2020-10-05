Shader "BlendTest"{
    Properties{
        _MainTex("Texture", 2D) = "black" {}
    }
    SubShader{
        Tags { "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha //uses the alpha from the image
		//Blend DstColor Zero //uses distance from light 
		//Blend One One //uses black as transparent
        Pass{
            SetTexture [_MainTex]{ combine texture}
        }
    }
}
