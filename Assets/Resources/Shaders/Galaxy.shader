// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:0,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:32719,y:32712,varname:node_3138,prsc:2|emission-3331-OUT;n:type:ShaderForge.SFN_Color,id:7241,x:32016,y:32572,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_7241,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.7758741,c2:0.6596021,c3:0.8970588,c4:1;n:type:ShaderForge.SFN_Tex2dAsset,id:8818,x:31250,y:32996,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:node_8818,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:5c3a3cd7382bdce459030c6d99e5b2c8,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:2645,x:32026,y:32907,varname:node_2645,prsc:2,tex:5c3a3cd7382bdce459030c6d99e5b2c8,ntxv:0,isnm:False|UVIN-8401-UVOUT,TEX-8818-TEX;n:type:ShaderForge.SFN_TexCoord,id:5669,x:30871,y:32676,varname:node_5669,prsc:2,uv:0;n:type:ShaderForge.SFN_Rotator,id:8401,x:31740,y:32720,varname:node_8401,prsc:2|UVIN-5669-UVOUT,SPD-573-OUT;n:type:ShaderForge.SFN_Vector1,id:573,x:31454,y:32915,varname:node_573,prsc:2,v1:0.2;n:type:ShaderForge.SFN_Multiply,id:3331,x:32289,y:32693,varname:node_3331,prsc:2|A-7241-RGB,B-2645-RGB;proporder:7241-8818;pass:END;sub:END;*/

Shader "Shader Forge/Galaxy" {
    Properties {
        _Color ("Color", Color) = (0.7758741,0.6596021,0.8970588,1)
        _MainTex ("MainTex", 2D) = "white" {}
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
                float4 node_1350 = _Time + _TimeEditor;
                float node_8401_ang = node_1350.g;
                float node_8401_spd = 0.2;
                float node_8401_cos = cos(node_8401_spd*node_8401_ang);
                float node_8401_sin = sin(node_8401_spd*node_8401_ang);
                float2 node_8401_piv = float2(0.5,0.5);
                float2 node_8401 = (mul(i.uv0-node_8401_piv,float2x2( node_8401_cos, -node_8401_sin, node_8401_sin, node_8401_cos))+node_8401_piv);
                float4 node_2645 = tex2D(_MainTex,TRANSFORM_TEX(node_8401, _MainTex));
                float3 emissive = (_Color.rgb*node_2645.rgb);
                float3 finalColor = emissive;
                return fixed4(finalColor,1);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
