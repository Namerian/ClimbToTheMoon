// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:False,dith:0,rfrpo:False,rfrpn:Refraction,coma:15,ufog:False,aust:False,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33814,y:32963,varname:node_3138,prsc:2|emission-9915-OUT,clip-4224-OUT;n:type:ShaderForge.SFN_Tex2d,id:5913,x:32076,y:32936,varname:node_5913,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-7952-UVOUT,TEX-1519-TEX;n:type:ShaderForge.SFN_TexCoord,id:7952,x:31121,y:32950,varname:node_7952,prsc:2,uv:0;n:type:ShaderForge.SFN_Tex2d,id:8120,x:32076,y:33278,varname:node_8120,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-983-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Tex2d,id:1963,x:32076,y:33599,varname:node_1963,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-8047-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Multiply,id:2353,x:31126,y:33314,varname:node_2353,prsc:2|A-5752-UVOUT,B-920-OUT;n:type:ShaderForge.SFN_Slider,id:3162,x:30198,y:33321,ptovrint:False,ptlb:offset difference,ptin:_offsetdifference,varname:node_3162,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2365446,max:1;n:type:ShaderForge.SFN_Multiply,id:8361,x:31118,y:33589,varname:node_8361,prsc:2|A-5752-UVOUT,B-2630-OUT;n:type:ShaderForge.SFN_Add,id:7908,x:31021,y:33928,varname:node_7908,prsc:2|A-2630-OUT,B-920-OUT;n:type:ShaderForge.SFN_Multiply,id:2943,x:31252,y:33874,varname:node_2943,prsc:2|A-5752-UVOUT,B-7908-OUT;n:type:ShaderForge.SFN_Tex2d,id:8629,x:32076,y:33958,varname:node_8629,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-8460-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Lerp,id:5480,x:32915,y:33130,varname:node_5480,prsc:2|A-8606-OUT,B-2934-OUT,T-5003-OUT;n:type:ShaderForge.SFN_Vector1,id:2354,x:32228,y:31996,varname:node_2354,prsc:2,v1:1;n:type:ShaderForge.SFN_Subtract,id:5825,x:32482,y:31996,varname:node_5825,prsc:2|A-2354-OUT,B-8939-OUT;n:type:ShaderForge.SFN_Subtract,id:1290,x:32482,y:32142,varname:node_1290,prsc:2|A-5825-OUT,B-8939-OUT;n:type:ShaderForge.SFN_Subtract,id:7039,x:32482,y:32316,varname:node_7039,prsc:2|A-1290-OUT,B-8939-OUT;n:type:ShaderForge.SFN_Subtract,id:8600,x:32482,y:32461,varname:node_8600,prsc:2|A-7039-OUT,B-8939-OUT;n:type:ShaderForge.SFN_Lerp,id:8606,x:32890,y:33348,varname:node_8606,prsc:2|A-469-OUT,B-3225-OUT,T-2896-OUT;n:type:ShaderForge.SFN_Lerp,id:469,x:32901,y:33531,varname:node_469,prsc:2|A-1295-OUT,B-8983-OUT,T-6466-OUT;n:type:ShaderForge.SFN_OneMinus,id:5003,x:32530,y:33301,varname:node_5003,prsc:2|IN-5921-OUT;n:type:ShaderForge.SFN_OneMinus,id:2896,x:32530,y:33539,varname:node_2896,prsc:2|IN-8031-OUT;n:type:ShaderForge.SFN_OneMinus,id:6466,x:32530,y:33779,varname:node_6466,prsc:2|IN-7090-OUT;n:type:ShaderForge.SFN_Slider,id:8939,x:32071,y:32078,ptovrint:False,ptlb:gradient,ptin:_gradient,varname:node_8939,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0.2222222,max:1;n:type:ShaderForge.SFN_Add,id:2630,x:30597,y:33574,varname:node_2630,prsc:2|A-920-OUT,B-920-OUT;n:type:ShaderForge.SFN_Color,id:9468,x:33195,y:32806,ptovrint:False,ptlb:Color,ptin:_Color,varname:node_9468,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:0.1255407,c2:0.3387513,c3:0.6323529,c4:1;n:type:ShaderForge.SFN_Multiply,id:9915,x:33511,y:32972,varname:node_9915,prsc:2|A-9468-RGB,B-5480-OUT;n:type:ShaderForge.SFN_Tex2dAsset,id:1519,x:31470,y:34134,ptovrint:False,ptlb:Main Tex,ptin:_MainTex,varname:node_1519,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6727,x:32080,y:33041,varname:node_6727,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-7952-UVOUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Tex2d,id:517,x:32076,y:33372,varname:node_517,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-983-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Tex2d,id:3294,x:32076,y:33692,varname:node_3294,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-8047-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Tex2d,id:6587,x:32076,y:34053,varname:node_6587,prsc:2,tex:a6caf115e36d26f4f9ec9d56b228bcd4,ntxv:0,isnm:False|UVIN-8460-OUT,TEX-1519-TEX;n:type:ShaderForge.SFN_Multiply,id:2934,x:32499,y:32966,varname:node_2934,prsc:2|A-2354-OUT,B-6727-R,C-6358-RGB;n:type:ShaderForge.SFN_Multiply,id:3225,x:32715,y:33413,varname:node_3225,prsc:2|A-517-G,B-1290-OUT,C-9109-RGB;n:type:ShaderForge.SFN_Multiply,id:8983,x:32715,y:33649,varname:node_8983,prsc:2|A-3294-B,B-7039-OUT,C-2775-RGB;n:type:ShaderForge.SFN_Multiply,id:1295,x:32715,y:33896,varname:node_1295,prsc:2|A-6587-A,B-8600-OUT,C-2014-RGB;n:type:ShaderForge.SFN_Tex2dAsset,id:3509,x:31609,y:33396,ptovrint:False,ptlb:texture,ptin:_texture,varname:node_3509,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:a0a53f11c1fc99f45a335b3c7b3e8881,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Tex2d,id:6358,x:32076,y:33156,varname:node_6358,prsc:2,tex:a0a53f11c1fc99f45a335b3c7b3e8881,ntxv:0,isnm:False|UVIN-983-OUT,TEX-3509-TEX;n:type:ShaderForge.SFN_Tex2d,id:9109,x:32076,y:33467,varname:node_9109,prsc:2,tex:a0a53f11c1fc99f45a335b3c7b3e8881,ntxv:0,isnm:False|UVIN-8047-OUT,TEX-3509-TEX;n:type:ShaderForge.SFN_Tex2d,id:2775,x:32076,y:33790,varname:node_2775,prsc:2,tex:a0a53f11c1fc99f45a335b3c7b3e8881,ntxv:0,isnm:False|UVIN-8460-OUT,TEX-3509-TEX;n:type:ShaderForge.SFN_Tex2d,id:2014,x:32076,y:34145,varname:node_2014,prsc:2,tex:a0a53f11c1fc99f45a335b3c7b3e8881,ntxv:0,isnm:False|UVIN-8460-OUT,TEX-3509-TEX;n:type:ShaderForge.SFN_ViewPosition,id:396,x:28703,y:32769,varname:node_396,prsc:2;n:type:ShaderForge.SFN_ObjectPosition,id:4428,x:28703,y:32540,varname:node_4428,prsc:2;n:type:ShaderForge.SFN_Subtract,id:7658,x:29178,y:32493,varname:node_7658,prsc:2|A-396-X,B-4428-X;n:type:ShaderForge.SFN_Subtract,id:4886,x:29171,y:32856,varname:node_4886,prsc:2|A-396-Y,B-4428-Y;n:type:ShaderForge.SFN_Subtract,id:983,x:31455,y:33222,varname:node_983,prsc:2|A-7952-UVOUT,B-2353-OUT;n:type:ShaderForge.SFN_Subtract,id:8047,x:31462,y:33630,varname:node_8047,prsc:2|A-7952-UVOUT,B-8361-OUT;n:type:ShaderForge.SFN_Subtract,id:8460,x:31448,y:33967,varname:node_8460,prsc:2|A-7952-UVOUT,B-2943-OUT;n:type:ShaderForge.SFN_ValueProperty,id:6886,x:28748,y:33086,ptovrint:False,ptlb:object rotation,ptin:_objectrotation,varname:node_6886,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;n:type:ShaderForge.SFN_Append,id:6937,x:29870,y:32455,varname:node_6937,prsc:2|A-7658-OUT,B-4886-OUT;n:type:ShaderForge.SFN_Rotator,id:5752,x:30529,y:32618,varname:node_5752,prsc:2|UVIN-6937-OUT,ANG-6886-OUT;n:type:ShaderForge.SFN_Vector1,id:920,x:30250,y:33461,varname:node_920,prsc:2,v1:0.014;n:type:ShaderForge.SFN_Round,id:4224,x:32228,y:32936,varname:node_4224,prsc:2|IN-5913-R;n:type:ShaderForge.SFN_Round,id:5921,x:32245,y:33278,varname:node_5921,prsc:2|IN-8120-G;n:type:ShaderForge.SFN_Round,id:8031,x:32242,y:33609,varname:node_8031,prsc:2|IN-1963-B;n:type:ShaderForge.SFN_Round,id:7090,x:32251,y:33958,varname:node_7090,prsc:2|IN-8629-A;proporder:3162-8939-9468-1519-3509-6886;pass:END;sub:END;*/

Shader "Shader Forge/Parallax" {
    Properties {
        _offsetdifference ("offset difference", Range(0, 1)) = 0.2365446
        _gradient ("gradient", Range(0, 1)) = 0.2222222
        _Color ("Color", Color) = (0.1255407,0.3387513,0.6323529,1)
        _MainTex ("Main Tex", 2D) = "white" {}
        _texture ("texture", 2D) = "white" {}
        _objectrotation ("object rotation", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
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
            uniform float _gradient;
            uniform float4 _Color;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform sampler2D _texture; uniform float4 _texture_ST;
            uniform float _objectrotation;
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
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 objPos = mul ( unity_ObjectToWorld, float4(0,0,0,1) );
                float4 node_5913 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(round(node_5913.r) - 0.5);
////// Lighting:
////// Emissive:
                float node_5752_ang = _objectrotation;
                float node_5752_spd = 1.0;
                float node_5752_cos = cos(node_5752_spd*node_5752_ang);
                float node_5752_sin = sin(node_5752_spd*node_5752_ang);
                float2 node_5752_piv = float2(0.5,0.5);
                float2 node_5752 = (mul(float2((_WorldSpaceCameraPos.r-objPos.r),(_WorldSpaceCameraPos.g-objPos.g))-node_5752_piv,float2x2( node_5752_cos, -node_5752_sin, node_5752_sin, node_5752_cos))+node_5752_piv);
                float node_920 = 0.014;
                float node_2630 = (node_920+node_920);
                float2 node_8460 = (i.uv0-(node_5752*(node_2630+node_920)));
                float4 node_6587 = tex2D(_MainTex,TRANSFORM_TEX(node_8460, _MainTex));
                float node_2354 = 1.0;
                float node_1290 = ((node_2354-_gradient)-_gradient);
                float node_7039 = (node_1290-_gradient);
                float4 node_2014 = tex2D(_texture,TRANSFORM_TEX(node_8460, _texture));
                float2 node_8047 = (i.uv0-(node_5752*node_2630));
                float4 node_3294 = tex2D(_MainTex,TRANSFORM_TEX(node_8047, _MainTex));
                float4 node_2775 = tex2D(_texture,TRANSFORM_TEX(node_8460, _texture));
                float4 node_8629 = tex2D(_MainTex,TRANSFORM_TEX(node_8460, _MainTex));
                float2 node_983 = (i.uv0-(node_5752*node_920));
                float4 node_517 = tex2D(_MainTex,TRANSFORM_TEX(node_983, _MainTex));
                float4 node_9109 = tex2D(_texture,TRANSFORM_TEX(node_8047, _texture));
                float4 node_1963 = tex2D(_MainTex,TRANSFORM_TEX(node_8047, _MainTex));
                float4 node_6727 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_6358 = tex2D(_texture,TRANSFORM_TEX(node_983, _texture));
                float4 node_8120 = tex2D(_MainTex,TRANSFORM_TEX(node_983, _MainTex));
                float3 emissive = (_Color.rgb*lerp(lerp(lerp((node_6587.a*(node_7039-_gradient)*node_2014.rgb),(node_3294.b*node_7039*node_2775.rgb),(1.0 - round(node_8629.a))),(node_517.g*node_1290*node_9109.rgb),(1.0 - round(node_1963.b))),(node_2354*node_6727.r*node_6358.rgb),(1.0 - round(node_8120.g))));
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
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
                float4 node_5913 = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                clip(round(node_5913.r) - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
