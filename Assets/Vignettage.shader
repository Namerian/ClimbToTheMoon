// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:4,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-9401-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32152,y:32476,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.8897059,c2:0.4914908,c3:0.4056012,c4:1;n:type:ShaderForge.SFN_Multiply,id:5696,x:31363,y:32824,varname:node_5696,prsc:2|A-7757-UVOUT,B-7757-UVOUT;n:type:ShaderForge.SFN_ComponentMask,id:508,x:31924,y:32835,varname:node_508,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-7359-OUT;n:type:ShaderForge.SFN_Power,id:7359,x:31739,y:32835,varname:node_7359,prsc:2|VAL-5696-OUT,EXP-9507-OUT;n:type:ShaderForge.SFN_Slider,id:9507,x:31463,y:32983,ptovrint:False,ptlb:Size,ptin:_Size,varname:node_9507,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:3.982906,max:5;n:type:ShaderForge.SFN_Add,id:1378,x:32130,y:32835,varname:node_1378,prsc:2|A-508-R,B-508-G;n:type:ShaderForge.SFN_Clamp01,id:4065,x:32287,y:32835,varname:node_4065,prsc:2|IN-1378-OUT;n:type:ShaderForge.SFN_Lerp,id:9401,x:32499,y:32697,varname:node_9401,prsc:2|A-6355-OUT,B-7241-RGB,T-4065-OUT;n:type:ShaderForge.SFN_Vector1,id:6355,x:32082,y:32732,varname:node_6355,prsc:2,v1:1;n:type:ShaderForge.SFN_ScreenPos,id:7757,x:30725,y:32932,varname:node_7757,prsc:2,sctp:0;proporder:7241-9507;pass:END;sub:END;*/

Shader "Shader Forge/Vignettage" {
    Properties {
        _Color ("Color", Color) = (0.8897059,0.4914908,0.4056012,1)
        _Size ("Size", Range(0, 5)) = 3.982906
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend DstColor Zero
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float4 _Color;
            uniform float _Size;
            struct VertexInput {
                float4 vertex : POSITION;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float4 screenPos : TEXCOORD0;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                o.screenPos = o.pos;
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                i.screenPos = float4( i.screenPos.xy / i.screenPos.w, 0, 0 );
                i.screenPos.y *= _ProjectionParams.x;
////// Lighting:
////// Emissive:
                float node_6355 = 1.0;
                float2 node_508 = pow((i.screenPos.rg*i.screenPos.rg),_Size).rg;
                float3 emissive = lerp(float3(node_6355,node_6355,node_6355),_Color.rgb,saturate((node_508.r+node_508.g)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
