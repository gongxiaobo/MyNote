// Made with Amplify Shader Editor
// Available at the Unity Asset Store - http://u3d.as/y3X 
Shader "MyShader/lightObj"
{
	Properties
	{
		[HideInInspector] __dirty( "", Int ) = 1
		_emission("emission", Color) = (0.5411981,0.7313044,0.8088235,0)
		_opacity_max("opacity_max", Float) = 0.75
		_opacity_min("opacity_min", Float) = 0.15
	}

	SubShader
	{
		Tags{ "RenderType" = "Transparent"  "Queue" = "Transparent+0" "IgnoreProjector" = "True" "IsEmissive" = "true"  }
		Cull Back
		CGPROGRAM
		#include "UnityShaderVariables.cginc"
		#pragma target 3.0
		#pragma surface surf Unlit alpha:fade keepalpha noshadow exclude_path:deferred 
		struct Input
		{
			fixed filler;
		};

		uniform float4 _emission;
		uniform float _opacity_min;
		uniform float _opacity_max;

		inline fixed4 LightingUnlit( SurfaceOutput s, half3 lightDir, half atten )
		{
			return fixed4 ( 0, 0, 0, s.Alpha );
		}

		void surf( Input i , inout SurfaceOutput o )
		{
			o.Emission = _emission.rgb;
			float clampResult5 = clamp( abs( sin( _Time.y ) ) , _opacity_min , _opacity_max );
			o.Alpha = clampResult5;
		}

		ENDCG
	}
	CustomEditor "ASEMaterialInspector"
}
/*ASEBEGIN
Version=13101
293;340;1428;789;1374.002;649.3754;1.678709;True;False
Node;AmplifyShaderEditor.TimeNode;2;-725.7604,-292.1288;Float;False;0;5;FLOAT4;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.SinOpNode;9;-536.316,-96.96091;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;12;-358.0812,91.82838;Float;False;Property;_opacity_max;opacity_max;1;0;0.75;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.RangedFloatNode;11;-378.3009,211.5374;Float;False;Property;_opacity_min;opacity_min;1;0;0.15;0;0;0;1;FLOAT
Node;AmplifyShaderEditor.AbsOpNode;15;-429.5187,-241.9026;Float;False;1;0;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ClampOpNode;5;-131.3564,-162.9317;Float;True;3;0;FLOAT;0.0;False;1;FLOAT;0.0;False;2;FLOAT;0.0;False;1;FLOAT
Node;AmplifyShaderEditor.ColorNode;1;5.806029,-375.0232;Float;False;Property;_emission;emission;0;0;0.5411981,0.7313044,0.8088235,0;0;5;COLOR;FLOAT;FLOAT;FLOAT;FLOAT
Node;AmplifyShaderEditor.StandardSurfaceOutputNode;0;325.7001,-360.7627;Float;False;True;2;Float;ASEMaterialInspector;0;0;Unlit;lightObj;False;False;False;False;False;False;False;False;False;False;False;False;False;False;True;False;False;Back;0;0;False;0;0;Transparent;0.5;True;False;0;False;Transparent;Transparent;ForwardOnly;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;True;False;0;255;255;0;0;0;0;False;0;4;10;25;False;0.5;False;0;Zero;Zero;0;Zero;Zero;Add;Add;0;False;0;0,0,0,0;VertexOffset;False;Cylindrical;False;Relative;0;;-1;-1;-1;-1;0;0;14;0;FLOAT3;0,0,0;False;1;FLOAT3;0,0,0;False;2;FLOAT3;0,0,0;False;3;FLOAT;0.0;False;4;FLOAT;0.0;False;6;FLOAT3;0,0,0;False;7;FLOAT3;0,0,0;False;8;FLOAT;0.0;False;9;FLOAT;0.0;False;10;OBJECT;0.0;False;11;FLOAT3;0,0,0;False;12;FLOAT3;0,0,0;False;14;FLOAT4;0,0,0,0;False;15;FLOAT3;0,0,0;False;0
WireConnection;9;0;2;2
WireConnection;15;0;9;0
WireConnection;5;0;15;0
WireConnection;5;1;11;0
WireConnection;5;2;12;0
WireConnection;0;2;1;0
WireConnection;0;9;5;0
ASEEND*/
//CHKSM=AB5AF136901FCF0D119BCC5B48FCC7E99731340D