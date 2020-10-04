Shader "OneOneBlend"{
    Properties{
        _MainTex("Texture", 2D) = "black" {}
    }
    SubShader{
        Tags { "Queue"="Transparent" }
        //Blend SrcAlpha OneMinusSrcAlpha
		//Blend DstColor Zero //uses distance from light 
		Blend One One 
        Pass{
            SetTexture [_MainTex]{ combine texture}
        }
    }
}
