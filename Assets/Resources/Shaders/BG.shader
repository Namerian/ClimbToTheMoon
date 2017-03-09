// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:1,rntp:1,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-5906-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:7528,x:31898,y:32907,ptovrint:False,ptlb:Main Tex,ptin:_MainTex,varname:node_7528,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:26bed124a1a16894b995648f98b3887e,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2629,x:32230,y:32704,varname:node_2629,prsc:2,tex:26bed124a1a16894b995648f98b3887e,ntxv:0,isnm:False|UVIN-6358-OUT,TEX-7528-TEX;n:type:ShaderForge.SFN_FragmentPosition,id:9991,x:31254,y:32373,varname:node_9991,prsc:2;n:type:ShaderForge.SFN_Append,id:704,x:31538,y:32444,varname:node_704,prsc:2|A-9991-X,B-9991-Y;n:type:ShaderForge.SFN_Color,id:772,x:32242,y:32904,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_772,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5,c2:0.5,c3:0.5,c4:1;n:type:ShaderForge.SFN_Multiply,id:5906,x:32469,y:32775,varname:node_5906,prsc:2|A-2629-RGB,B-772-RGB;n:type:ShaderForge.SFN_Multiply,id:8203,x:31766,y:32517,varname:node_8203,prsc:2|A-704-OUT,B-3268-OUT;n:type:ShaderForge.SFN_Slider,id:3268,x:31491,y:32802,ptovrint:False,ptlb:scale,ptin:_scale,varname:node_3268,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_Frac,id:6358,x:32061,y:32537,varname:node_6358,prsc:2|IN-8203-OUT;proporder:7528-772-3268;pass:END;sub:END;*/

Shader "Shader Forge/BG" {
    Properties {
        _MainTex ("Main Tex", 2D) = "white" {}
        _Color ("Color", Color) = (0.5,0.5,0.5,1)
        _scale ("scale", Range(0, 1)) = 0
    }
     SubShader {
        Tags {
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
       		ZTest Off
       		Blend SrcAlpha OneMinusSrcAlpha
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            ZWrite On
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _scale;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 posWorld : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
////// Lighting:
////// Emissive:
                float2 node_704 = float2(i.posWorld.r,i.posWorld.g);
                float2 node_6358 = frac((node_704*_scale));
                float4 node_2629 = tex2D(_MainTex,TRANSFORM_TEX(node_6358, _MainTex));
                float3 emissive = (node_2629.rgb*_Color.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
