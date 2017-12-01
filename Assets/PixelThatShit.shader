Shader "Hidden/PixelThatShit"
{
	Properties
	{
		_MainTex ("Texture", 2D) = "white" {}
	}
	SubShader
	{
		// No culling or depth
		Cull Off ZWrite Off ZTest Always

		Pass
		{
			CGPROGRAM
			#pragma vertex vert
			#pragma fragment frag
			
			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float2 uv : TEXCOORD0;
			};

			struct v2f
			{
				float2 uv : TEXCOORD0;
				float4 vertex : SV_POSITION;
			};

			v2f vert (appdata v)
			{
				v2f o;
				o.vertex = UnityObjectToClipPos(v.vertex);
				o.uv = v.uv;
				return o;
			}
			
			sampler2D _MainTex;

			fixed4 frag (v2f i) : SV_Target
			{
				float2 newUV = i.uv;
			
				float2 targetRes = _ScreenParams.xy / 6.;
				float2 inPixel = frac(i.uv*targetRes);
				float2 nearEdge = min(inPixel, 1. - inPixel);
				
				newUV = newUV - frac(i.uv*targetRes) / targetRes + 0.5/ targetRes;
				newUV = newUV - frac(i.uv * _ScreenParams.xy) / _ScreenParams.xy;
				fixed4 col = tex2D(_MainTex, newUV);

				//col *= pow(2.*min(nearEdge.y,nearEdge.x),.1);

				return col;
			}
			ENDCG
		}
	}
}
