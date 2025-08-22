// Unity built-in shader source. Copyright (c) 2016 Unity Technologies. MIT license (see license.txt)

Shader "ALP/Billboard_Instanced" {
Properties {
    _Color ("Main Color", Color) = (1,1,1,1)
    _MainTex ("Base (RGB) Alpha (A)", 2D) = "white" {}
    _Cutoff ("Alpha cutoff", Range(0,1)) = 0.9
    _BaseLight ("Base Light", Range(0, 1)) = 0.35
    _AO ("Amb. Occlusion", Range(0, 10)) = 2.4
    _Occlusion ("Dir Occlusion", Range(0, 20)) = 7.5
    [HideInInspector] _TreeInstanceColor ("TreeInstanceColor", Vector) = (1,1,1,1)
    [HideInInspector] _TreeInstanceScale ("TreeInstanceScale", Vector) = (1,1,1,1)
    [HideInInspector] _SquashAmount ("Squash", Float) = 1
}

SubShader {
    Tags { "IgnoreProjector"="True" "RenderType"="TreeLeaf"
            "Queue" = "AlphaTest"
            "IgnoreProjector"="True"
            "RenderType" = "TreeTransparentCutout"   
          }

   

   

CGPROGRAM
#pragma vertex vert

#pragma multi_compile_shadowcaster
#pragma surface surf TreeLeaf alphatest:_Cutoff vertex:TreeVertLeaf addshadow nolightmap noforwardadd
#include "UnityBuiltin3xTreeLibrary.cginc"


sampler2D _MainTex;

struct Input {
    float2 uv_MainTex;
    fixed4 color : COLOR; // color.a = AO
};


void surf (Input IN, inout LeafSurfaceOutput o) {
    fixed4 c = tex2D(_MainTex, IN.uv_MainTex);
    o.Albedo = c.rgb * IN.color.rgb * IN.color.a;
    o.Alpha = c.a;  
}


ENDCG


}

Dependency "OptimizedShader" = "Hidden/Nature/Tree Creator Leaves Optimized"
FallBack "Diffuse"

}



