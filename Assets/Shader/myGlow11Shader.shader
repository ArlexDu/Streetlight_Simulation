Shader "Happy/myGlow11Shader" {
Properties {
	_Color ("Main Color", Color) = (1,1,1,1)
	_MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_Illum ("Illumin (A)", 2D) = "white" {}
	
}
SubShader {
	Tags { "RenderEffect"="Glow11" "RenderType"="Glow11" }
	LOD 200
	
CGPROGRAM
#pragma surface surf Lambert

sampler2D _MainTex;
sampler2D _Illum;
fixed4 _Color;

struct Input {
	float2 uv_MainTex;
	float2 uv_Illum;
};

void surf (Input IN, inout SurfaceOutput o) {
	fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 c = tex * _Color;
	o.Albedo = c.rgb;
	o.Emission = c.rgb * UNITY_SAMPLE_1CHANNEL(_Illum, IN.uv_Illum);
	o.Alpha = c.a;
}
ENDCG
} 
FallBack "Glow 11/Unity/Self-Illumin/VertexLit"
CustomEditor "GlowMatInspector"
}
