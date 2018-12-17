// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "Donjon_Shader/Wall" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _SpecColor ("Specular Color", Color) = (0.5, 0.5, 0.5, 1)
    [PowerSlider(5.0)] _Shininess ("Shininess", Range (0.03, 1)) = 0.078125
	_HeightCtrlScale ("Rand Height", Range (0.03, 3)) = 0.078125
	_HeightFadeMoss ("Height_Ctrl", Range (0, 10)) = 0.078125
	_MossStrength ("Strength_Ctrl", Range (-5, 5)) = 1
    _MainTex ("Base (RGB) Gloss (A)", 2D) = "white" {}
	_BumpMap ("Normalmap", 2D) = "bump" {}
	_MossCtrlTex ("Moss Ctrl (RGB) Gloss (A)", 2D) = "white" {}
	_MossTex ("Moss (RGB) Gloss (A)", 2D) = "white" {}
   	_MossMap ("Moss map", 2D) = "bump" {}
}

CGINCLUDE
sampler2D _MainTex;
sampler2D _MossTex;
sampler2D _BumpMap;
sampler2D _MossMap;
sampler2D _MossCtrlTex;
fixed4 _Color;
half _Shininess;
fixed _HeightFadeMoss;
fixed _MossStrength;
fixed _HeightCtrlScale;

struct Input {
    float2 uv_MainTex;
    float2 uv_BumpMap;
	float3 worldPos;
};

void surf (Input IN, inout SurfaceOutput o) {
    fixed4 tex = tex2D(_MainTex, IN.uv_MainTex);
	fixed3 mossTex = tex2D(_MossTex, IN.uv_MainTex);
	fixed mossHeight = tex2D(_MossCtrlTex, IN.worldPos.xz * _HeightCtrlScale).r;
//	float mossCtrl = clamp(IN.worldPos.y * _HeightMoss * mossHeight, 0, 1);
	float mossCtrl = clamp((IN.worldPos.y + (_MossStrength * mossHeight)) * _HeightFadeMoss, 0, 1);
//	tex.rgb = lerp(mossTex, 1, mossCtrl);
	tex.rgb = tex.rgb * mossCtrl;
	tex.rgb += mossTex * (1 - mossCtrl);
    o.Albedo = tex.rgb * _Color.rgb;
 	o.Gloss = tex.a;
  //  o.Alpha = tex.a * _Color.a;
    o.Specular = _Shininess;
    o.Normal = lerp(UnpackNormal(tex2D(_MossMap, IN.uv_BumpMap)), UnpackNormal(tex2D(_BumpMap, IN.uv_BumpMap)), mossCtrl);
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
