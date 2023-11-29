// Define a new shader called "Custom/Glitch"
Shader "Custom/Glitch" {

    // Declare the properties for the shader
    Properties {
        // A texture property named "_MainTex", set to a default white texture
        _MainTex ("Texture", 2D) = "white" {}
        // A color property named "_Color", set to white
        _Color ("Color", Color) = (1,1,1,1)
        // A range property named "_Speed" with a range of 0-5, set to 1
        _Speed ("Speed", Range(0,5)) = 1
        // A range property named "_Amount" with a range of 0-1, set to 0.5
        _Amount ("Amount", Range(0,1)) = 0.5

        _Alpha ("Alpha", Range(0,1)) = 0.9
    }

    // Declare the subshaders for the shader
    SubShader {
        // Set some rendering tags for the subshader
        Tags {"Queue"="Transparent" "IgnoreProjector" = "True" "RenderType"="Transparent"}
        // Set the level of detail for the subshader
        LOD 100
        ZWrite Off
        Blend SrcAlpha OneMinusSrcAlpha
        Cull front

        // Declare a pass for the subshader
        Pass {
            // Begin CG code
            CGPROGRAM
            // Include the vertex shader function
            #pragma vertex vert alpha
            // Include the fragment shader function
            #pragma fragment frag alpha
            // Include the UnityCG.cginc file for common functions and variables
            #include "UnityCG.cginc"

            // Declare a struct for the vertex data
            struct appdata {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;

                UNITY_VERTEX_INPUT_INSTANCE_ID //Insert
            };

            // Declare a struct for the output data
            struct v2f {
                float2 uv : TEXCOORD0;
                float4 vertex : SV_POSITION;

                UNITY_VERTEX_OUTPUT_STEREO //Insert
            };

            // Declare the sampler2D for the main texture
            sampler2D _MainTex;
            // Declare the texture coordinate transform for the main texture
            float4 _MainTex_ST;
            // Declare the color property for the shader
            float4 _Color;
            // Declare the speed property for the shader
            float _Speed;
            // Declare the amount property for the shader
            float _Amount;
            // declare alpha param
            float _Alpha;

            // Define the vertex shader function
            v2f vert (appdata v) {
                v2f o;

                UNITY_SETUP_INSTANCE_ID(v); //Insert
                UNITY_INITIALIZE_OUTPUT(v2f, o); //Insert
                UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o); //Insert

                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                return o;
            }

            // Define the distortion function for the glitch effect
            float2 distortion(float2 p, float t) {
                float2 frequency = float2(10.0, 30.0);
                float2 amplitude = float2(0.02, 0.05);
                float2 speed = float2(0.1, 0.2);
                float2 offset = float2(-0.1, 0.1);
                float2 distortion = 0.5 * sin(frequency * p * t + offset);
                distortion *= amplitude * (1.0 - smoothstep(0.0, 1.0, p.y));
                distortion *= 1.0 - pow(p.y, 3.0);
                distortion *= step(p.y, 1.0) * step(0.0, p.y);
                return distortion;
            }

            // Define the fragment shader function
            float4 frag (v2f i) : SV_Target {
                // Calculate the current time multiplied by the speed property
                float t = _Time.y * _Speed;
                // Calculate the distortion for the glitch effect
                float2 distortionAmount = distortion(i.uv, t);
                // Offset the texture coordinates using the distortion
                float2 offset = distortionAmount * _Amount;
                float4 color = tex2D(_MainTex, i.uv + offset);

                // Apply the color property to the texture
                color *= _Color;
                color *= _Alpha;

                return color;
            }

            // End CG code
            ENDCG
        }
    }
    // Declare the fallback for the shader
    FallBack "Diffuse"
}