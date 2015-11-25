Shader "Happy/glowforsphere" {
Properties {
_Color ("Color", Color) = (1,1,1,1)
_Cutoff ("Cutoff", Range(0,1))=0.5
_Power ("Power", Range(0.5, 5.0)) = 3.0
}
SubShader {
Tags { "Queue"="Transparent" }
LOD 200

CGPROGRAM
#pragma surface surf Lambert alpha


half4 _Color;
half _Cutoff;
half _Power;
float _intensity;

struct Input {
  float2 uv_MainTex;
  half3 viewDir;

};


void surf (Input IN, inout SurfaceOutput o) {
   half4 c = _Color;
   half ndv=saturate(dot(o.Normal,normalize(IN.viewDir)));
   o.Emission = c.rgb;
   o.Alpha = c.a*pow ((ndv-_Cutoff)/(2-_Cutoff+0.00001),_Power);
}
ENDCG
}
FallBack "Diffuse"
}