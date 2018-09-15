Shader "MyShader/20180321"
{
	//Properties{
	//	//_MainTex("Maintex",2D)="white"{}
	//	//_Color("color",Color)=(1,1,1,1)
	//}
	SubShader{
		//Tags{"Queue"="Opaque" "RenderType"="opaque" "Preview"="Cube"}
		Pass {
			
			//Blend SrcAlpha OneMinusSrcAlpha
			//Tags{"LightMode"="Always"}
			//ZTest Off
			//ZWrite On
			
			CGPROGRAM

			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"


			//sampler2D _MainTex;
			//float4 _MainTex_ST;
			//fixed4 _Color;

			struct app
			{
				float4 vertex :POSITION ;
				float3 normal: NORMAL;
				//float2 uv :TEXCOORD0 ; 
			};
			struct v2f
			{
				float4 pos:SV_POSITION;
				half3 worldNormal:TEXCOORD0;
				//float2 uv :TEXCOORD0;
			};
			struct final
			{
				fixed4 outcoor:SV_Target;
			};

			v2f vert(app _app){
				v2f o;
				o.pos=UnityObjectToClipPos(_app.vertex);
				//o.uv = TRANSFORM_TEX(_app.uv,_MainTex);
				o.worldNormal=UnityObjectToWorldNormal(_app.normal);
				//o.worldNormal=_app.normal;
				return o;
			}
			final frag(v2f _v2f){
				final o;
				//o.outcoor = (tex2D(_MainTex,_v2f.uv).rgb,0.5);
				o.outcoor.rgb =_v2f.worldNormal*0.5+0.5;
				return o;
			}
			ENDCG

		}
	
}
}
