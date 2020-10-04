Shader "DotProduct"
{
	//Shows the difference of calculating the Dot Product
	SubShader{

		CGPROGRAM
		#pragma surface surf Lambert

		struct Input 
		{
			float3 viewDir;		//takes in View Direction
		};

		void surf (Input IN, inout SurfaceOutput o)  
		{
			half dotp = dot(IN.viewDir, o.Normal);	//calculates the view direction and normal dot product, results in a mostly white with blue reflection
			//half dotp = 1- dot(IN.viewDir, o.Normal);	 //this function flips the shaded values to be mostly blue with a white reflection
			o.Albedo = float3(dotp, 1, 1);			//stores value of calculation and the red value is interpreting it

			//o.Albedo.r = 1- dot(IN.viewDir, o.Normal); // mostly black with red reflections
			//o.Albedo.gb = float2(1- dot(IN.viewDir, o.Normal), 0); //mostly black with green reflections
			// o.Albedo = float3(0,1-dot(IN.viewDir, o.Normal), 1);  //dark blue base with light blue reflections
			//o.Albedo = float3(dot(IN.viewDir, o.Normal), 1, 1 - dot(IN.viewDir, o.Normal));  //radioative yellow base and blue-green reflections

		}
		ENDCG
	}
}