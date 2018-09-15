Shader "MyShader/testShader"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
		_Color("color",Color)=(1,1,1,1)
		_Frequency("frequency",Float)=2
		//_vector("vector",float3) = (1,1,1)
	}
	SubShader
	{
		Pass {
			Tags{"LightMode"="ForwardBase"}
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag 
			#include "UnityCG.cginc"
			struct appdate
			{
				float4 vertex :POSITION ;
				float2 uv:TEXCOORD0 ; 
				
			};
			struct v2f
			{
				float4 pos : SV_POSITION;
				float2 uv : TEXCOORD0 ; 
				fixed value : TEXCOORD1  ;
			};
			struct f_out
			{
				fixed4 showcolor:SV_Target;
			};
			sampler2D _MainTex;
			fixed4 _Color;
			float4 _MainTex_ST;
			Float _Frequency;
			//float3 _vector;
			v2f vert(appdate _app){

				v2f o;
				o.pos=UnityObjectToClipPos(_app.vertex);
				o.uv=TRANSFORM_TEX(_app.uv,_MainTex);
				
				float3 worldpos=mul(unity_ObjectToWorld,_app.vertex);
				fixed dir=dot(worldpos,_WorldSpaceLightPos0.xyz);
				if (dir>0)
				{
				o.value=0;	
				}else if(dir<0){
				o.value=1;
				}else{
					o.value=0.5;
				}
				
				// o.value=worldpos.x;
				return o;
			}

			f_out frag(v2f _i) {
				f_out o;
				// fixed4 timeColor=(saturate(round(0.5)),1,1,1);
				fixed4 outcolor =(1,0,0,1);
				// outcolor.x=sin((_Time.y+outcolor.x)*_Frequency);
				// outcolor = tex2D(_MainTex,_i.uv);
				// outcolor*=_Color;
				// outcolor=_Color;
				// outcolor*=timeColor;
				o.showcolor=_Color*outcolor;
				return o;
			}


			ENDCG 
		}
		
	}
}
