// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32846,y:32709,varname:node_3138,prsc:2|emission-1276-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32101,y:33156,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.5500726,c2:0.1959883,c3:0.9191176,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:9587,x:31645,y:33214,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_9587,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:e09b715c7649b1248aa2f835c26965fa,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6941,x:31878,y:32674,varname:node_6941,prsc:2,tex:e09b715c7649b1248aa2f835c26965fa,ntxv:0,isnm:False|UVIN-147-OUT,TEX-9587-TEX;n:type:ShaderForge.SFN_Tex2d,id:5900,x:31878,y:32816,varname:node_5900,prsc:2,tex:e09b715c7649b1248aa2f835c26965fa,ntxv:0,isnm:False|UVIN-1437-OUT,TEX-9587-TEX;n:type:ShaderForge.SFN_Tex2d,id:4440,x:31878,y:32955,varname:node_4440,prsc:2,tex:e09b715c7649b1248aa2f835c26965fa,ntxv:0,isnm:False|UVIN-5099-OUT,TEX-9587-TEX;n:type:ShaderForge.SFN_Add,id:1437,x:31427,y:32793,varname:node_1437,prsc:2|A-1884-OUT,B-3927-OUT;n:type:ShaderForge.SFN_TexCoord,id:9257,x:31047,y:32371,varname:node_9257,prsc:2,uv:0;n:type:ShaderForge.SFN_Add,id:5099,x:31427,y:32918,varname:node_5099,prsc:2|A-1884-OUT,B-2152-OUT;n:type:ShaderForge.SFN_Add,id:913,x:32104,y:32786,varname:node_913,prsc:2|A-6941-R,B-5900-B,C-4440-G;n:type:ShaderForge.SFN_Append,id:1415,x:30524,y:32573,varname:node_1415,prsc:2|A-3299-X,B-3299-Y;n:type:ShaderForge.SFN_ViewPosition,id:3299,x:30321,y:32573,varname:node_3299,prsc:2;n:type:ShaderForge.SFN_Power,id:1041,x:32418,y:32649,varname:node_1041,prsc:2|VAL-913-OUT,EXP-7343-OUT;n:type:ShaderForge.SFN_Vector1,id:7343,x:32127,y:32982,varname:node_7343,prsc:2,v1:2;n:type:ShaderForge.SFN_Lerp,id:6061,x:32490,y:33031,varname:node_6061,prsc:2|A-7241-RGB,B-913-OUT,T-1041-OUT;n:type:ShaderForge.SFN_Multiply,id:1276,x:32642,y:32903,varname:node_1276,prsc:2|A-913-OUT,B-6061-OUT;n:type:ShaderForge.SFN_Multiply,id:1884,x:31199,y:32505,varname:node_1884,prsc:2|A-9257-UVOUT,B-8195-OUT;n:type:ShaderForge.SFN_Slider,id:8195,x:30890,y:32532,ptovrint:False,ptlb:scale,ptin:_scale,varname:node_8195,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:3;n:type:ShaderForge.SFN_Add,id:147,x:31427,y:32662,varname:node_147,prsc:2|A-1884-OUT,B-3020-OUT;n:type:ShaderForge.SFN_Multiply,id:3927,x:30996,y:32790,varname:node_3927,prsc:2|A-1415-OUT,B-7174-OUT;n:type:ShaderForge.SFN_Vector1,id:7174,x:30683,y:32818,varname:node_7174,prsc:2,v1:0.05;n:type:ShaderForge.SFN_Multiply,id:3020,x:30919,y:32649,varname:node_3020,prsc:2|A-1415-OUT,B-518-OUT;n:type:ShaderForge.SFN_Vector1,id:518,x:30666,y:32712,varname:node_518,prsc:2,v1:0.1;n:type:ShaderForge.SFN_Multiply,id:2152,x:31116,y:32963,varname:node_2152,prsc:2|A-1415-OUT,B-3302-OUT;n:type:ShaderForge.SFN_Vector1,id:3302,x:30777,y:33049,varname:node_3302,prsc:2,v1:0.01;proporder:7241-9587-8195;pass:END;sub:END;*/

Shader "Shader Forge/SPACE" {
    Properties {
        _Color ("Color", Color) = (0.5500726,0.1959883,0.9191176,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _scale ("scale", Range(0, 3)) = 1
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
            Blend One One
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
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _scale;
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
////// Lighting:
////// Emissive:
                float2 node_1884 = (i.uv0*_scale);
                float2 node_1415 = float2(_WorldSpaceCameraPos.r,_WorldSpaceCameraPos.g);
                float2 node_147 = (node_1884+(node_1415*0.1));
                float4 node_6941 = tex2D(_MainTex,TRANSFORM_TEX(node_147, _MainTex));
                float2 node_1437 = (node_1884+(node_1415*0.05));
                float4 node_5900 = tex2D(_MainTex,TRANSFORM_TEX(node_1437, _MainTex));
                float2 node_5099 = (node_1884+(node_1415*0.01));
                float4 node_4440 = tex2D(_MainTex,TRANSFORM_TEX(node_5099, _MainTex));
                float node_913 = (node_6941.r+node_5900.b+node_4440.g);
                float3 emissive = (node_913*lerp(_Color.rgb,float3(node_913,node_913,node_913),pow(node_913,2.0)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
