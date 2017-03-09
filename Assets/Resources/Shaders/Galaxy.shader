// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32981,y:32707,varname:node_3138,prsc:2|emission-5299-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32016,y:32572,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7758741,c2:0.6596021,c3:0.8970588,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:8818,x:31250,y:32996,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8818,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5c3a3cd7382bdce459030c6d99e5b2c8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2645,x:32026,y:32907,varname:node_2645,prsc:2,tex:5c3a3cd7382bdce459030c6d99e5b2c8,ntxv:0,isnm:False|UVIN-8401-UVOUT,TEX-8818-TEX;n:type:ShaderForge.SFN_TexCoord,id:5669,x:30871,y:32676,varname:node_5669,prsc:2,uv:0;n:type:ShaderForge.SFN_Rotator,id:8401,x:31740,y:32720,varname:node_8401,prsc:2|UVIN-5669-UVOUT,SPD-573-OUT;n:type:ShaderForge.SFN_Vector1,id:573,x:31454,y:32915,varname:node_573,prsc:2,v1:0.03;n:type:ShaderForge.SFN_Multiply,id:3331,x:32289,y:32693,varname:node_3331,prsc:2|A-7241-RGB,B-2645-RGB;n:type:ShaderForge.SFN_Multiply,id:5299,x:32584,y:32848,varname:node_5299,prsc:2|A-3331-OUT,B-824-OUT,C-3581-OUT;n:type:ShaderForge.SFN_Slider,id:824,x:32262,y:32955,ptovrint:False,ptlb:brightness,ptin:_brightness,varname:node_824,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_TexCoord,id:595,x:31891,y:33121,varname:node_595,prsc:2,uv:0;n:type:ShaderForge.SFN_RemapRange,id:4101,x:32041,y:33121,varname:node_4101,prsc:2,frmn:0,frmx:1,tomn:-1,tomx:1|IN-595-UVOUT;n:type:ShaderForge.SFN_Multiply,id:5121,x:32198,y:33121,varname:node_5121,prsc:2|A-4101-OUT,B-4101-OUT;n:type:ShaderForge.SFN_ComponentMask,id:1041,x:32354,y:33121,varname:node_1041,prsc:2,cc1:0,cc2:1,cc3:-1,cc4:-1|IN-5121-OUT;n:type:ShaderForge.SFN_Add,id:8719,x:32516,y:33121,varname:node_8719,prsc:2|A-1041-R,B-1041-G;n:type:ShaderForge.SFN_OneMinus,id:3581,x:32673,y:33121,varname:node_3581,prsc:2|IN-8719-OUT;proporder:7241-8818-824;pass:END;sub:END;*/

Shader "Shader Forge/Galaxy" {
    Properties {
        _Color ("Color", Color) = (0.7758741,0.6596021,0.8970588,1)
        _MainTex ("MainTex", 2D) = "white" {}
        _brightness ("brightness", Range(0, 1)) = 1
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
            #pragma only_renderers d3d9 d3d11 glcore gles 
            #pragma target 3.0
            uniform float4 _TimeEditor;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float _brightness;
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
                float4 node_6993 = _Time + _TimeEditor;
                float node_8401_ang = node_6993.g;
                float node_8401_spd = 0.03;
                float node_8401_cos = cos(node_8401_spd*node_8401_ang);
                float node_8401_sin = sin(node_8401_spd*node_8401_ang);
                float2 node_8401_piv = float2(0.5,0.5);
                float2 node_8401 = (mul(i.uv0-node_8401_piv,float2x2( node_8401_cos, -node_8401_sin, node_8401_sin, node_8401_cos))+node_8401_piv);
                float4 node_2645 = tex2D(_MainTex,TRANSFORM_TEX(node_8401, _MainTex));
                float2 node_4101 = (i.uv0*2.0+-1.0);
                float2 node_1041 = (node_4101*node_4101).rg;
                float3 emissive = ((_Color.rgb*node_2645.rgb)*_brightness*(1.0 - (node_1041.r+node_1041.g)));
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
