// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "MyShaders/TwoLayerScroll"{
	Properties{
		_Layer1Tex("main texture" , 2D) = "white"{}
		_Layer2Tex("2nd texture" , 2D) = "white"{}
		_ScrollX ("scroll speed x" , Float) = 0.2
		_ScrollY ("scroll speed y" , Float) = 0
		_2ndScrollX ("2nd scroll speed x" , Float) = 0.5
		_2ndScrollY ("2nd scroll speed y" , Float) = 0
		_Multiplier ("multiplier" , Float) = 0.5
	}
	
	subshader{
		Tags{"Queue"="Geometry+10" "RenderType"="Opaque"}
		
		pass{
			Lighting off
			ZWrite off
			
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"
			
			sampler2D _Layer1Tex;
			sampler2D _Layer2Tex;
			float4 _Layer1Tex_ST;
			float4 _Layer2Tex_ST;
			float _ScrollX;
			float _ScrollY;
			float _2ndScrollX;
			float _2ndScrollY;
			float _Multiplier;
			
			struct v2f{
				float4 pos : SV_POSITION;
				float4 uv : TEXCOORD0;
			};
			
			v2f vert(appdata_full v)
			{
				v2f o;
				o.pos = UnityObjectToClipPos( v.vertex);
				o.uv.xy = _Layer1Tex_ST.xy * v.texcoord.xy + _Layer1Tex_ST.zw + frac(float2(_ScrollX , _ScrollY) * _Time.xx);
				o.uv.zw = _Layer2Tex_ST.xy * v.texcoord.xy + _Layer2Tex_ST.zw + frac(float2(_2ndScrollX , _2ndScrollY) * _Time.xx);
				return o;
			}
			
			fixed4 frag(v2f i):COLOR
			{
				fixed4 tex1 = tex2D(_Layer1Tex , i.uv.xy);
				fixed4 tex2 = tex2D(_Layer2Tex , i.uv.zw);
				return tex1 * tex2 * _Multiplier;
			}
			
			ENDCG
		}
	}
}