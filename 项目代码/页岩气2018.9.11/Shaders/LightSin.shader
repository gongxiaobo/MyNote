Shader "MyShader/LightSin"
{
	Properties
	{
		_Color("color",Color)=(1,1,1,1)
		_Frequency("Frequency",Float)=1
		_AlphaMax("AlphaMax",Float)=1
		_AlphaMin("AlphaMin",Float)=0
		_ColorA("colora",Color)=(1,1,1,1)
	}
	SubShader
	{
		
		Tags { "RenderType"="Transparent" "Queue"="Transparent" }
		Pass
		{
			Blend SrcAlpha OneMinusSrcAlpha
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			
			#include "UnityCG.cginc"
			fixed4 _Color;
			fixed4 _ColorA;
			float _Frequency;
			Float _AlphaMax;
			Float _AlphaMin;
			struct appdata
			{
				float4 vertex : POSITION;
				
			};

			struct v2f
			{
				
				
				float4 vertex : SV_POSITION;
			};

		
			
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
				// sample the texture
				fixed4 col = _Color;
				
				return col;
			}
			ENDCG
		}
	}
}
