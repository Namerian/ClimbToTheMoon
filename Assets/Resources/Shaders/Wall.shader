// Shader created with Shader Forge v1.32 
// Shader Forge (c) Neat Corporation / Joachim Holmer - http://www.acegikmo.com/shaderforge/
// Note: Manually altering this data may prevent you from opening it in Shader Forge
/*SF_DATA;ver:1.32;sub:START;pass:START;ps:flbk:,iptp:0,cusa:False,bamd:0,lico:1,lgpr:1,limd:0,spmd:1,trmd:0,grmd:0,uamb:True,mssp:True,bkdf:False,hqlp:False,rprd:False,enco:False,rmgx:True,rpth:0,vtps:0,hqsc:True,nrmq:1,nrsp:0,vomd:0,spxs:False,tesm:0,olmd:1,culm:0,bsrc:0,bdst:1,dpts:2,wrdp:True,dith:0,rfrpo:True,rfrpn:Refraction,coma:15,ufog:False,aust:True,igpj:False,qofs:0,qpre:2,rntp:3,fgom:False,fgoc:False,fgod:False,fgor:False,fgmd:0,fgcr:0.5,fgcg:0.5,fgcb:0.5,fgca:1,fgde:0.01,fgrn:0,fgrf:300,stcl:False,stva:128,stmr:255,stmw:255,stcp:6,stps:0,stfa:0,stfz:0,ofsf:0,ofsu:0,f2p0:False,fnsp:False,fnfb:False;n:type:ShaderForge.SFN_Final,id:3138,x:33850,y:32883,varname:node_3138,prsc:2|emission-345-OUT,clip-1062-A;n:type:ShaderForge.SFN_FragmentPosition,id:4721,x:31345,y:32375,varname:node_4721,prsc:2;n:type:ShaderForge.SFN_Append,id:5037,x:31645,y:32394,varname:node_5037,prsc:2|A-4721-X,B-4721-Y;n:type:ShaderForge.SFN_Multiply,id:8128,x:31804,y:32394,varname:node_8128,prsc:2|A-5037-OUT,B-9237-OUT;n:type:ShaderForge.SFN_Slider,id:9237,x:31488,y:32539,ptovrint:False,ptlb:scale,ptin:_scale,varname:node_9237,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:1,max:1;n:type:ShaderForge.SFN_Tex2d,id:8223,x:32630,y:32349,varname:node_8223,prsc:2,tex:38bdb62466fb1c04c8a9324eab9c4c20,ntxv:0,isnm:False|UVIN-8128-OUT,TEX-5524-TEX;n:type:ShaderForge.SFN_Tex2d,id:1062,x:32644,y:32989,varname:node_1062,prsc:2,tex:38bdb62466fb1c04c8a9324eab9c4c20,ntxv:0,isnm:False|TEX-5524-TEX;n:type:ShaderForge.SFN_Tex2dAsset,id:5524,x:31939,y:32812,ptovrint:False,ptlb:tex,ptin:_tex,varname:node_5524,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,tex:38bdb62466fb1c04c8a9324eab9c4c20,ntxv:0,isnm:False;n:type:ShaderForge.SFN_RgbToHsv,id:5936,x:32931,y:32330,varname:node_5936,prsc:2|IN-8223-RGB;n:type:ShaderForge.SFN_Add,id:3530,x:33165,y:32432,varname:node_3530,prsc:2|A-5936-HOUT,B-5108-OUT;n:type:ShaderForge.SFN_Slider,id:5108,x:32551,y:32544,ptovrint:False,ptlb:Hue shift,ptin:_Hueshift,varname:node_5108,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,min:0,cur:0,max:1;n:type:ShaderForge.SFN_HsvToRgb,id:7998,x:33364,y:32330,varname:node_7998,prsc:2|H-3530-OUT,S-5936-SOUT,V-5936-VOUT;n:type:ShaderForge.SFN_Multiply,id:345,x:33613,y:32917,varname:node_345,prsc:2|A-8820-OUT,B-850-OUT;n:type:ShaderForge.SFN_ToggleProperty,id:3693,x:32915,y:32836,ptovrint:False,ptlb:use red,ptin:_usered,varname:node_3693,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_ToggleProperty,id:6542,x:32915,y:32985,ptovrint:False,ptlb:use blue,ptin:_useblue,varname:node_6542,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_ToggleProperty,id:5628,x:32915,y:32911,ptovrint:False,ptlb:use green,ptin:_usegreen,varname:node_5628,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:True;n:type:ShaderForge.SFN_Append,id:850,x:33104,y:32867,varname:node_850,prsc:2|A-3693-OUT,B-5628-OUT,C-6542-OUT;n:type:ShaderForge.SFN_SwitchProperty,id:8820,x:33509,y:32698,ptovrint:False,ptlb:use texture,ptin:_usetexture,varname:node_8820,prsc:2,glob:False,taghide:False,taghdr:False,tagprd:False,tagnsco:False,tagnrm:False,on:False|A-4411-OUT,B-7998-OUT;n:type:ShaderForge.SFN_RgbToHsv,id:5900,x:32825,y:32611,varname:node_5900,prsc:2|IN-9284-OUT;n:type:ShaderForge.SFN_Add,id:9375,x:33038,y:32676,varname:node_9375,prsc:2|A-5900-HOUT,B-5108-OUT;n:type:ShaderForge.SFN_HsvToRgb,id:4411,x:33308,y:32647,varname:node_4411,prsc:2|H-9375-OUT,S-5900-SOUT,V-5900-VOUT;n:type:ShaderForge.SFN_Vector3,id:9284,x:32577,y:32736,varname:node_9284,prsc:2,v1:0.8705883,v2:0.4745098,v3:0.5176471;proporder:9237-5524-5108-3693-6542-5628-8820;pass:END;sub:END;*/

Shader "Shader Forge/Wall2" {
    Properties {
        _scale ("scale", Range(0, 1)) = 1
        _tex ("tex", 2D) = "white" {}
        _Hueshift ("Hue shift", Range(0, 1)) = 0
        [MaterialToggle] _usered ("use red", Float ) = 1
        [MaterialToggle] _useblue ("use blue", Float ) = 1
        [MaterialToggle] _usegreen ("use green", Float ) = 1
        [MaterialToggle] _usetexture ("use texture", Float ) = 0.8705883
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
            #pragma only_renderers d3d9 d3d11 glcore gles gles3 d3d11_9x 
            #pragma target 3.0
            uniform float _scale;
            uniform sampler2D _tex; uniform float4 _tex_ST;
            uniform float _Hueshift;
            uniform fixed _usered;
            uniform fixed _useblue;
            uniform fixed _usegreen;
            uniform fixed _usetexture;
            struct VertexInput {
                float4 vertex : POSITION;
                float2 texcoord0 : TEXCOORD0;
            };
            struct VertexOutput {
                float4 pos : SV_POSITION;
                float2 uv0 : TEXCOORD0;
                float4 posWorld : TEXCOORD1;
            };
            VertexOutput vert (VertexInput v) {
                VertexOutput o = (VertexOutput)0;
                o.uv0 = v.texcoord0;
                o.posWorld = mul(unity_ObjectToWorld, v.vertex);
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex );
                return o;
            }
            float4 frag(VertexOutput i) : COLOR {
                float4 node_1062 = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                clip(node_1062.a - 0.5);
////// Lighting:
////// Emissive:
                float3 node_9284 = float3(0.8705883,0.4745098,0.5176471);
                float4 node_5900_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5900_p = lerp(float4(float4(node_9284,0.0).zy, node_5900_k.wz), float4(float4(node_9284,0.0).yz, node_5900_k.xy), step(float4(node_9284,0.0).z, float4(node_9284,0.0).y));
                float4 node_5900_q = lerp(float4(node_5900_p.xyw, float4(node_9284,0.0).x), float4(float4(node_9284,0.0).x, node_5900_p.yzx), step(node_5900_p.x, float4(node_9284,0.0).x));
                float node_5900_d = node_5900_q.x - min(node_5900_q.w, node_5900_q.y);
                float node_5900_e = 1.0e-10;
                float3 node_5900 = float3(abs(node_5900_q.z + (node_5900_q.w - node_5900_q.y) / (6.0 * node_5900_d + node_5900_e)), node_5900_d / (node_5900_q.x + node_5900_e), node_5900_q.x);;
                float2 node_8128 = (float2(i.posWorld.r,i.posWorld.g)*_scale);
                float4 node_8223 = tex2D(_tex,TRANSFORM_TEX(node_8128, _tex));
                float4 node_5936_k = float4(0.0, -1.0 / 3.0, 2.0 / 3.0, -1.0);
                float4 node_5936_p = lerp(float4(float4(node_8223.rgb,0.0).zy, node_5936_k.wz), float4(float4(node_8223.rgb,0.0).yz, node_5936_k.xy), step(float4(node_8223.rgb,0.0).z, float4(node_8223.rgb,0.0).y));
                float4 node_5936_q = lerp(float4(node_5936_p.xyw, float4(node_8223.rgb,0.0).x), float4(float4(node_8223.rgb,0.0).x, node_5936_p.yzx), step(node_5936_p.x, float4(node_8223.rgb,0.0).x));
                float node_5936_d = node_5936_q.x - min(node_5936_q.w, node_5936_q.y);
                float node_5936_e = 1.0e-10;
                float3 node_5936 = float3(abs(node_5936_q.z + (node_5936_q.w - node_5936_q.y) / (6.0 * node_5936_d + node_5936_e)), node_5936_d / (node_5936_q.x + node_5936_e), node_5936_q.x);;
                float3 emissive = (lerp( (lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((node_5900.r+_Hueshift)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_5900.g)*node_5900.b), (lerp(float3(1,1,1),saturate(3.0*abs(1.0-2.0*frac((node_5936.r+_Hueshift)+float3(0.0,-1.0/3.0,1.0/3.0)))-1),node_5936.g)*node_5936.b), _usetexture )*float3(_usered,_usegreen,_useblue));
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
                float4 node_1062 = tex2D(_tex,TRANSFORM_TEX(i.uv0, _tex));
                clip(node_1062.a - 0.5);
                SHADOW_CASTER_FRAGMENT(i)
            }
            ENDCG
        }
    }
    FallBack "Diffuse"
    CustomEditor "ShaderForgeMaterialInspector"
}
