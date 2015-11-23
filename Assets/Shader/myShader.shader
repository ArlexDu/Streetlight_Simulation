Shader "Happy/LightShader" {
	Properties
	{
	    _ColorTint ("Color Tint",Color)=(1,1,1,1)
		_MainTex ("Texture", 2D) = "white" {}
		_RimColor("Rim Color",Color)=(1,1,1,1)
		_RimPower("Rim Power",Range(1,6)) = 3
		_Alpha("Rim Power",Range(0,1)) = 1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		#pragma surface surf Lambert alpha:blend


		struct Input {
		    float4 color : Color;
			float2 uv_MainTex;
			float3 viewDir;
		};
        float4 _ColorTint;
        sampler2D _MainTex;
        float4 _RimColor;
        float _RimPower; 
        float _Alpha; 

		void surf (Input IN, inout SurfaceOutput o) {
			// Albedo comes from a texture tinted by color
			IN.color = _ColorTint;
			half4 c = tex2D(_MainTex,IN.uv_MainTex);
			o.Albedo = c.rgb * IN.color;
			o.Emission = _RimColor.rgb * pow(0.5,_RimPower);
			o.Alpha = c.r * _Alpha;
		}
		ENDCG
	} 
	FallBack "Diffuse"
}
