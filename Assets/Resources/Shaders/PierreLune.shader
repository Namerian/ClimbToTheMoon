// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-4875-OUT,clip-3409-G;n:type:ShaderForge.SFN_Color,id:7241,x:31665,y:32303,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5073529,c2:0.7263072,c3:1,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:111,x:31393,y:32932,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_111,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:ff045ea2a2e55e349968fa7fd99a9a1d,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:1462,x:31670,y:32831,varname:node_1462,prsc:2,tex:ff045ea2a2e55e349968fa7fd99a9a1d,ntxv:0,isnm:False|UVIN-1040-UVOUT,TEX-111-TEX;n:type:ShaderForge.SFN_TexCoord,id:6314,x:30876,y:32746,varname:node_6314,prsc:2,uv:0;n:type:ShaderForge.SFN_Panner,id:7297,x:31095,y:32746,varname:node_7297,prsc:2,spu:-0.2,spv:0|UVIN-6314-UVOUT;n:type:ShaderForge.SFN_Add,id:4875,x:32349,y:32660,varname:node_4875,prsc:2|A-9981-OUT,B-1462-B;n:type:ShaderForge.SFN_Tex2d,id:3409,x:31609,y:32581,varname:node_3409,prsc:2,tex:ff045ea2a2e55e349968fa7fd99a9a1d,ntxv:0,isnm:False|TEX-111-TEX;n:type:ShaderForge.SFN_Rotator,id:1040,x:31313,y:32746,varname:node_1040,prsc:2|UVIN-7297-UVOUT,ANG-9080-OUT;n:type:ShaderForge.SFN_Vector1,id:9080,x:31134,y:32909,varname:node_9080,prsc:2,v1:-0.5;n:type:ShaderForge.SFN_Blend,id:9981,x:32074,y:32413,varname:node_9981,prsc:2,blmd:6,clmp:True|SRC-7241-RGB,DST-7902-OUT;n:type:ShaderForge.SFN_Multiply,id:7902,x:31882,y:32505,varname:node_7902,prsc:2|A-7058-OUT,B-3409-R;n:type:ShaderForge.SFN_Vector1,id:7058,x:31637,y:32514,varname:node_7058,prsc:2,v1:0.3;proporder:7241-111;pass:END;sub:END;*/

Shader "Shader Forge/T_PierreLune" {
    Properties {
        _Color ("Color", Color) = (0.5073529,0.7263072,1,1)
        _tex ("tex", 2D) = "white" {}
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
    }
    SubShader {
        Tags {
            "Queue"="AlphaTest"
            "RenderType"="TransparentCutout"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase_fullshadows
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _tex; uniform float4 _tex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_3409 = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                clip(node_3409.g - 0.5);
////// Lighting:
////// Emissive:
                float node_1040_ang = (-0.5);
                float node_1040_spd = 1.0;
                float node_1040_cos = cos(node_1040_spd*node_1040_ang);
                float node_1040_sin = sin(node_1040_spd*node_1040_ang);
                float2 node_1040_piv = float2(0.5,0.5);
                float4 node_9907 = _Time + _TimeEditor;
                float2 node_1040 = (mul((i.uv0+node_9907.g*float2(-0.2,0))-node_1040_piv,float2x2( node_1040_cos, -node_1040_sin, node_1040_sin, node_1040_cos))+node_1040_piv);
                float4 node_1462 = tex2D(_tex,TRANSFORM_TEX(node_1040, _tex));
                float3 emissive = (saturate((1.0-(1.0-_Color.rgb)*(1.0-(0.3*node_3409.r))))+node_1462.b);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
        Pass {
            Name "ShadowCaster"
            Tags {
                "LightMode"="ShadowCaster"
            }
            Offset 1, 1
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_SHADOWCASTER
            #include "UnityCG.cginc"
            #include "Lighting.cginc"
            #pragma fragmentoption ARB_precision_hint_fastest
            #pragma multi_compile_shadowcaster
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform sampler2D _tex; uniform float4 _tex_ST;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                V2F_SHADOW_CASTER;
                float2 uv0 : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                TRANSFER_SHADOW_CASTER(o)
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_3409 = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                clip(node_3409.g - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
