// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Donjon_Shader/Floor" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
    [PowerSlider(5.0)] _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
	_DirtScale ("Dirt Scale", Range (0.03, 0.5)) = 0.2
	_WaterScale ("water Scale", Range (0.03, 0.5)) = 0.2
    _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_DirTex ("Dirt (RGB) Gloss (A)", 2D) = "white" {}
	_DirMaskTex ("Dirt Map", 2D) = "white" {}
	_DirtBumpMap ("Dirt Normalmap", 2D) = "bump" {}
	_WaterMaskTex ("Water Map", 2D) = "white" {}
}

CGINCLUDE

sampler2D _MainTex;
sampler2D _DirTex;
sampler2D _DirMaskTex;
sampler2D _WaterMaskTex;
sampler2D _BumpMap;
sampler2D _DirtBumpMap;
fixed4 _Color;
fixed _DirtScale;
fixed _WaterScale;
half _Shininess;

struct Input {
    float2 uv_MainTex;
    float2 uv_BumpMap;
	float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed4 dirtTex = tex2D(_DirTex, IN.uv_MainTex);
	// mask texture
	fixed4 dirtMaskTex = tex2D(_DirMaskTex, IN.worldPos.xz * _DirtScale);
	fixed4 WaterMaskTex = tex2D(_WaterMaskTex, IN.worldPos.xz * _WaterScale);
	fixed3 col = tex.rgb * _Color.rgb * dirtTex;
	col = col * (1 - dirtMaskTex.r) + dirtTex * dirtMaskTex.r;
//	col = col * (1 - (WaterMaskTex.r + 1) * 0.5);
	col = col * ((1 - WaterMaskTex.r)+1) * 0.5;	
    o.Albedo = col;
    o.Gloss = clamp(dirtMaskTex.r/2 + (WaterMaskTex.r*2) + 0.2, 0, 1);
    o.Alpha = tex.a * _Color.a;
    o.Specular = _Shininess + ((1 - WaterMaskTex.r) * 2);
	// normal texture
	fixed3 norml = UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap));
	fixed3 dirtNormal = UnpackNormal(tex2D(_DirtBumpMap, IN.uv_BumpMap));
	norml = norml * (1 - dirtMaskTex.r) + dirtNormal * dirtMaskTex.r;
	norml = norml * (1 - WaterMaskTex.r) + fixed3(0,0,5) * WaterMaskTex.r;
    o.Normal = norml;
}
ENDCG

SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 400

    CGPROGRAM
    #pragma surface surf BlinnPhong
    #pragma target 3.0
    ENDCG
}

SubShader {
    Tags { "RenderType"="Opaque" }
    LOD 400

    CGPROGRAM
    #pragma surface surf BlinnPhong nodynlightmap
    ENDCG
}

FallBack "Legacy Shaders/Specular"
}
