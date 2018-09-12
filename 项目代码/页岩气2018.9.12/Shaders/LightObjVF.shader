Shader "MyShader/LightObjVF"
{
	Properties
	{
		//_MainTex ("Texture", 2D) = "white" {}
		_Color("color",Color)=(1,1,1,1)
		_Frequency("Frequency",Float)=1
		_AlphaMax("AlphaMax",Float)=1
		_AlphaMin("AlphaMin",Float)=0
		//_Color1("color",Color)=(1,1,1,1)
	}
	SubShader
	{
		Tags { "RenderType"="Transparent" "Queue"="Transparent+2000" }
		//LOD 100

		Pass
		{
			Tags{"LightMode"="Always"}
			ZTest Off
			ZWrite On
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
			};
			struct v2f
			{
				float4 vertex : SV_POSITION;
			};

			fixed4 _Color;
			float _Frequency;
			float _AlphaMax;
			float _AlphaMin;
			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				return o;
			}
			
			fixed4 frag (v2f i) : SV_Target
			{
				float tWave=_Frequency*_Time.y;
				float ta=abs(sin(tWave));
				_Color.w =clamp(ta,_AlphaMin,_AlphaMax);
				return _Color;
			}
			ENDCG
		}
	}
}
