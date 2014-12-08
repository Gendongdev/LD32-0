Shader "Custom/WriteDepth" {
    Properties {
        _MainTex ("Base (RGB)", 2D) = "white" {}
		_Color ("Main Color", Color) = (1,1,1,0)
    }
    SubShader {
        Tags { "RenderType"="Opaque" }
 
        Pass {
            CGPROGRAM        
                #pragma exclude_renderers gles flash
                #pragma vertex vert
                #pragma fragment frag
               
                #include "UnityCG.cginc"
                               
                struct v2f {
                    float4 pos : POSITION;
                    float2 uv : TEXCOORD0;
                };
               
                struct fout {
                    half4 color : COLOR;
                    float depth : DEPTH;
                };                
               
			   float4 _Color;
                uniform sampler2D _MainTex;
               
                v2f vert (appdata_base v) {
                    v2f vo;
                    vo.pos = mul( UNITY_MATRIX_MVP, v.vertex );
                    vo.uv = v.texcoord.xy;
                    return vo;
                }
             
                fout frag( v2f i ) {              
                    fout fo;
                    fo.color = _Color;
                    fo.depth = 0.99;
                    return fo;
                }
            ENDCG
            }
   
    }
    FallBack "Diffuse"
}