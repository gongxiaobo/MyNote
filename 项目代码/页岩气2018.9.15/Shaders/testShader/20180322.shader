// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'



Shader "MyShader/20180322"
{
	SubShader{
	Pass{
		CGPROGRAM
		#pragma vertex vert
		#pragma fragment frag
		#include "UnityCG.cginc"
		struct app{
		float4 vertex :POSITION;
		float3 normal :NORMAL;
		};

		struct v2f{
		float4 pos : SV_POSITION;
		half3 worldRefl : TEXCOORD0;
		};

		v2f vert(app _app){
			v2f o;
			o.pos = UnityObjectToClipPos(_app.vertex);
			//顶点的世界位置 compute world space position of the vertex
			float3 worldpos = mul(unity_ObjectToWorld, _app.vertex).xyz;
			//计算世界空间的视角方向 compute world space view direction
			float3 worldViewDir = normalize(UnityWorldSpaceViewDir(worldpos));
			//世界法线 world space normal
			float3 worldNormal = UnityObjectToWorldNormal(_app.normal);
			//视角方向在法线方反射方向 world space reflection vector
			o.worldRefl = reflect(-worldViewDir,worldNormal);
			return o;
		}
		fixed4 frag(v2f i) : SV_Target{
			//sample the default reflection cubemap, using the reflection vector
			//采样默认的立方贴图，使用反射线
			half4 skyData = UNITY_SAMPLE_TEXCUBE(unity_SpecCube0,i.worldRefl);
			//decode cubemap data into actual color
			//解码立方体图成实际的颜色
			half3 skycolor = DecodeHDR(skyData,unity_SpecCube0_HDR);
			fixed4 c = 0;
			c.rgb=skycolor;
			return c;
		
		}
		ENDCG
	}
	
	}
	
}
