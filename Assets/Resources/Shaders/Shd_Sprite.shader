// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Shader created with Shader Forge v1.26 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.26;sub:START;pass:START;ps:flbk:,iptp:1,cusa:True,bamd:0,lico:1,lgpr:1,limd:1,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:True,tesm:0,olmd:1,culm:2,bsrc:3,bdst:7,dpts:2,wrdp:False,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:True,qofs:0,qpre:3,rntp:2,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:1873,x:33229,y:32719,varname:node_1873,prsc:2|diff-2533-OUT,emission-6177-OUT,alpha-603-OUT;n:type:ShaderForge.SFN_Tex2d,id:4805,x:31258,y:32735,ptovrint:False,ptlb:MainTex,ptin:_MainTex,varname:_MainTex_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:True,tagnsco:False,tagnrm:False,ntxv:0,isnm:False;n:type:ShaderForge.SFN_Multiply,id:1086,x:32125,y:32807,cmnt:RGB,varname:node_1086,prsc:2|A-3095-OUT,B-8534-OUT,C-5376-RGB;n:type:ShaderForge.SFN_Color,id:5983,x:31258,y:32921,ptovrint:False,ptlb:Color,ptin:_Color,varname:_Color_copy,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,c1:1,c2:1,c3:1,c4:1;n:type:ShaderForge.SFN_VertexColor,id:5376,x:31829,y:33042,varname:node_5376,prsc:2;n:type:ShaderForge.SFN_Multiply,id:1749,x:32336,y:32807,cmnt:Premultiply Alpha,varname:node_1749,prsc:2|A-1086-OUT,B-603-OUT;n:type:ShaderForge.SFN_Multiply,id:603,x:32161,y:32982,cmnt:A,varname:node_603,prsc:2|A-4805-A,B-5983-A,C-5376-A;n:type:ShaderForge.SFN_HsvToRgb,id:8534,x:31875,y:32618,varname:node_8534,prsc:2|H-5038-HOUT,S-5038-SOUT,V-3578-OUT;n:type:ShaderForge.SFN_ValueProperty,id:3578,x:31657,y:32638,ptovrint:False,ptlb:Luminosite,ptin:_Luminosite,varname:node_3578,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_RgbToHsv,id:5038,x:31657,y:32483,varname:node_5038,prsc:2|IN-5983-RGB;n:type:ShaderForge.SFN_Desaturate,id:4142,x:31549,y:32808,varname:node_4142,prsc:2|COL-4805-RGB;n:type:ShaderForge.SFN_SwitchProperty,id:3095,x:31718,y:32780,ptovrint:False,ptlb:Recolorize,ptin:_Recolorize,varname:node_3095,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4805-RGB,B-4142-OUT;n:type:ShaderForge.SFN_ValueProperty,id:1792,x:32248,y:33194,ptovrint:False,ptlb:Saturation,ptin:_Saturation,varname:node_1792,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_Desaturate,id:9712,x:32595,y:32795,varname:node_9712,prsc:2|COL-1086-OUT,DES-447-OUT;n:type:ShaderForge.SFN_OneMinus,id:447,x:32374,y:33117,varname:node_447,prsc:2|IN-1792-OUT;n:type:ShaderForge.SFN_Power,id:2533,x:32866,y:32786,varname:node_2533,prsc:2|VAL-1567-OUT,EXP-5072-OUT;n:type:ShaderForge.SFN_ValueProperty,id:5072,x:32576,y:32995,ptovrint:False,ptlb:Contraste,ptin:_Contraste,varname:node_5072,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:1;n:type:ShaderForge.SFN_SwitchProperty,id:6177,x:33026,y:32492,ptovrint:False,ptlb:Unlit,ptin:_Unlit,varname:node_6177,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True|A-3870-OUT,B-2533-OUT;n:type:ShaderForge.SFN_Vector1,id:3870,x:32818,y:32477,varname:node_3870,prsc:2,v1:0;n:type:ShaderForge.SFN_HsvToRgb,id:1567,x:32627,y:32584,varname:node_1567,prsc:2|H-2953-OUT,S-1834-SOUT,V-1834-VOUT;n:type:ShaderForge.SFN_RgbToHsv,id:1834,x:32446,y:32562,varname:node_1834,prsc:2|IN-9712-OUT;n:type:ShaderForge.SFN_Add,id:2953,x:32549,y:32303,varname:node_2953,prsc:2|A-5834-OUT,B-1834-HOUT;n:type:ShaderForge.SFN_ValueProperty,id:5834,x:32340,y:32410,ptovrint:False,ptlb:Hue,ptin:_Hue,varname:node_5834,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,v1:0;proporder:4805-5983-3095-5834-1792-3578-5072-6177;pass:END;sub:END;*/

Shader "Custom/Shd_Sprite" {
    Properties {
        [PerRendererData]_MainTex ("MainTex", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        [MaterialToggle] _Recolorize ("Recolorize", Float ) = 0
        _Hue ("Hue", Float ) = 0
        _Saturation ("Saturation", Float ) = 1
        _Luminosite ("Luminosite", Float ) = 1
        _Contraste ("Contraste", Float ) = 1
        [MaterialToggle] _Unlit ("Unlit", Float ) = 0
        [HideInInspector]_Cutoff ("Alpha cutoff", Range(0,1)) = 0.5
        [MaterialToggle] PixelSnap ("Pixel snap", Float) = 0
    }
    SubShader {
        Tags {
            "IgnoreProjector"="True"
            "Queue"="Transparent"
            "RenderType"="Transparent"
            "CanUseSpriteAtlas"="True"
            "PreviewType"="Plane"
        }
        Pass {
            Name "FORWARD"
            Tags {
                "LightMode"="ForwardBase"
            }
            Blend SrcAlpha OneMinusSrcAlpha
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDBASE
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #pragma multi_compile_fwdbase
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Luminosite;
            uniform fixed _Recolorize;
            uniform float _Saturation;
            uniform float _Contraste;
            uniform fixed _Unlit;
            uniform float _Hue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(_WorldSpaceLightPos0.xyz);
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = 1;
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float3 indirectDiffuse = float3(0,0,0);
                indirectDiffuse += UNITY_LIGHTMODEL_AMBIENT.rgb; // Ambient Light
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_5038_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5038_p = lerp(float4(float4(_Color.rgb,0.0).zy, node_5038_k.wz), float4(float4(_Color.rgb,0.0).yz, node_5038_k.xy), step(float4(_Color.rgb,0.0).z, float4(_Color.rgb,0.0).y));
                float4 node_5038_q = lerp(float4(node_5038_p.xyw, float4(_Color.rgb,0.0).x), float4(float4(_Color.rgb,0.0).x, node_5038_p.yzx), step(node_5038_p.x, float4(_Color.rgb,0.0).x));
                float node_5038_d = node_5038_q.x - min(node_5038_q.w, node_5038_q.y);
                float node_5038_e = 1.0e-10;
                float3 node_5038 = float3(abs(node_5038_q.z + (node_5038_q.w - node_5038_q.y) / (6.0 * node_5038_d + node_5038_e)), node_5038_d / (node_5038_q.x + node_5038_e), node_5038_q.x);;
                float3 node_1086 = (lerp( _MainTex_var.rgb, dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)), _Recolorize )*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_5038.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_5038.g)*_Luminosite)*i.vertexColor.rgb); // RGB
                float3 node_9712 = lerp(node_1086,dot(node_1086,float3(0.3,0.59,0.11)),(1.0 - _Saturation));
                float4 node_1834_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1834_p = lerp(float4(float4(node_9712,0.0).zy, node_1834_k.wz), float4(float4(node_9712,0.0).yz, node_1834_k.xy), step(float4(node_9712,0.0).z, float4(node_9712,0.0).y));
                float4 node_1834_q = lerp(float4(node_1834_p.xyw, float4(node_9712,0.0).x), float4(float4(node_9712,0.0).x, node_1834_p.yzx), step(node_1834_p.x, float4(node_9712,0.0).x));
                float node_1834_d = node_1834_q.x - min(node_1834_q.w, node_1834_q.y);
                float node_1834_e = 1.0e-10;
                float3 node_1834 = float3(abs(node_1834_q.z + (node_1834_q.w - node_1834_q.y) / (6.0 * node_1834_d + node_1834_e)), node_1834_d / (node_1834_q.x + node_1834_e), node_1834_q.x);;
                float3 node_2533 = pow((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_Hue+node_1834.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1834.g)*node_1834.b),_Contraste);
                float3 diffuseColor = node_2533;
                float3 diffuse = (directDiffuse + indirectDiffuse) * diffuseColor;
////// Emissive:
                float3 emissive = lerp( 0.0, node_2533, _Unlit );
/// Final Color:
                float3 finalColor = diffuse + emissive;
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                return fixed4(finalColor,node_603);
            }
            ENDCG
        }
        Pass {
            Name "FORWARD_DELTA"
            Tags {
                "LightMode"="ForwardAdd"
            }
            Blend One One
            Cull Off
            ZWrite Off
            
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            #define UNITY_PASS_FORWARDADD
            #pragma multi_compile _ PIXELSNAP_ON
            #include "UnityCG.cginc"
            #include "AutoLight.cginc"
            #pragma multi_compile_fwdadd
            #pragma exclude_renderers gles3 metal d3d11_9x xbox360 xboxone ps3 ps4 psp2 
            #pragma target 3.0
            uniform float4 _LightColor0;
            uniform sampler2D _MainTex; uniform float4 _MainTex_ST;
            uniform float4 _Color;
            uniform float _Luminosite;
            uniform fixed _Recolorize;
            uniform float _Saturation;
            uniform float _Contraste;
            uniform fixed _Unlit;
            uniform float _Hue;
            struct VertexInput {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float2 texcoord0 : TEXCOORD0;
                float4 vertexColor : COLOR;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
                float3 normalDir : TEXCOORD2;
                float4 vertexColor : COLOR;
                LIGHTING_COORDS(3,4)
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.vertexColor = v.vertexColor;
                o.normalDir = UnityObjectToWorldNormal(v.normal);
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                float3 lightColor = _LightColor0.rgb;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                #ifdef PIXELSNAP_ON
                    o.pos = UnityPixelSnap(o.pos);
                #endif
                TRANSFER_VERTEX_TO_FRAGMENT(o)
                return o;
            }
            float4 frag(VertexOutput i, float facing : VFACE) : COLOR {
                float isFrontFace = ( facing >= 0 ? 1 : 0 );
                float faceSign = ( facing >= 0 ? 1 : -1 );
                i.normalDir = normalize(i.normalDir);
                i.normalDir *= faceSign;
                float3 viewDirection = normalize(_WorldSpaceCameraPos.xyz - i.posWorld.xyz);
                float3 normalDirection = i.normalDir;
                float3 lightDirection = normalize(lerp(_WorldSpaceLightPos0.xyz, _WorldSpaceLightPos0.xyz - i.posWorld.xyz,_WorldSpaceLightPos0.w));
                float3 lightColor = _LightColor0.rgb;
////// Lighting:
                float attenuation = LIGHT_ATTENUATION(i);
                float3 attenColor = attenuation * _LightColor0.xyz;
/////// Diffuse:
                float NdotL = max(0.0,dot( normalDirection, lightDirection ));
                float3 directDiffuse = max( 0.0, NdotL) * attenColor;
                float4 _MainTex_var = tex2D(_MainTex,TRANSFORM_TEX(i.uv0, _MainTex));
                float4 node_5038_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5038_p = lerp(float4(float4(_Color.rgb,0.0).zy, node_5038_k.wz), float4(float4(_Color.rgb,0.0).yz, node_5038_k.xy), step(float4(_Color.rgb,0.0).z, float4(_Color.rgb,0.0).y));
                float4 node_5038_q = lerp(float4(node_5038_p.xyw, float4(_Color.rgb,0.0).x), float4(float4(_Color.rgb,0.0).x, node_5038_p.yzx), step(node_5038_p.x, float4(_Color.rgb,0.0).x));
                float node_5038_d = node_5038_q.x - min(node_5038_q.w, node_5038_q.y);
                float node_5038_e = 1.0e-10;
                float3 node_5038 = float3(abs(node_5038_q.z + (node_5038_q.w - node_5038_q.y) / (6.0 * node_5038_d + node_5038_e)), node_5038_d / (node_5038_q.x + node_5038_e), node_5038_q.x);;
                float3 node_1086 = (lerp( _MainTex_var.rgb, dot(_MainTex_var.rgb,float3(0.3,0.59,0.11)), _Recolorize )*(lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac(node_5038.r+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_5038.g)*_Luminosite)*i.vertexColor.rgb); // RGB
                float3 node_9712 = lerp(node_1086,dot(node_1086,float3(0.3,0.59,0.11)),(1.0 - _Saturation));
                float4 node_1834_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_1834_p = lerp(float4(float4(node_9712,0.0).zy, node_1834_k.wz), float4(float4(node_9712,0.0).yz, node_1834_k.xy), step(float4(node_9712,0.0).z, float4(node_9712,0.0).y));
                float4 node_1834_q = lerp(float4(node_1834_p.xyw, float4(node_9712,0.0).x), float4(float4(node_9712,0.0).x, node_1834_p.yzx), step(node_1834_p.x, float4(node_9712,0.0).x));
                float node_1834_d = node_1834_q.x - min(node_1834_q.w, node_1834_q.y);
                float node_1834_e = 1.0e-10;
                float3 node_1834 = float3(abs(node_1834_q.z + (node_1834_q.w - node_1834_q.y) / (6.0 * node_1834_d + node_1834_e)), node_1834_d / (node_1834_q.x + node_1834_e), node_1834_q.x);;
                float3 node_2533 = pow((lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((_Hue+node_1834.r)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_1834.g)*node_1834.b),_Contraste);
                float3 diffuseColor = node_2533;
                float3 diffuse = directDiffuse * diffuseColor;
/// Final Color:
                float3 finalColor = diffuse;
                float node_603 = (_MainTex_var.a*_Color.a*i.vertexColor.a); // A
                return fixed4(finalColor * node_603,0);
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
