Shader "Unlit/TEST1"
{
	Properties{
		_Color ("Main Yoshi Color", COLOR) = (1,1,1,1)
	}
	SubShader
	{
	   Pass{

			Material{
				Diffuse[_Color]
				Ambient[_Color]
			}

		Lighting On

		}
    }
}
